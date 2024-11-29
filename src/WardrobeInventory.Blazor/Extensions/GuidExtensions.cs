using System.Web;

namespace WardrobeInventory.Blazor.Extensions;

public static class GuidExtensions
{
    public static string UrlEncoded(this Guid value)
    {
        return HttpUtility.UrlEncode(value.ToString());
    }
}
