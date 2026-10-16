using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Classes
{
    public class Product : IComparable<Product>
    {
        private string type;
        private double price;
        private string grade;
        private int amount;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Price
        {
            get { return price; }
            set { 
                if (value >= 0) price = value; 
                else throw new ArgumentException("Price cannot be negative.");
            }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public int Amount
        {
            get { return amount; }
            set {
                if (value >= 0) amount = value;
                else throw new ArgumentException("Price cannot be negative.");
            }
        }

        public Product()
        {
            type = "Unknown";
            price = 0.0;
            grade = "Unknown";
            amount = 0;
        }

        public Product(string type, double price, string grade, int amount)
        {
            Type = type;
            Price = price;
            Grade = grade;
            Amount   = amount;
        }

        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.amount.CompareTo(other.amount);
        }

        public override string ToString()
        {
            return $"Type: {type}, Price: {price}, Grade: {grade}, Amount: {amount}";
        }
    }
}
