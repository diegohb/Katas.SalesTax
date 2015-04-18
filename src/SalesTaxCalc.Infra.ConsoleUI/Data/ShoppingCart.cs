// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.ShoppingCart.cs
// Last Modified: 04/18/2015 5:03 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI.Data
{
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
                let quantity = prodGroup.Count()
                let shelfPriceTotal = prodGroup.Key.ShelfPrice*quantity
                let taxTotal = roundToNearestOneTwentieth(prodGroup.Key.TaxRateValue*quantity)
                select
                    new ReceiptLineItem(prodGroup.Key.ProductID, prodGroup.Key.Name, quantity, taxTotal, shelfPriceTotal, shelfPriceTotal + taxTotal);
        }

        private decimal roundToNearestOneTwentieth(decimal pValue)
        {
            //TODO: implement rounding
            return pValue;
        }
    }
}