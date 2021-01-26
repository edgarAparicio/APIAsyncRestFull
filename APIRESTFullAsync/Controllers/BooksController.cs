using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparico.Data.APIAsyncRESTFull.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRESTFullAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook booksRepositorie;

        public BooksController(IBook booksRepositorie)
        {
            this.booksRepositorie = booksRepositorie;
        }

        //Metodo normal
        //public IActionResult GetBooks()
        //{
        //    var books = booksRepositorie.GetBooksAsync();
        //    return Ok(books);
        //}

        //Metodo asincrono
        [HttpGet("libros")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await booksRepositorie.GetBooksAsync();
            return Ok(books);
        }
    }
}
