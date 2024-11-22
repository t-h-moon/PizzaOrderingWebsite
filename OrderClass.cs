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
    public class OrderClass
    {
        DBConnect dBConnect = new DBConnect();
        public ArrayList arrPizzaOrder = new ArrayList();
        public int totalQty;//per pizza type: qty
        public decimal totalPrice;//per pizza type: qty  x size, price

        public OrderClass()
        { 

        }

        //Pizza type: BasePrice (from the database) x Size
        public decimal calPriceBySize(string pizzatype, string pizzaSize)
        {
            decimal price = 0.0m;
            decimal basePrice = getBasePrice(pizzatype);

            if (pizzaSize.Equals("Small"))
            {
                price = basePrice;
            }
            else if (pizzaSize.Equals("Medium"))
            {
                price = basePrice + 2;
            }
            else {
                price = basePrice + 5;
            }
            return price;
        }

        //Update to the database: TotalSales and TotalQuantityOrdered 
        public void updateSalesAndQty(string pizzaType, int totalQty, decimal totalSales) 
        {
            String sqlUpdate= "UPDATE Pizza SET TotalQuantityOrdered = TotalQuantityOrdered + " + totalQty + ", TotalSales = TotalSales + " + totalSales + "WHERE PizzaType = '" + pizzaType + "'";
            dBConnect.DoUpdate(sqlUpdate);
        }

        //Get base price of the pizza that was selected from database
        public decimal getBasePrice(string pizzaType)
        {
            decimal basePrice = 0.0m;
            String sqlBasePrice = "SELECT BasePrice FROM Pizza WHERE PizzaType = '" + pizzaType + "'";
            basePrice = decimal.Parse(dBConnect.GetDataSet(sqlBasePrice).Tables[0].Rows[0]["BasePrice"].ToString());
            return basePrice;
        }

        //Returns the TotalQuantityOrdered value from the database per pizza type
        public string getTotalQuantityOrdered()
        {
            String sqlQty = "SELECT PizzaType, TotalQuantityOrdered FROM Pizza ORDER BY TotalQuantityOrdered DESC";
            return sqlQty;
        }

        //Returns the TotalSales value from the database per pizza type
        public string getTotalSales()
        {
            String sqlTotalSales = "SELECT PizzaType, TotalSales FROM Pizza ORDER BY TotalSales DESC";
            return sqlTotalSales;
        }
    }
}
