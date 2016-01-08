﻿// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.Product.cs
// Last Modified: 04/18/2015 5:32 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Data
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
        public bool IsImported { get; set; }
        public ProductCategoryEnum ProductType { get; set; }

        public string GetNameWithPrice()
        {
            return string.Format("{0} @ {1:C2}", Name, ShelfPrice);
        }

        public override string ToString()
        {
            return string.Format
                ("ProductID: {0}, Name: {1}, ShelfPrice: {2}, ProductType: {3}", ProductID, Name, ShelfPrice, ProductType);
        }
    }
}