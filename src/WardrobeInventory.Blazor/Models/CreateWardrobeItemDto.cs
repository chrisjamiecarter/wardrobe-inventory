using WardrobeInventory.Enums;

namespace WardrobeInventory.Blazor.Models;

public class CreateWardrobeItemDto
{
    public required string Name { get; set; }

    public string? ImagePath { get; set; }

    public WardrobeItemColours? Color { get; set; }

    public WardrobeItemSizes? Size { get; set; }

    public WardrobeItemMaterials? Material { get; set; }
}
