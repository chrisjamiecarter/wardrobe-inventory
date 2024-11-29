using WardrobeInventory.Enums;

namespace WardrobeInventory.Api.Contracts.Responses;

public record WardrobeItemResponse(Guid Id, string Name, string ImagePath, WardrobeItemColours? Colour, WardrobeItemMaterials? Material, WardrobeItemSizes? Size);
