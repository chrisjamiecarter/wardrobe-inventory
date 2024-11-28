using WardrobeInventory.Enums;

namespace WardrobeInventory.Entities;

public class WardrobeItem
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public string ImagePath { get; set; } = "/img/B5FCD8C6-66E8-4F42-97C8-B6921C8DEC30.png";

    public WardrobeItemColours? Color { get; set; }

    public WardrobeItemSizes? Size { get; set; }

    public WardrobeItemMaterials? Material { get; set; }
}
