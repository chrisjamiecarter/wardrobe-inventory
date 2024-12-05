using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Entities;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Repositories;

public class WardrobeItemRepository(WardrobeInventoryDbContext context) : GenericRepository<WardrobeItem>(context), IWardrobeItemRepository
{
}
