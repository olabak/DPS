using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppMVC.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        [Display(Name = "Dodano")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
