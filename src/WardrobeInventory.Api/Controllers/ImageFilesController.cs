using Microsoft.AspNetCore.Mvc;

namespace WardrobeInventory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageFilesController(IHostEnvironment environment) : ControllerBase
{
    [HttpPost(Name = nameof(PostImageFileAsync))]
    public async Task<IResult> PostImageFileAsync([FromForm] IFormFile file)
    {
        try
        {
            var maximumFileSize = 5 * 1024 * 1024;
            var allowedContentTypes = new List<string> { "image/png", "image/jpg", "image/jpeg" };

            if (!allowedContentTypes.Contains(file.ContentType))
            {
                return TypedResults.BadRequest(new { error = $"Unable to post image file with content type: {file.ContentType}." });
            }

            if (file.Length > maximumFileSize)
            {
                return TypedResults.BadRequest(new { error = $"Unable to post image file with exceeded maximum file size." });
            }

            var trustedFileName = Guid.NewGuid().ToString();

            var serverDirectoryPath = Path.Combine(environment.ContentRootPath, "..\\WardrobeInventory.Blazor\\wwwroot");
            var relativeFilePath = Path.Combine("img", $"{trustedFileName}{Path.GetExtension(file.FileName)}");

            var filePath = Path.GetFullPath(Path.Combine(serverDirectoryPath, relativeFilePath));

            await using FileStream writeStream = new(filePath, FileMode.Create);
            await file.CopyToAsync(writeStream);

            return TypedResults.Ok(relativeFilePath);
        }
        catch (Exception)
        {
            return TypedResults.BadRequest(new { error = "Unable to post image file." });
        }
    }
}
