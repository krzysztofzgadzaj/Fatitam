using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    public class MacroCounter
    {
        public static Meal setContainerValues(List<Meal> meals)
        {
            Meal temp = new Meal { Name = "", Kcal = 0, Fat = 0, Carbs = 0, Proteins = 0 };

            foreach (Meal m in meals)
            {
                temp.Kcal += m.Kcal;
                temp.Proteins += m.Proteins;
                temp.Carbs += m.Carbs;
                temp.Fat += m.Fat;
            }

            return temp;
        }
    }
}
