using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewProject.Models
{
    public class OBJETOS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_OBJETO { get; set; }
        public string NOMBRE { get; set; }
        public string COLOR { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public decimal? PRECIO { get; set; }
    }
}