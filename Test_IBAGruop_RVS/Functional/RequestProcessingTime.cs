using System;

namespace Test_IBAGruop_RVS.Functional
{
    public class RequestProcessingTime
    {
       private static DateTime minBorder = new DateTime(2021,10,5,8,0,0);

       private static DateTime maxBorder = new DateTime(2021, 10, 5, 20, 0, 0);
        internal static bool TimeChek()
        {
            var min = minBorder.TimeOfDay;
            var max = maxBorder.TimeOfDay;
            var currentTime = DateTime.Now.TimeOfDay;
            if(currentTime> min && currentTime< max)
            {
                return true;
            }
            else
            {
                return false;
            }          
        }
    }
}
