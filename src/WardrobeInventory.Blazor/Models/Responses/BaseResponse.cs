namespace WardrobeInventory.Blazor.Models.Responses;

public class BaseResponse
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public void HandleException(Exception exception)
    {
        IsSuccess = false;

        if (string.IsNullOrWhiteSpace(Message))
        {
            Message = exception.Message;
        }
    }
}
