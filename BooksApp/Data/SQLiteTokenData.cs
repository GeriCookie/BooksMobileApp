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

    public static class BooksDbContext
    {
        public static async void InitAsync()
        {
            var connection = GetDbConnectionAsync();
            await connection.CreateTableAsync<TokenModel>();
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

        public static async Task AddUserToken(TokenModel token)
        {
            var connection = GetDbConnectionAsync();

            await DelateUserToken(connection);
            await connection.InsertAsync(token);
        }

        public static async Task DelateUserToken(SQLiteAsyncConnection connection)
        {
            var result = await GetUserToken();

            if (result != null)
            {
                await connection.DeleteAllAsync<TokenModel>();
            }
        }

        public static async Task<TokenModel> GetUserToken()
        {
            var connection = GetDbConnectionAsync();
            var result = await connection.Table<TokenModel>().ToListAsync();
            return result.FirstOrDefault();
        }
    }
}
