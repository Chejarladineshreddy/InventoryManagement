using Entitites;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModalClasses
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public JsonPatchDocument<Category>? Patch { get; set; }

    }
}
