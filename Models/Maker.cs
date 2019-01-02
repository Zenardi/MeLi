using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using meli.Controllers.Resources;

namespace meli.Models
{
    public class Maker
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<ModelsResource> Models { get; set; }

        public Maker()
        {
            Models = new Collection<ModelsResource>();
        }
    }
}