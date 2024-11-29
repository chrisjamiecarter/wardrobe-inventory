using System.ComponentModel.DataAnnotations;
using WardrobeInventory.Enums;

namespace WardrobeInventory.Blazor.Models;

public class WardrobeItemCreateDto
{
    [Required]
    public string? Name { get; set; }

    public string? ImagePath { get; set; }

    public WardrobeItemColours? Colour { get; set; }
    
    public WardrobeItemMaterials? Material { get; set; }

    public WardrobeItemSizes? Size { get; set; }
}
