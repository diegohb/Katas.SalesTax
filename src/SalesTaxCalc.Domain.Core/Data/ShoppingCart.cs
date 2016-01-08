// *************************************************
// SalesTaxCalc.Domain.Core.ShoppingCart.cs
// Last Modified: 01/08/2016 2:41 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Services;

    public class ShoppingCart
    {
        private readonly IList<Product> _items;
        private readonly IProvideTaxRateForProduct _taxAssessor;
        private readonly IRoundingStrategy _roundingStrategy;

        #region Constructors

        // TODO: inject these with IoC
        public ShoppingCart(IProvideTaxRateForProduct taxAssessor, IRoundingStrategy roundingStrategy)
        {
            _items = new List<Product>();
            _taxAssessor = taxAssessor;
            _roundingStrategy = roundingStrategy;
        }

        public ShoppingCart(IEnumerable<Product> pItems, IProvideTaxRateForProduct taxAssessor, IRoundingStrategy roundingStrategy)
        {
            _items = pItems.ToList();
            _taxAssessor = taxAssessor;
            _roundingStrategy = roundingStrategy;
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
                let taxAmount =
                    _roundingStrategy.GetRoundedValue
                        (_taxAssessor.GetApplicableTaxRateForProduct(prodGroup.Key.ProductType, prodGroup.Key.IsImported).ActualValue
                         *prodGroup.Key.ShelfPrice)
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
    }
}