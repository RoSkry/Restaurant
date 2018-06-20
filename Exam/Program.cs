using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Dish d = new Dish { Name = "Borsh", Price = 24.34, Type = "Горячее" };
            try
            {
                Console.WriteLine("Информация про блюдо");
                Console.WriteLine(d);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Стоимость блюда после добавления");
                d += 5;
                Console.WriteLine(d);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Стоимость блюда после вычетания");
                d -= 10;
                Console.WriteLine(d);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Явное приведение");
                Console.WriteLine((double)d);

                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                 
                Console.WriteLine();

                List<Dish> dishess = new List<Dish>
                {
                    new Dish {Name="Суп",Price=10.25,Type="Горячее" },
                    new Dish {Name="Мороженое",Price=15.00,Type="Десерт" },
                    new Dish {Name="Салат",Price=12,Type="Холодное" },
                    new Dish {Name="Борщ",Price=16.05,Type="Горячее" },
                    new Dish {Name="Рассольник",Price=14.43,Type="Горячее" },
                    new Dish {Name="Пироженое",Price=11.34,Type="Десерт" },
                    new Dish {Name="Торт",Price=12.56,Type="Десерт" },
                    new Dish {Name="Спагетти",Price=12.83,Type="Холодное" },
                    new Dish {Name="Свинина",Price=15.25,Type="Холодное" },


                };
                Menu menu = new Menu { dishes = dishess };
                Console.WriteLine("Выводим все блюда");
                Console.WriteLine();
                menu.ShowDishes();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Удаляем четвертое блюдо, третье в листе и выводим измененый список");
                menu.DeleteDishes(3);
                menu.ShowDishes();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Добавляем новое блюда, и выводим результат");
                menu.AddDish(d);
                menu.ShowDishes();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Изменяем цену у салата и выводим");
                menu.Change(2, 34);
                menu.ShowDishes();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Ищем по названию");
                menu.SearchName("Салат");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Ищем по типу");
                menu.SearchType("Горячее");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Ищем по цене");
                menu.SearchPrice(10.25);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Генерируем меню на утро");
            List<Dish> breakfast = menu.GenerateUtro();
               foreach (object item in breakfast)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Генерируем меню на обед");
                List<Dish> supper = menu.GenerateObed();
                foreach (object item in supper)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Генерируем меню на ужин");
                List<Dish> evening= menu.GenerateUzin();
                foreach (object item in evening)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Запись и чтение из файла");
                menu.ToFile();
                menu.FromFile();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("+++++++++++++++++++Ресторан++++++++++++++++");

                Restaurant res = new Restaurant();
                Console.WriteLine("Выводим меню на данное время");
                Console.WriteLine();
                res.Showmenu(DateTime.Now,menu);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Делаем заказ и записываем его в файл");
                res.ChooseDishes();
                res.OrderToFile();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");


                List<Dish> first = new List<Dish> {
                    new Dish {Name="Суп",Price=10.25,Type="Горячее" },
                    new Dish {Name="Мороженое",Price=15.00,Type="Десерт" },
                };
                List<Dish> second = new List<Dish> {
                       new Dish {Name="Борщ",Price=16.05,Type="Горячее" },
                    new Dish {Name="Рассольник",Price=14.43,Type="Горячее" },
                    new Dish {Name="Пироженое",Price=11.34,Type="Десерт" },
                };
                List<Dish> third = new List<Dish> {
                    new Dish {Name="Мороженое",Price=15.00,Type="Десерт" },
                    new Dish {Name="Салат",Price=12,Type="Холодное" },
                };

                List<Visitor> visitors = new List<Visitor>
                {
                   new Visitor() {Name="Ivan",Order=first},
                   new Visitor() {Name="Fedor",Order=second},
                   new Visitor() {Name="Kiril",Order=third }
                };
                Console.WriteLine("Выводим все заказы на данный момент");
                res.Report_Orders(visitors);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Выводим весь доход");
                res.AllIncome();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                //Console.WriteLine("++++++++++++++++++Vip+++++++++++++++++");
                //Restaurant vip = new VipRestaurant();
                //vip.Showmenu(DateTime.Now, menu);
                //vip.ChooseDishes();
                //Console.WriteLine("++++++++++++++Standart+++++++++++++++++++");
                //Restaurant standard = new StandardRestaraunt();
                //standard.Showmenu(DateTime.Now, menu);
                //standard.ChooseDishes();
                //Console.WriteLine("+++++++Snack Bar +++++++++++++++++++++");
                //Restaurant snack = new SnackBar();
                //snack.Showmenu(DateTime.Now, menu);
                //snack.ChooseDishes();
                List<Restaurant> restaurants = new List<Restaurant>()
                {
                  new VipRestaurant(),
                  new StandardRestaraunt(),
                  new SnackBar()
                };
                foreach(var item in restaurants )
                {
                    item.Showmenu(DateTime.Now, menu);
                    item.ChooseDishes();
                }
            }
           catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
