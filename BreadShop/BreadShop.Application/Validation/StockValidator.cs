using BreadShop.Application.Dtos.Stock;

namespace BreadShop.Application.Validation
{
    /// <summary>
    /// implementation of stock validator.
    /// </summary>
    public class StockValidator
    {
        /// <summary>
        /// validating stock object.
        /// </summary>
        /// <param name="stock">stock object</param>
        /// <returns>isValid</returns>
        public bool IsPostValid(StockDto stock)
        {
            bool isValid = true;

            if (stock.TotalPrice <= 0 || stock.TotalPrice == 0)
            {
                isValid = false;
            }

            if (stock.TotalQuantity <= 0 || stock.TotalQuantity == 0)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
