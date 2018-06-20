using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    [Serializable]
    class Restaurant
    {
        public List<Visitor> visitors;
        public List<Dish> menu_Now { get; set; }
        public virtual List<Dish> Showmenu(DateTime time, Menu m)
        {
            menu_Now = new List<Dish>();
            if (time.Hour < 10 && time.Hour > 5)
            {
                menu_Now = m.GenerateUtro();

            }
            else if (time.Hour > 10 && time.Hour < 16)
            {
                menu_Now = m.GenerateObed();
            }
            else
            {
                menu_Now = m.GenerateUzin();
                Console.WriteLine();

            }
            foreach (var item in menu_Now)
            {
                Console.WriteLine(item);
            }
            return menu_Now;
        }

        public virtual void ChooseDishes()
        {
           List<Dish>  order = new List<Dish>();
            visitors = new List<Visitor>();
            int i =1;
            Console.WriteLine("Ваше имя");
            string name = Console.ReadLine();
            Console.WriteLine("Choose your dishes");
            foreach (var item in menu_Now)
            {
                Console.WriteLine((i++) + " " + item);
            }
            int choice = 0;
            while (true)
            {
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 3) break;
                order.Add(menu_Now[choice-1]);
            }
            Console.WriteLine("Ваш заказ:"); 
             foreach(var item in order)
            {
                Console.WriteLine(item);
            }
            YourSumYoPay(order);
            visitors.Add(new Visitor() { Name = name, Order = order });
                     
        }

        public void OrderToFile()
        {
            BinaryFormatter binform = new BinaryFormatter();
            using (Stream st = File.Create("Order.bin"))
            {
                binform.Serialize(st, visitors);
            }
        }

        public void YourSumYoPay(List<Dish> ord)
        {
            double sum = 0;
            foreach (var item in ord)
            {
               sum+=item.Price;
            }
            Console.WriteLine("Вас счет "+sum);
        }

        public void Report_Orders (List<Visitor> v)
        {
            for (int i = 0; i < v.Count; i++)
                visitors.Add(v[i]);


            Console.WriteLine($"Все заказы на {DateTime.Now.Hour}:{DateTime.Now.Minute}");
               foreach(var item in visitors)
            {
                Console.WriteLine($"Имя {item.Name}:");
                foreach( var i in item.Order)
                {
                    Console.WriteLine(i);
                }
               
            }
        }

        public void AllIncome()
        {
            double sum = 0;
            foreach (var item in visitors)
            {
             
                foreach (var i in item.Order)
                {
                    sum += i.Price;
                }

            }
            Console.WriteLine($"Доход составляет {sum}");

        }
    }
}
