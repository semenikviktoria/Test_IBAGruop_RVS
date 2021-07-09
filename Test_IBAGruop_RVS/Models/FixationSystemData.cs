using System;


namespace Test_IBAGruop_RVS.Models
{
    public class FixationSystemData: IComparable<FixationSystemData>
    {
        public DateTime DateTime { get; set; }
        public string CarNumber { get; set; }
        public string TravelSpeed { get; set; }
        public FixationSystemData( DateTime dateTime, string carNumber, string travelSpeed)
        {
            DateTime = dateTime;
            CarNumber = carNumber;
            TravelSpeed = travelSpeed;
        }

        public int CompareTo(FixationSystemData other)
        {

            if (other == null) return 1;

            return TravelSpeed.CompareTo(other.TravelSpeed);
        }

        public static bool operator >(FixationSystemData operand1, FixationSystemData operand2)
        {
            return operand1.CompareTo(operand2) > 0;
        }

        public static bool operator <(FixationSystemData operand1, FixationSystemData operand2)
        {
            return operand1.CompareTo(operand2) < 0;
        }

        public static bool operator >=(FixationSystemData operand1, FixationSystemData operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        public static bool operator <=(FixationSystemData operand1, FixationSystemData operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }
    }
}
