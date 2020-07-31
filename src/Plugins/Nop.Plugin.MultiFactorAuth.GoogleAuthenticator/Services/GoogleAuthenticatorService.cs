using System;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Domains;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Services
{
    /// <summary>
    /// Represents Google Authenticator service
    /// </summary>
    public class GoogleAuthenticatorService
    {
        #region Fields

        private readonly IRepository<GoogleAuthenticatorConfiguration> _repository;
        private readonly IStaticCacheManager _staticCacheManager;

        #endregion

        #region Ctr

        public GoogleAuthenticatorService(IRepository<GoogleAuthenticatorConfiguration> repository,
            IStaticCacheManager staticCacheManager)
        {
            _repository = repository;
            _staticCacheManager = staticCacheManager;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get configurations
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paged list of configurations</returns>
        public IPagedList<GoogleAuthenticatorConfiguration> GetPagedConfigurations(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _repository.Table;
            query = query.OrderBy(configuration => configuration.Id);

            return new PagedList<GoogleAuthenticatorConfiguration>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// Insert the configuration
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public void InsertConfiguration(GoogleAuthenticatorConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _repository.Insert(configuration);
            _staticCacheManager.RemoveByPrefix(GoogleAuthenticatorDefaults.PrefixCacheKey);
        }

        /// <summary>
        /// Update the configuration
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public void UpdateConfiguration(GoogleAuthenticatorConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _repository.Update(configuration);
            _staticCacheManager.RemoveByPrefix(GoogleAuthenticatorDefaults.PrefixCacheKey);
        }

        /// <summary>
        /// Delete the configuration
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public void DeleteConfiguration(GoogleAuthenticatorConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _repository.Delete(configuration);
            _staticCacheManager.RemoveByPrefix(GoogleAuthenticatorDefaults.PrefixCacheKey);
        }

        #endregion
    }
}
