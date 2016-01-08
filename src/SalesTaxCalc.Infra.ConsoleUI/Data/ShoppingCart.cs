// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.ShoppingCart.cs
// Last Modified: 04/18/2015 5:15 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart
    {
        private readonly IList<Product> _items;

        #region Constructors

        public ShoppingCart()
        {
            _items = new List<Product>();
        }

        public ShoppingCart(IEnumerable<Product> pItems)
        {
            _items = new List<Product>(pItems);
        }

        public List<Product> Items
        {
            get { return (List<Product>) _items; }
        }

        #endregion

        public void AddItem(Product pProduct, int pQuantity)
        {
            for (var itemCount = 0; itemCount < pQuantity; itemCount++)
                _items.Add(pProduct);
        }

        public IEnumerable<ReceiptLineItem> GetLineItems()
        {
            return from item in _items
                group item.ProductID by item
                into prodGroup
                let taxAmount = roundToNearestOneTwentieth(prodGroup.Key.TaxRateValue*prodGroup.Key.ShelfPrice)
                let quantity = prodGroup.Count()
                let shelfPriceWithTax = prodGroup.Key.ShelfPrice + taxAmount
                let shelfPriceTotal = prodGroup.Key.ShelfPrice*quantity
                let taxTotal = taxAmount*quantity
                select
                    new ReceiptLineItem
                        (prodGroup.Key.ProductID, prodGroup.Key.Name, quantity, taxTotal,
                            shelfPriceWithTax, shelfPriceTotal, shelfPriceWithTax*quantity);
        }

        public decimal GetTotalSalesTax()
        {
            return GetLineItems().Sum(pLine => pLine.TaxTotal);
        }

        public decimal GetGrandTotal()
        {
            return GetLineItems().Sum(pLine => pLine.Total);
        }

        private decimal roundToNearestOneTwentieth(decimal pValue)
        {
            //ref: http://stackoverflow.com/a/1448465/1240322
            return Math.Ceiling(pValue*20)/20;
        }
    }
}