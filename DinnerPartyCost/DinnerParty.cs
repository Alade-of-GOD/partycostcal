using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPartyCost
{
    class DinnerParty
    {
        public double CostTotal(double i, double j, int NumberOfPeople, int CostOfFoodPerPerson, int CostOfWaterPerPerson)
        {
            i = NumberOfPeople * CostOfFoodPerPerson;
            j = NumberOfPeople * CostOfWaterPerPerson;
            double Total = i + j;
            return Total;
        }
        
    }
}
