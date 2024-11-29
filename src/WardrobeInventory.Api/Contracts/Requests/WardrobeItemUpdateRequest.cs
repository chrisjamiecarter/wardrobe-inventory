namespace WardrobeInventory.Api.Contracts.Requests;

public record WardrobeItemUpdateRequest(string Name, string ImagePath, string Colour, string Material, string Size);
