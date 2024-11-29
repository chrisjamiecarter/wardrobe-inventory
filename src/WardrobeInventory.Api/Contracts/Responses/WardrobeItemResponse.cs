namespace WardrobeInventory.Api.Contracts.Responses;

public record WardrobeItemResponse(Guid Id, string Name, string ImagePath, string Colour, string Size, string Material);
