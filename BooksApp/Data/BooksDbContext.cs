namespace BooksApp.Data
{
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.Storage;

    using BooksApp.Models;
    using System.Collections.Generic;

    public static class BooksDbContext
    {
        public static async void InitAsync()
        {
            var connection = GetDbConnectionAsync();

            //Ignore IT!
            //await connection.DeleteAllAsync<PatternModel>();

            await connection.CreateTableAsync<TokenModel>();
            await connection.CreateTableAsync<PatternModel>();
            await DelateUserToken(connection);
        }

        public static SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "booksApp.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));


            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        public static async Task AddPattern(string pattern)
        {
            var connection = GetDbConnectionAsync();

            var newPattern = new PatternModel
            {
                Pattern = pattern
            };
            
            await connection.InsertOrReplaceAsync(newPattern);
        }

        public static async Task<IEnumerable<string>> GetAllPatternsAsync()
        {
            var connection = GetDbConnectionAsync();

            var result = await connection.Table<PatternModel>().ToListAsync();
            return result.Select(p => p.Pattern);
        }

        public static async Task AddUserToken(string token)
        {
            var connection = GetDbConnectionAsync();

            var newToken = new TokenModel
            {
                authKey = token
            };
            await DelateUserToken(connection);
            await connection.InsertAsync(newToken);
        }

        public static async Task DelateUserToken(SQLiteAsyncConnection connection)
        {
            var result = await GetUserToken();

            if (result != null)
            {
                await connection.DeleteAllAsync<TokenModel>();
            }
        }

        public static async Task<string> GetUserToken()
        {
            var connection = GetDbConnectionAsync();
            var result = await connection.Table<TokenModel>().ToListAsync();
            var tokenModel = result.FirstOrDefault();
            if (tokenModel != null)
            {
                return tokenModel.authKey;
            }
            else
            {
                return null;
            }
        }
    }
}
