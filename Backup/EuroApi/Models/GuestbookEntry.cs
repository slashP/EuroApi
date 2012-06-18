using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EuroApi.Models
{
    public class Guestbook
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Du må skrive inn et Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Meldingen kan ikke være tom")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public virtual List<Comment> kommentar { get; set; }
    }
}