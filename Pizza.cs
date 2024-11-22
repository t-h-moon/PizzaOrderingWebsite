using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PizzaLibrary;
using Utilities;
using System.Data;
using System.Collections;



namespace PizzaLibrary
{
    public class Pizza
    {
        private string PizzaType;
        private string Size;
        private int Quantity;
        private decimal Price;
        private decimal TotalCost;

        public Pizza()
        {

        }

        ArrayList pizzaOrder = new ArrayList ();

        public String pizzaType
        {
            get { return PizzaType; }
            set { PizzaType = value; }
        }

        public String size
        {
            get { return Size; }
            set { Size = value; }
        }

        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public decimal price
        {
            get { return Price; }
            set { Price = value; }
        }

        public decimal totalCost
        {
            get { return TotalCost; }
            set { TotalCost = value; }
        }

















    }
}
