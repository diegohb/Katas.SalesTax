// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.ShoppingCart.cs
// Last Modified: 04/18/2015 1:46 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI.Data
{
    using System.Collections.Generic;

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

        #endregion

        public void AddItem(Product pProduct, int pQuantity)
        {
            for (var itemCount = 0; itemCount < pQuantity; itemCount++)
                _items.Add(pProduct);
        }
    }
}