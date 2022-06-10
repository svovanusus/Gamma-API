using Gamma.Data.Entities;
using Gamma.Logic.Models;
using Gamma.Logic.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gamma.Logic.Services.Impl
{
    internal class SitesServiceImpl : ISitesService
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IUserRepository _userRepository;

        public SitesServiceImpl(ISiteRepository siteRepository, IUserRepository userRepository)
        {
            _siteRepository = siteRepository;
            _userRepository = userRepository;
        }

        public async Task<SiteListItemModel[]> GetUserSites(long userId)
        {
            return await _siteRepository.GetAllForUser(userId).Select(x => new SiteListItemModel
            {
                SiteId = x.SiteId,
                Name = x.Name,
                PagesCount = x.Pages.Count,
            }).ToArrayAsync();
        }

        public async Task<CreateSiteRequestModel?> GetSite(long siteId, long userId)
        {
            var site = await _siteRepository.GetById(siteId);
            if (site == null || site.Owner.UserId != userId) return null;

            return new CreateSiteRequestModel
            {
                Name = site.Name,
                DomainId = site.Domain.DomainId,
                DomainName = site.Domain.Name,
            };
        }

        public async Task<SiteListItemModel> CreateSite(CreateSiteRequestModel model, long userId)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null) return null!;

            var newSite = await _siteRepository.Save(new Site
            {
                Name = model.Name,
                Owner = user,
                Pages = new List<SitePage>(),
            });

            await _siteRepository.CommitChangesAsync();

            return new SiteListItemModel
            {
                SiteId = newSite.SiteId,
                Name = newSite.Name,
                PagesCount = newSite.Pages.Count
            };
        }
    }
}
