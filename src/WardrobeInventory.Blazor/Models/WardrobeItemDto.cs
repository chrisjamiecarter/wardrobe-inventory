﻿using WardrobeInventory.Enums;

namespace WardrobeInventory.Blazor.Models;

public class WardrobeItemDto
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public string? ImagePath { get; set; }

    public WardrobeItemColours? Colour { get; set; }

    public WardrobeItemMaterials? Material { get; set; }

    public WardrobeItemSizes? Size { get; set; }
}
