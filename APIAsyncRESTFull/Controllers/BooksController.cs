﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
