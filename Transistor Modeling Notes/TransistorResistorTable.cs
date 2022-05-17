using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    W/L ratio determines the size of a transistor
       
    Most of the time L is constant for all transistors, so W determines the size.
    
    R is reverse proportional with W (size) and I is proportional with W (size)

    Large transistors means more current and less Resistance

    For the ideal circuit, the Resistance of both the PMOS and the NMOS should be the same
    To achieve this the PMOS should be about double the size of the NMOS
        this is because the PMOS has 2x the amount of resistance compared to a NMOS of the same size
*/


namespace Transistor_Modeling_Notes
{
    public static class TransistorResistorTable
    {
        /*
            Contains a Transistor Resistance Table for nmos and pmos based on VDD and Dimensions

            This table assume the width of the transistor divided by the length of the transistor is = 1

            Class Notes: "Resistance of pmos is almost double the resistance of nmos for the same trans.
                size especially in high VDD"
        */

        static Dictionary<double, int> nmosValues = new Dictionary<double, int>(){
            {1,35},
            {1.5,19},
            {2,15},
            {2.5,13}
        };

        static Dictionary<double, int> pmosValues = new Dictionary<double, int>(){
            {1,115},
            {1.5,55},
            {2,38},
            {2.5,31}
        };

        public static int GetValue(bool nmos, double vdd)
        {
            /*Returns the REQ of a transistor based on the inputted VDD*/
            return nmos ? nmosValues[vdd] : pmosValues[vdd];
        }

        public static double GetTransistorResistanceInKilos(bool nmos, double vdd, double WidthByLengthRatio)
        {
            /* Class notes: "to get the Req for a trans. with different size (not W/L=1), divide the number from
                    table by the new W/L (or multiply by new L/W) */
            return nmos ? nmosValues[vdd] / WidthByLengthRatio : pmosValues[vdd] / WidthByLengthRatio;
        }

        public static double GetTransistorResistance(bool nmos, double vdd, double WidthByLengthRatio)
        {
            /* Class notes: "to get the Req for a trans. with different size (not W/L=1), divide the number from
                    table by the new W/L (or multiply by new L/W) */
            // This outputs in ohms instead of kilo ohms
            double res = nmos ? nmosValues[vdd] / WidthByLengthRatio : pmosValues[vdd] / WidthByLengthRatio;
            return res *= Math.Pow(10, 3); //the table was in kilo ohms
        }

        public static double GetTransistorResistance(bool nmos, double vdd, double width, double length)
        {
            /* Class notes: "to get the Req for a trans. with different size (not W/L=1), divide the number from
                    table by the new W/L (or multiply by new L/W) */
            // This outputs in ohms instead of kilo ohms
            double WidthByLengthRatio = Math.Round((width / length), 2);
            double res = nmos ? nmosValues[vdd] / WidthByLengthRatio : pmosValues[vdd] / WidthByLengthRatio;
            return res *= Math.Pow(10, 3); //the table was in kilo ohms
        }
    }
}
