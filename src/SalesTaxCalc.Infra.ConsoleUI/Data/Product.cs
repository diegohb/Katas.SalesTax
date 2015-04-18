// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.Product.cs
// Last Modified: 04/18/2015 1:20 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI.Data
{
    public class Product
    {
        public Product(int pProductID, string pName, decimal pShelfPrice)
        {
            ProductID = pProductID;
            Name = pName;
            ShelfPrice = pShelfPrice;
        }

        public int ProductID { get; private set; }
        public string Name { get; private set; }
        public decimal ShelfPrice { get; private set; }
        public decimal TaxRateValue { get; set; }
        public ProductTypeEnum ProductType { get; set; }
    }
}