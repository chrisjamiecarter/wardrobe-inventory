using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using RestSharp;
using WardrobeInventory.Blazor.Extensions;
using WardrobeInventory.Blazor.Models;
using WardrobeInventory.Blazor.Models.Responses;

namespace WardrobeInventory.Blazor.Services;

public class ImageFileService
{
    private static readonly string BaseUrl = "https://localhost:7238/api/imagefiles";
    private static readonly string PostImageFileRoute = @$"{BaseUrl}/";

    public static async Task<ImageFileResponse> PostImageFile(IBrowserFile request)
    {
        var response = new ImageFileResponse();

        try
        {
            using var restClient = new RestClient();

            var restRequest = new RestRequest(PostImageFileRoute);
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            
            using var fileStream = request.OpenReadStream();
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            restRequest.AddFile("file", memoryStream.ToArray(), request.Name, request.ContentType);

            var restResponse = await restClient.ExecuteAsync(restRequest, Method.Post);

            response.IsSuccess = restResponse.IsSuccessStatusCode;

            if (response.IsSuccess)
            {
                response.ImagePath = JsonSerializer.Deserialize<string>(restResponse.Content!, JsonSerializerOptions.Web)!;
            }
            else
            {
                response.Message = restResponse.ErrorMessage ?? "Unknown error has occured";
            }
        }
        catch (Exception exception)
        {
            response.HandleException(exception);
        }

        return response;
    }
}
