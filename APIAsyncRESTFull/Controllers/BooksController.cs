using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.Business.Entities.APIAsyncRESTFull;
using EdgarAparico.Data.APIAsyncRESTFull.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIAsyncRESTFull.Controllers
{
    //Este atributo forazara el uso de enrutamiento basado en atributos que es la mejor practica para crear API
    [ApiController]
    //Todas las URL que se dirigen a este controlador comenzara con API/Books
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBook booksRepositorie;

        public BooksController(IBook booksRepositorie)
        {
            this.booksRepositorie = booksRepositorie;
        }

        //Metodo normal para obtener lista de libros
        public IActionResult ObtenerLibros()
        {
            var books = booksRepositorie.GetBooksAsync();
            return Ok(books);
        }

        //Metodo asincrono para obtener lista de libros 
        [HttpGet("ObtenerListaLibros")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await booksRepositorie.GetBooksAsync();
            return Ok(books);
        }

        //Metodo normal para obtener un libro
        public IActionResult ObtenerLibro(Guid bookId)
        {
            var book = booksRepositorie.GetBookAsync(bookId);
            return Ok(book);
        }

        //Metodo async para obtener un libro
        [HttpGet("ObtenerLibro")]
        [Route("{bookId}")]

        public async Task<IActionResult> GetBook(Guid bookId)
        {
            var book = await booksRepositorie.GetBookAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);

        }




    }
}
