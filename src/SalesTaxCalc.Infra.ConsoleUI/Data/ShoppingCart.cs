// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.ShoppingCart.cs
// Last Modified: 04/18/2015 1:41 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI.Data
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        private IList<Product> _items;

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
    }
}