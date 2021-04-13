using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_collection
{
    class PopulationFormatter
    {
        public static string FormatPopulation(int poputlation)
        {
            if (poputlation == 0)
                return "(Unknown)";

            int popRounded = RoundPopulation4(poputlation);

            return $"{popRounded:### ### ### ###}".Trim();
        }

        // Round the population to 4 significant figures
        private static int RoundPopulation4(int poputlation)
        {
            int accuracy = (int)Math.Max((int)GetHigestPowerofTen(poputlation) / 10_000L, 1);

            return RoundToNearest(poputlation, accuracy);
        }

        private static int RoundToNearest(int poputlation, int accuracy)
        {
            throw new NotImplementedException();
        }

        private static int GetHigestPowerofTen(int poputlation)
        {
            throw new NotImplementedException();
        }
    }
}
