using System.Drawing;
using WardrobeInventory.Api.Contracts.Requests;
using WardrobeInventory.Api.Contracts.Responses;
using WardrobeInventory.Entities;
using WardrobeInventory.Enums;

namespace WardrobeInventory.Api.Contracts.Mappings;

public static class WardrobeItemMappings
{
    public static WardrobeItem ToDomain(this WardrobeItemCreateRequest request)
    {
        var entity = new WardrobeItem
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Colour = request.Colour,
            Material = request.Material,
            Size = request.Size,
        };

        if (!string.IsNullOrWhiteSpace(request.ImagePath))
        {
            entity.ImagePath = request.ImagePath;
        }

        return entity;
    }

    public static WardrobeItem ApplyUpdate(this WardrobeItem entity, WardrobeItemUpdateRequest request)
    {
        entity.Name = request.Name;
        entity.Colour = request.Colour;
        entity.Material = request.Material;
        entity.Size = request.Size;

        if (!string.IsNullOrWhiteSpace(request.ImagePath))
        {
            entity.ImagePath = request.ImagePath;
        }

        //if (Enum.TryParse<WardrobeItemColours>(request.Colour, out var parsedColour))
        //{
        //    entity.Colour = parsedColour;
        //}

        //if (Enum.TryParse<WardrobeItemMaterials>(request.Material, out var parsedMaterial))
        //{
        //    entity.Material = parsedMaterial;
        //}

        //if (Enum.TryParse<WardrobeItemSizes>(request.Size, out var parsedSize))
        //{
        //    entity.Size = parsedSize;
        //}

        return entity;
    }

    public static WardrobeItemResponse ToResponse(this WardrobeItem entity)
    {
        return new WardrobeItemResponse(entity.Id, entity.Name, entity.ImagePath, entity.Colour, entity.Material, entity.Size);
    }

    public static IReadOnlyList<WardrobeItemResponse> ToReponse(this IReadOnlyList<WardrobeItem> entities)
    {
        return entities.Select(x => x.ToResponse()).ToList();
    }
}
