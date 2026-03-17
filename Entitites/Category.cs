using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Entitites
{
    public class Category
    {
        public Int64 Id { get; set; }
    
        public string Name { get; set; }
        public string Description { get; set; }
        //[JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
