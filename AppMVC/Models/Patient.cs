using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppMVC.Models
{
    public class Patient: Entity
    {
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [Display(Name = "Wiek")]
        public int Age { get; set; }
    }
}
