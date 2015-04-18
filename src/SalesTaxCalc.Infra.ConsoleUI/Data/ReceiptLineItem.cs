// *************************************************
// SalesTaxCalc.Infra.ConsoleUI.ReceiptLineItem.cs
// Last Modified: 04/18/2015 5:03 PM
// Modified By: Bustamante, Diego (bustamd1)
// *************************************************

namespace SalesTaxCalc.Infra.ConsoleUI.Data
{
    using System.Collections.Generic;
    using System.Text;

    public class ReceiptLineItem
    {
        private readonly int _productID;
        private readonly string _name;
        private readonly int _quantity;
        private readonly decimal _taxTotal;
        private readonly decimal _shelfPriceTotal;
        private readonly decimal _subTotal;

        public ReceiptLineItem(int pProductID, string pName, int pQuantity, decimal pTaxTotal, decimal pShelfPriceTotal, decimal pSubTotal)
        {
            _productID = pProductID;
            _name = pName;
            _quantity = pQuantity;
            _taxTotal = pTaxTotal;
            _shelfPriceTotal = pShelfPriceTotal;
            _subTotal = pSubTotal;
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

        public decimal ShelfPriceTotal
        {
            get { return _shelfPriceTotal; }
        }

        public decimal SubTotal
        {
            get { return _subTotal; }
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
            builder.Append(", ShelfPriceTotal = ");
            builder.Append(ShelfPriceTotal);
            builder.Append(", SubTotal = ");
            builder.Append(SubTotal);
            builder.Append(" }");
            return builder.ToString();
        }

        public override bool Equals(object value)
        {
            var type = value as ReceiptLineItem;
            return (type != null) && EqualityComparer<int>.Default.Equals(type.ProductID, ProductID)
                   && EqualityComparer<string>.Default.Equals(type.Name, Name) && EqualityComparer<int>.Default.Equals(type.Quantity, Quantity)
                   && EqualityComparer<decimal>.Default.Equals(type.TaxTotal, TaxTotal)
                   && EqualityComparer<decimal>.Default.Equals(type.ShelfPriceTotal, ShelfPriceTotal)
                   && EqualityComparer<decimal>.Default.Equals(type.SubTotal, SubTotal);
        }

        public override int GetHashCode()
        {
            int num = 0x7a2f0b42;
            num = (-1521134295*num) + EqualityComparer<int>.Default.GetHashCode(ProductID);
            num = (-1521134295*num) + EqualityComparer<string>.Default.GetHashCode(Name);
            num = (-1521134295*num) + EqualityComparer<int>.Default.GetHashCode(Quantity);
            num = (-1521134295*num) + EqualityComparer<decimal>.Default.GetHashCode(TaxTotal);
            num = (-1521134295*num) + EqualityComparer<decimal>.Default.GetHashCode(ShelfPriceTotal);
            return (-1521134295*num) + EqualityComparer<decimal>.Default.GetHashCode(SubTotal);
        }
    }
}