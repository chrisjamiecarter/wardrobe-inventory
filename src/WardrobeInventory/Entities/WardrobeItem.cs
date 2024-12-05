using WardrobeInventory.Enums;

namespace WardrobeInventory.Entities;

public class WardrobeItem : BaseEntity
{
    public required string Name { get; set; }

    public string ImagePath { get; set; } = "/img/B5FCD8C6-66E8-4F42-97C8-B6921C8DEC30.png";

    public WardrobeItemColours? Colour { get; set; }

    public WardrobeItemMaterials? Material { get; set; }

    public WardrobeItemSizes? Size { get; set; }
}
