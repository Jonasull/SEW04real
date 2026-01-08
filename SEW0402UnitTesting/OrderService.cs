using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEW0402UnitTesting
{
    public class OrderItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsDrink { get; set; } // Unterscheidung für MWSt

        public OrderItem(string name, int quantity, double price, bool isDrink = false)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            IsDrink = isDrink;
        }

    }

    public class OrderService
    {
        // Aufgabe 1: Einfache Summe
        public double CalculateTotal(List<OrderItem> orderItems)
        {
            //return orderItems.Sum(item => item.Price * item.Quantity);
            double total = 0;
            foreach (OrderItem item in orderItems)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

        // Aufgabe 2: 20% MWSt auf alles
        public double CalculateTotalWith20PercentVat(List<OrderItem> orderItems)
        {
            double netTotal = CalculateTotal(orderItems);
            return netTotal * 1.20;
        }

        // Aufgabe 3: Unterschiedliche MWSt (Essen 10%, Getränke 20%)
        public double CalculateTotalWithMultipleVat(List<OrderItem> orderItems)
        {
            double total = 0;
            foreach (OrderItem item in orderItems)
            {
                double subtotal = item.Price * item.Quantity;
                double vatRate = item.IsDrink ? 1.20 : 1.10;
                total += subtotal * vatRate;
            }
            return total;
        }
    }
}
