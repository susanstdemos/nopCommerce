using System;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Domains;
using Nop.Services.Caching;

namespace Nop.Plugin.MultiFactorAuth.GoogleAuthenticator.Services
{
    /// <summary>
    /// Represents Google Authenticator service
    /// </summary>
    public class GoogleAuthenticatorService
    {
        #region Fields

        private readonly ICacheKeyService _cacheKeyService;
        private readonly IRepository<GoogleAuthenticatorRecord> _repository;
        private readonly IStaticCacheManager _staticCacheManager;

        #endregion

        #region Ctr

        public GoogleAuthenticatorService(ICacheKeyService cacheKeyService,
            IRepository<GoogleAuthenticatorRecord> repository,
            IStaticCacheManager staticCacheManager)
        {
            _cacheKeyService = cacheKeyService;
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
        public IPagedList<GoogleAuthenticatorRecord> GetPagedConfigurations(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _repository.Table;
            query = query.OrderBy(configuration => configuration.Id);

            return new PagedList<GoogleAuthenticatorRecord>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// Get a configuration by the identifier
        /// </summary>
        /// <param name="configurationId">Configuration identifier</param>
        /// <returns>Configuration</returns>
        public GoogleAuthenticatorRecord GetConfigurationById(int configurationId)
        {
            if (configurationId == 0)
                return null;

            return _staticCacheManager.Get(_cacheKeyService.PrepareKeyForDefaultCache(GoogleAuthenticatorDefaults.ConfigurationCacheKey, configurationId), () =>
                _repository.GetById(configurationId));
        }

        /// <summary>
        /// Insert the configuration
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public void InsertConfiguration(GoogleAuthenticatorRecord configuration)
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
        public void UpdateConfiguration(GoogleAuthenticatorRecord configuration)
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
        public void DeleteConfiguration(GoogleAuthenticatorRecord configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _repository.Delete(configuration);
            _staticCacheManager.RemoveByPrefix(GoogleAuthenticatorDefaults.PrefixCacheKey);
        }

        #endregion
    }
}
