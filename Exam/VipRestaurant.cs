using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class VipRestaurant:Restaurant
    {
        public override List<Dish> Showmenu(DateTime time,Menu m ) 
        {
            int i = 1;
            Console.WriteLine("++++++++++++++Vip Restaraunt++++++++++++");
            menu_Now = new List<Dish>();
            List<Dish> gor = m.dishes.FindAll(s => s.Type == "Горячее");
            List<Dish> hol = m.dishes.FindAll(s => s.Type == "Холодное");
            List<Dish> des = m.dishes.FindAll(s => s.Type == "Десерт");
            Console.WriteLine("Горячие блюда");
            foreach(var item in gor)
            {
                Console.WriteLine((i++)+" "+item);
            }
            Console.WriteLine("Холоднst блюда");
            foreach (var item in hol)
            {
                Console.WriteLine((i++) + " " + item);
            }
            Console.WriteLine("Дессерт");
            foreach (var item in des)
            {
                Console.WriteLine((i++) + " " + item);
            }
            menu_Now.AddRange(gor);
            menu_Now.AddRange(hol);
            menu_Now.AddRange(des);
            return menu_Now;
        }

        public override void ChooseDishes()
        {
            List<Dish> order = new List<Dish>();
            visitors = new List<Visitor>();
            int choice = 0;
            Console.WriteLine("Ваше имя");
            string name = Console.ReadLine();
            Console.WriteLine("Выберите блюда");
            while (true)
            {
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 9) break;
                order.Add(menu_Now[choice - 1]);
            }
           
            Console.WriteLine("Ваш заказ:");
            foreach (var item in order)
            {
                Console.WriteLine(item);
            }
            YourSumYoPay(order);
            visitors.Add(new Visitor() { Name = name, Order = order });
        }
    }
}
