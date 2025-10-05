using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_OOP
{
    internal class Tovar
    {
        public int Code { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; internal set; }
        public Tovar(int code, string name, decimal price, int quantity)
        {
            Code = code;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public void MinusTovar()
        {
            if (Quantity > 0)
                Quantity -= 1;
        }
        public string ShowInfo()
        {
            return "[" + Code + "]" +Name+ "-" + Price + " Йен. Осталось:" + Quantity + " единиц товара";
        }
    }
}
