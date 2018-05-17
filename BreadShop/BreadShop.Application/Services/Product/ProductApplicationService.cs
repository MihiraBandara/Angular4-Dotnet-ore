using BreadShop.Application.Dtos.Product;
using BreadShop.Application.Mappers.Product;
using BreadShop.Data.Repositories.Product;
using BreadShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using BreadShop.Application.Validation;

namespace BreadShop.Application.Services.Product
{
    /// <summary>
    /// product application service implements application service logics.
    /// </summary>
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        public ProductApplicationService(IProductRepository _productRepository)
        {
            this._productRepository = _productRepository;
        }

        /// <summary>
        /// saving the product object
        /// </summary>
        /// <param name="productDto">product object that want to save</param>
        /// <returns></returns>
        public Domain.Products.Model.Product SaveProduct(ProductDto productDto)
        {   
            ProductValidator validator = new ProductValidator();
            bool isValid = validator.IsPostValid(productDto);
            ProductMapper modelMapper = new ProductMapper();
            Domain.Products.Model.Product product = modelMapper.ProductEntityFrom(productDto);

            if (!isValid || product == null)
            {
                throw new NullReferenceException();
            }
            Domain.Products.Model.Product result = _productRepository.SaveProduct(product);
            return product;
        }

        /// <summary>
        /// get all products list.
        /// </summary>
        /// <returns></returns>
        public IList<ProductDto> GetProducts()
        {
            IList<Domain.Products.Model.Product> products = _productRepository.GetProducts();
            if (products == null)
            {
                throw new InvalidOperationException();
            }
            ProductMapper modelMapper = new ProductMapper();
            
            IList<ProductDto> productDtoList = new List<ProductDto>();
            foreach (Domain.Products.Model.Product product in products)
            {
                ProductDto productdto = modelMapper.DtoFrom(product);
                productDtoList.Add(productdto);
            }

            return productDtoList;
        }

        /// <summary>
        /// updating product object
        /// </summary>
        /// <param name="productDto">product object that want to update.</param>
        public void UpdateProduct(ProductDto productDto)
        {
            ProductValidator validator = new ProductValidator();
            bool isValid = validator.IsPutValid(productDto);
            ProductMapper modelMapper = new ProductMapper();
            Domain.Products.Model.Product product = modelMapper.ProductEntityFrom(productDto);
            if (!isValid || product == null)
            {
                throw new InvalidOperationException();
            }
            this._productRepository.UpdateProduct(product);
        }

        /// <summary>
        /// get product details by id.
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns></returns>
        public ProductDto GetProductById(int id)
        {
            Domain.Products.Model.Product product = _productRepository.GetProductById(id);

            if (product == null)
            {
                throw new InvalidOperationException();
            }

            ProductMapper modelMapper = new ProductMapper();
            ProductDto projectDto = modelMapper.DtoFrom(product);

            return projectDto;
        }
    }
}
