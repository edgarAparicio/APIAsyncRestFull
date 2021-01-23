using EdgarAparicio.Business.Entities.APIAsyncRESTFull;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EdgarAparico.Data.APIAsyncRESTFull.Services
{
    public interface IBook
    {
        //Sincrono
        //IEnumerable<Book> GetBooks();

        //Book GetBook(Guid id);

        //Asincrono
        //Se le agrega un sufijo asincronico al nombre del metodo para indicar que el metodo devuelve una tarea y no completara su trabajo sincronico 
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(Guid id);

    }
}
