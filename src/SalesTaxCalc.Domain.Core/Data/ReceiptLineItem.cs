// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.ReceiptLineItem.cs
// Last Modified: 04/18/2015 5:15 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Domain.Core.Data
{
    using System;
    using System.Text;

    public class ReceiptLineItem : IEquatable<ReceiptLineItem>
    {
        private readonly int _productID;
        private readonly string _name;
        private readonly int _quantity;
        private readonly decimal _taxTotal;
        private readonly decimal _shelfPriceTotal;
        private readonly decimal _total;
        private readonly decimal _shelfPrice;

        public ReceiptLineItem
            (int pProductID, string pName, int pQuantity, decimal pTaxTotal, decimal pShelfPrice, decimal pShelfPriceTotal, decimal pTotal)
        {
            _productID = pProductID;
            _name = pName;
            _quantity = pQuantity;
            _taxTotal = pTaxTotal;
            _shelfPriceTotal = pShelfPriceTotal;
            _total = pTotal;
            _shelfPrice = pShelfPrice;
        }

        public int ProductID
        {
            get { return _productID; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public decimal TaxTotal
        {
            get { return _taxTotal; }
        }

        public decimal ShelfPrice
        {
            get { return _shelfPrice; }
        }

        public decimal ShelfPriceTotal
        {
            get { return _shelfPriceTotal; }
        }

        public decimal Total
        {
            get { return _total; }
        }

        public string PrintableMessage
        {
            get
            {
                return Quantity > 1
                    ? string.Format("{0}: {1:0.00} ({2} @ {3})", Name, Total, Quantity, ShelfPrice)
                    : string.Format("{0}: {1:0.00}", Name, Total);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ ProductID = ");
            builder.Append(ProductID);
            builder.Append(", Name = ");
            builder.Append(Name);
            builder.Append(", Quantity = ");
            builder.Append(Quantity);
            builder.Append(", TaxTotal = ");
            builder.Append(TaxTotal);
            builder.Append(", ShelfPrice = ");
            builder.Append(ShelfPrice);
            builder.Append(", ShelfPriceTotal = ");
            builder.Append(ShelfPriceTotal);
            builder.Append(", Total = ");
            builder.Append(Total);
            builder.Append(" }");
            return builder.ToString();
        }

        #region Equality

        public bool Equals(ReceiptLineItem pOther)
        {
            if (ReferenceEquals(null, pOther)) return false;
            if (ReferenceEquals(this, pOther)) return true;
            return _productID == pOther._productID && string.Equals(_name, pOther._name) && _quantity == pOther._quantity
                   && _taxTotal == pOther._taxTotal
                   && _shelfPriceTotal == pOther._shelfPriceTotal && _total == pOther._total && _shelfPrice == pOther._shelfPrice;
        }

        public override bool Equals(object pObject)
        {
            if (ReferenceEquals(null, pObject)) return false;
            if (ReferenceEquals(this, pObject)) return true;
            if (pObject.GetType() != this.GetType()) return false;
            return Equals((ReceiptLineItem) pObject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _productID;
                hashCode = (hashCode*397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _quantity;
                hashCode = (hashCode*397) ^ _taxTotal.GetHashCode();
                hashCode = (hashCode*397) ^ _shelfPriceTotal.GetHashCode();
                hashCode = (hashCode*397) ^ _total.GetHashCode();
                hashCode = (hashCode*397) ^ _shelfPrice.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}