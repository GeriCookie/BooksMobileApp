﻿using BooksApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Models;
using BooksApp.Http;

namespace BooksApp.Data
{
  public class HttpDetailBookData : IDetailBookData
  {
    private string url;

    public HttpDetailBookData(string url)
    {
      this.url = url;
    }

    public async Task<DetailBookModel> GetBook(string id)
    {
      var endpointUrl = this.url + "/" + id;
      DetailBookModel book = await HttpRequester.Get<DetailBookModel>(endpointUrl);
      return book;
    }
  }
}
