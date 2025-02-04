﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;


[Table("Categorias")]
public class Category
{
    public Category()
    {
        Products = new Collection<Products>();
    }

    [Key]  
    public int CategoryId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    public ICollection<Products>? Products { get; set; }
}

