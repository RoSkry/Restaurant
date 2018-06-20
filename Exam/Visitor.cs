using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{    [Serializable]
    class Visitor
    {
        public string Name { get; set; }
        public List<Dish> Order { get; set; }
        public override string ToString()
        {
            return $"Имя {Name} , Ваш заказ {Order}";
        }
    }

}
