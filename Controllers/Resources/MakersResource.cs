using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using meli.Models;

namespace meli.Controllers.Resources
{
    public class MakerResource
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public ICollection<ModelResource> Models { get; set; }

        public MakerResource()
        {
            Models = new Collection<ModelResource>();
        }
    }
}