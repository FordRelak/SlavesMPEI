using Microsoft.AspNetCore.Mvc;

namespace SlavesMPEI.Infrastructure.Extenshions
{
    public static class UrlHelperExtenshions
    {
        public static string GetUrlHelper(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper.Page("/");
            }
            return localUrl;
        }
    }
}