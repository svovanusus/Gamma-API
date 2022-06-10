using Gamma.Logic.Models;

namespace Gamma.Logic.Services
{
    public interface ISitesService
    {
        Task<SiteListItemModel[]> GetUserSites(long userId);
        Task<SiteListItemModel> CreateSite(CreateSiteRequestModel model, long userId);
        Task<CreateSiteRequestModel?> GetSite(long siteId, long userId);
    }
}
