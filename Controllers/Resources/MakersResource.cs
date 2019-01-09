using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using meli.Models;

namespace meli.Controllers.Resources
{
    public class MakerResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Models { get; set; }

        public MakerResource()
        {
            Models = new Collection<KeyValuePairResource>();
        }
    }
}