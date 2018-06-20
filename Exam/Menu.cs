using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{[Serializable]
    class Menu
    {
       public List<Dish> dishes { get; set; }
       string []Time_of_Day = { "Утро", "Обед", "Ужин" };
       public void DeleteDishes(int num)
       {
            dishes.RemoveAt(num);
       }
        public void AddDish(Dish d)
        {
            dishes.Add(d);
        }
        public void Change(int n,double price)
        {
            dishes[n].Price = price; 
        }
        public void SearchName(string name)
        {
            List<Dish> d = dishes.FindAll(s => s.Name ==name);
            Console.WriteLine($"Все блюда  с названием {name} ");
            if (d!=null)
            {
                foreach (var e in d)
                    Console.WriteLine(e);
            }
            else Console.WriteLine("ничего не найдено");
        }
        public void SearchPrice(double price)
        {
            Console.WriteLine($"Все блюда с {price} ценой");
            List<Dish> d = dishes.FindAll(s => s.Price == price);
            if (d != null)
            {
                foreach (var e in d)
                    Console.WriteLine(e);
            }
            else Console.WriteLine("ничего не найдено");
        }
        public void SearchType(string name)
        {
            List<Dish> d = dishes.FindAll(s => s.Type == name);
            if (d != null)
            {
                Console.WriteLine($"Все {name} блюда");
                foreach (var e in d)
                    Console.WriteLine(e);
            }
            else Console.WriteLine("ничего не найдено");
        }
        public  List<Dish> GenerateUtro()
        {
            Random rand = new Random();
            List<Dish> gor = dishes.FindAll(s => s.Type == "Горячее");
            List<Dish> hol = dishes.FindAll(s => s.Type == "Холодное");
            List<Dish> des = dishes.FindAll(s => s.Type == "Десерт");

            Console.WriteLine(Time_of_Day[0]);
            List<Dish> utro = new List<Dish> {
                gor[rand.Next(0,gor.Count)],
                hol[rand.Next(0, hol.Count)],
                des[rand.Next(0, des.Count)]
            };
            return utro;
            
        }
        public List<Dish> GenerateObed()
        {
            Random rand = new Random();
            List<Dish> gor = dishes.FindAll(s => s.Type == "Горячее");
            List<Dish> hol = dishes.FindAll(s => s.Type == "Холодное");
            List<Dish> des = dishes.FindAll(s => s.Type == "Десерт");
             Console.WriteLine(Time_of_Day[1]);
            List<Dish> obed = new List<Dish> {
                gor[rand.Next(0,gor.Count)],
                hol[rand.Next(0, hol.Count)],
                des[rand.Next(0, des.Count)]
            };
            return obed;
        }
        public List<Dish> GenerateUzin()
        {
            Random rand = new Random();
            List<Dish> gor = dishes.FindAll(s => s.Type == "Горячее");
            List<Dish> hol = dishes.FindAll(s => s.Type == "Холодное");
            List<Dish> des = dishes.FindAll(s => s.Type == "Десерт");
            Console.WriteLine(Time_of_Day[2]);
            List<Dish> uzin = new List<Dish> {
                gor[rand.Next(0,gor.Count)],
                hol[rand.Next(0, hol.Count)],
                des[rand.Next(0, des.Count)]
            };
            return uzin;
        }


        public void ToFile()
        {
            BinaryFormatter binform = new BinaryFormatter();
            using (Stream st = File.Create("Exam.bin"))
            {
                binform.Serialize(st, dishes);
            }
        }
        public void FromFile()
        {
            BinaryFormatter binform = new BinaryFormatter();
            List<Dish> d = null;
            using (Stream st = File.OpenRead("Exam.bin"))
            {
                d = (List<Dish>)binform.Deserialize(st);
            }
            foreach(object item in d)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowDishes()
        {
            foreach(var item in dishes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
