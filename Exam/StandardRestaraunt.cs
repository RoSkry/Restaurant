using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class StandardRestaraunt:Restaurant
    {
        public override List<Dish> Showmenu(DateTime time, Menu m)
        {
            Console.WriteLine("+++++++++++++++++++Standart Restaraunt++++++++++++++++++++++");
            return base.Showmenu(time, m);
        }
        public override void ChooseDishes()
        {
            base.ChooseDishes();
        }
    }
}
