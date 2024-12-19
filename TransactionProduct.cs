using System;

namespace BrewBreeze
{
    public class TransactionProduct
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Addon { get; set; }
    }
}
