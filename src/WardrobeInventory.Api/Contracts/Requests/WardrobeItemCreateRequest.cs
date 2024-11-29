using WardrobeInventory.Enums;

namespace WardrobeInventory.Api.Contracts.Requests;

public record WardrobeItemCreateRequest(string Name, string? ImagePath, WardrobeItemColours? Colour, WardrobeItemMaterials? Material, WardrobeItemSizes? Size);
