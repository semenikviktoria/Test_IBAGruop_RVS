
using Test_IBAGruop_RVS.Models;

namespace Test_IBAGruop_RVS.Functional
{
    internal static class DataFiltering
    { 
        internal static bool FilteringBySpeed(FixationSystemData fixation, string minSpeed)
        {
            decimal speedData = decimal.Parse(fixation.TravelSpeed);
            decimal speedTemp = decimal.Parse(minSpeed);

            if (speedData >= speedTemp )
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
