namespace WardrobeInventory.Api.Contracts.Requests;

public record WardrobeItemCreateRequest(string Name, string ImagePath, string Colour, string Material, string Size);
