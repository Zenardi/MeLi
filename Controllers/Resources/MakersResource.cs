using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using meli.Models;

namespace meli.Controllers.Resources
{
    public class MakersResource
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }

        public MakersResource()
        {
            Models = new Collection<Model>();
        }
    }
}