using BreadShop.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Domain.Products.Model;

namespace BreadShop.Application.Mappers.Product
{
    /// <summary>
    /// mapping product object.
    /// </summary>
    public class ProductMapper : IModelMapper<ProductDto, Domain.Products.Model.Product>
    {
        /// <summary>
        /// mapping product type object to productdto type object.
        /// </summary>
        /// <param name="domainEntity">product type object</param>
        /// <returns>productdto type object</returns>
        public ProductDto DtoFrom(Domain.Products.Model.Product domainEntity)
        {
            return new ProductDto()
            {
                ProductId = domainEntity.ProductId,
                ProductName = domainEntity.ProductName,
                Ingrediants = domainEntity.Ingrediants,
                Descriptions = domainEntity.Descriptions,
                Quantity = domainEntity.Quantity,
                CreatedOn = domainEntity.CreatedOn,
                UpdatedOn = domainEntity.UpdatedOn
            };
        }

        public Domain.Products.Model.Product EntityFrom(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// mapping productdto object to product object
        /// </summary>
        /// <param name="dto">productdto type object</param>
        /// <returns>product type object</returns>
        public Domain.Products.Model.Product ProductEntityFrom(ProductDto dto)
        {
            return new Domain.Products.Model.Product()
            {
                ProductId = dto.ProductId,
                ProductName = dto.ProductName, 
                Ingrediants = dto.Ingrediants,
                Descriptions = dto.Descriptions,
                Quantity = dto.Quantity,
                CreatedOn = dto.CreatedOn,
                UpdatedOn = dto.UpdatedOn
            };
        }
    }
}
