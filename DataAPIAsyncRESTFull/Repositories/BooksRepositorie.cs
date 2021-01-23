using EdgarAparicio.Business.Entities.APIAsyncRESTFull;
using EdgarAparico.Data.APIAsyncRESTFull.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarAparico.Data.APIAsyncRESTFull.Repositories
{

    //Tambien se implementara IDispose en este repositirio para que cuando se elimine el repositorio tambie se nuestro contexto 
    //Que no es necesario implementar estos metodos ya que el repositorio no tiene un finalizador. Pdria verse como un codigo innecesario
    //Un finalizador de este tipo se seule usar para deshacerse de los recursos no gestionados
    //Es solo para asegurarase que la clase se limpiara muy bien 
    public class BooksRepositorie : IBook, IDisposable
    {
        private DbContextAPIAsyncRESTFull DbContextAPI;

        public BooksRepositorie(DbContextAPIAsyncRESTFull dbContext)
        {
            this.DbContextAPI = dbContext;
        }


        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            //Aqui es un metodo normal todavia
            //var getBooks = DbContextAPI.Books.ToList();
            //return getBooks;

            //Para hacer un metodo asincrono 
            var getBooks = await DbContextAPI.Books.Include(b => b.Author).ToListAsync();
            return getBooks;
        }

        public async Task<Book> GetBookAsync(Guid id)
        {

            var getBook = await DbContextAPI.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
            return getBook;
        }

        public void Dispose()
        {
            Dispose(true);
            //GC o basura garantiza que CLR no llame al finalizador para nuestro repositorio
            //En otras palabras le estamos diciendo a GC que el repositoio ya se ha limpiado 
            GC.SuppressFinalize(this); 


        }

        protected virtual void Dispose(bool disposing)
        {
            //Cuando CLR disponga del repositorio
            //Verificamos si el contexto no es nulo y llamamos al metodo dispose y aegura que se elimine

            if (disposing)

                if(DbContextAPI != null)
                {
                    DbContextAPI.Dispose();
                    DbContextAPI = null;
                }  
            }
        }
    }
}
