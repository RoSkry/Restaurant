using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class SnackBar:Restaurant
    {
        public override List<Dish> Showmenu(DateTime time, Menu m)
        {
            Console.WriteLine("+++++++++++++++++++++Snack Bar++++++++++++++++++++++");
           menu_Now=m.GenerateObed();
            return menu_Now;
        }
        public override void ChooseDishes()
        {
            base.ChooseDishes();
        }
    }
}
