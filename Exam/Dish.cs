using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{[Serializable]
    class Dish
    {
        public string Name {get;set;}
        public double Price { get; set; }
        public string Type { get; set; }
        public static Dish operator+(Dish d,double pr)
        {
            d.Price += pr;
            return d;
        }
        public static Dish operator -(Dish d, double pr)
        {
             if (d.Price < pr) throw new Exception("Цена отрицательная");

            d.Price -= pr;
              return d;
          
        }
        public static explicit operator double(Dish d)
        {
            return (double)d.Price;
        }

        public override string ToString()
        {
            return $"Имя: {Name} Цена: {Price} Тип: {Type}";
        }
    }
}
