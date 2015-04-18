// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.Product.cs
// Last Modified: 04/18/2015 12:44 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI.Data
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal ShelfPrice { get; set; }
        public decimal TaxRateValue { get; set; }
        public ProductTypeEnum ProductType { get; set; }
    }
}