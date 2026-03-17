using Entitites;
using Microsoft.AspNetCore.JsonPatch;
using System.ComponentModel.DataAnnotations;

namespace ModalClasses

{
    public class ProductDto
    {

        public string Name { get; set; }
        public Double? Price { get; set; }

        public JsonPatchDocument<Product>? Patch { get; set; }
        public string? CategoryName { get; set; }
         
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
    }
}
