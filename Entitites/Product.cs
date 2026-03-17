using System.ComponentModel.DataAnnotations;

namespace Entitites
{
    public class Product
    {
        public Int64 Id { get; set; }
   
        public string Name { get; set; }
        public Double Price { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }
        public long CategoryId { get; set; }
        public Category category { get; set; }
        
    }
}
