using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Models
{
    public class CartItemViewModel
    {
        public int Qty { get; set; }

        public Car Car { get; set; }// Containment - the use of a complex data type as a field/ prop in a class 
        //Complex data type -> any class with multiple properties (DateTime, Product, ContactViewModel...)
        //Primitive data type -> a class that stores a single value (int, bool, char, decimal...)

        public CartItemViewModel (int qty, Car car)
        {
            Qty = qty;
            Car = car;
        }       
    }
}
