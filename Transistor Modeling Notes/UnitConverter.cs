using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_Modeling_Notes
{
    /*
        The unit size in formulas for transisters is meters,
        Therefore, a converter needs to exist. 
     */
    public enum Units { meter, decimeter, centimeter, millimeter, nanometer, micrometer, picometer, femtometer}
    public enum Prefix {giga, mega, kilo, hecto, deka, standard, 
        deci, centi, milli, nano, micro, pico, femto, atto, zepto, yocto}

    public static class UnitConverter
    {
        public static double micrometer = Math.Pow(10,-6);

        static Dictionary <Units, double> relation = new Dictionary <Units, double>()
            //Contains a unit's scientific notation relation to the standard unit (meters) 
        {
            {Units.meter, 0},
            {Units.decimeter, -1},
            {Units.centimeter, -2},
            {Units.millimeter, -3},
            {Units.micrometer, -6},
            {Units.nanometer, -9},
            {Units.picometer, -12},
            {Units.femtometer, -15}
        };

        static Dictionary<int, Prefix> prefixes = new Dictionary<int, Prefix>()
            //Contains a unit's scientific notation relation to the standard unit (meters) 
        {
            {3, Prefix.kilo}, 
            {6, Prefix.mega},
            {9, Prefix.giga},
            {0, Prefix.standard},
            {-3, Prefix.milli},
            {-6, Prefix.micro},
            {-9, Prefix.nano},
            {-12, Prefix.pico}
        };


        public static double ConvertToStandardUnits(Units unit, double num)
        {
            //Returns a measured number in standard units : i.e. 4cm = 0.04 
            return num* Math.Pow(10, relation[unit]);
        }

        public static (double, Prefix) ConvertFromStandard(double num)
        //This function assumes a positive number greater than 1
        {
            //edge cases
            if (num == 0 || num < 0)
                return (num, Prefix.standard);

            //finds the max decimal place for number. Then because the standard
            // is to use multiples of 3s, make use of the modulo
            int decimalplace = (int)Math.Round(Math.Log10(num), 0, MidpointRounding.AwayFromZero);
            decimalplace = decimalplace - (decimalplace % 3);

            //divide by decimal place and tag it
            double newNum = num / Math.Pow(10, decimalplace);
            Prefix ret = prefixes[decimalplace];
            return (newNum, ret);
        }
    }
}
