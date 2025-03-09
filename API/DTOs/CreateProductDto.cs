using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; }= string.Empty;

    [Range(0.01, double.MaxValue , ErrorMessage = "Price Must Be Greater Than Zero")]
    public decimal Price { get; set; }

    [Required]
    public string PictureUrl { get; set; }= string.Empty;

    [Required]
    public string Type { get; set; }= string.Empty;

    [Required]
    public string Brand { get; set; }= string.Empty;

    [Range(1 , int.MaxValue , ErrorMessage = "Quantity In Stock Must Be At Least One")]
    public int QuantityInStock { get; set; }
}
