using System;
using System.Collections.Generic;
using System.Text;

namespace BreadShop.Application.Mappers
{
    /// <summary>
    /// Application model DTO / domain model entity mapper.
    /// </summary>
    public interface IModelMapper<TDto, TEntity>
    {
        /// <summary>
        /// Application model DTO mapped from
        /// specified domain model entity.
        /// </summary>
        /// <param name="domainEntity">
        /// The domain model entity to map from.
        /// Must not be null.
        /// </param>
        /// <returns>
        /// The DTO mapped from <paramref name="domainEntity"/>.
        /// </returns>
        TDto DtoFrom(TEntity domainEntity);

        /// <summary>
        /// Domain model entity mapped from
        /// specified application model DTO.
        /// </summary>
        /// <param name="dto">
        /// The application model DTO to map from.
        /// Must not be null.
        /// </param>
        /// <returns>
        /// The domain model entity mapped from <paramref name="dto"/>.
        /// </returns>
        TEntity EntityFrom(TDto dto);
    }
}
