using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EdgarAparicio.Business.Entities.APIAsyncRESTFull
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

        //Clave externa para la tabla author
        public Guid AuthorId { get; set; }

        //Propiedad de Navegacion a la tabla author, donde atraves del libro podemos acceder a la tabla Author relacionada
        public Author Author { get; set; }
    }
}
