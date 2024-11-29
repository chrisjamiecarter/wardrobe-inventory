using WardrobeInventory.Entities;

namespace WardrobeInventory.Blazor.Models.Responses;

public class WardrobeItemsResponse : BaseResponse
{
    public IReadOnlyList<WardrobeItemDto>? WardrobeItems { get; set; }
}
