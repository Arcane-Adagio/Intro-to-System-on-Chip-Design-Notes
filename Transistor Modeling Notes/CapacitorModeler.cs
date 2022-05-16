/*Coded much of this at 3am... im afraid of when I'll have to look at this again*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_Modeling_Notes
{
    /*
        A wire can be represented/modeled as a plate above the substrate
            So it consists of the internal capacitance C_int = C_pp
            Sometimes we use C_int = C_gate = C_pp
        The Capacitance of a wire (C_wire) = C_pp + C_fringe
        Table from lecture 4, Slide 10
     
     */



    public enum Metals { substrate, diffusion, poly, metal1, metal2, metal3, metal4, metal5 };
    /*
     Note: In slide, these were synonomous
        A11=METAL1, A12=METAL2, A13=METAL3, A14=METAL4, A15=METAL5
     */

    public static class CapacitanceTable
    {
        /*

        */

        static Dictionary<(Metals, Metals), (double, double)> MetalByMetalTable = new Dictionary<(Metals, Metals), (double, double)>(){
            //(int, int) = (C_pp, C_fringe)
            {(Metals.substrate, Metals.poly), (88,54)},
            {(Metals.substrate, Metals.metal1), (30,40)},
            {(Metals.substrate, Metals.metal2), (13,25)},
            {(Metals.substrate, Metals.metal3), (8.9,18)},
            {(Metals.substrate, Metals.metal4), (6.5,14)},
            {(Metals.substrate, Metals.metal5), (5.2,12)},


            {(Metals.diffusion, Metals.metal1), (41,47)},
            {(Metals.diffusion, Metals.metal2), (15,27)},
            {(Metals.diffusion, Metals.metal3), (9.4,19)},
            {(Metals.diffusion, Metals.metal4), (6.8,15)},
            {(Metals.diffusion, Metals.metal5), (5.4,12)},


            {(Metals.poly, Metals.metal1), (57,54)},
            {(Metals.poly, Metals.metal2), (17,29)},
            {(Metals.poly, Metals.metal3), (10,20)},
            {(Metals.poly, Metals.metal4), (7,15)},
            {(Metals.poly, Metals.metal5), (5.4,12)},


            {(Metals.metal1, Metals.metal2), (36,45)},
            {(Metals.metal1, Metals.metal3), (15,27)},
            {(Metals.metal1, Metals.metal4), (8.9,18)},
            {(Metals.metal1, Metals.metal5), (6.6,14)},


            {(Metals.metal2, Metals.metal3), (41,19)},
            {(Metals.metal2, Metals.metal4), (15,27)},
            {(Metals.metal2, Metals.metal5), (9.1,19)},


            {(Metals.metal3, Metals.metal4), (35,45)},
            {(Metals.metal3, Metals.metal5), (14,27)},

            {(Metals.metal4, Metals.metal5), (38,52)},
        };


        public static double GetTableValues(bool cpp, Metals m1, Metals m2)
        {
            /*Returns the REQ of a transistor based on the inputted VDD*/
            return cpp ? MetalByMetalTable[(m1,m2)].Item1 : MetalByMetalTable[(m1, m2)].Item2;
        }

        public static double GetCFringeCustomDimensions(Metals m1, Metals m2, double length)
            //This function expects the length and width to be in micrometers
            //The answer is in picofarads

            /*Class notes:
                 * To calculate the C_fringe for a given wire, take the Cfringe from the table and scale (multiply)
                 * it to length(L) of the given wire x2 since we have two sides of the wire
            */
        {
            double normalCFringe = GetTableValues(false, m1, m2);
            return normalCFringe * (length * 2);
        }

        public static double GetCppCustomDimensions(Metals m1, Metals m2, double length, double width)
        //This function expects the length and width to be in micrometers
        //The answer is in picofarads

            /*Class notes:
                 * To calculate the C_pp for a given wire, take the Cpp from the table and scale (multiply)
                 * it to the area (L.W) of the given wire
            */
        {

            double normalCpp = GetTableValues(true, m1, m2) * UnitConverter.micrometer;
            return normalCpp * (length * width) * Math.Pow(10,12);
        }


        public static double GetCapacitanceOfWireInPicos(Metals m2, double width, double length, Metals m1 = Metals.substrate)
        {
            return GetCppCustomDimensions(m1, m2, length, width) + GetCFringeCustomDimensions(m1, m2, length);
        }

        public static double GetCapacitanceOfWire(Metals m2, double width, double length, Metals m1 = Metals.substrate)
        {
            return (GetCppCustomDimensions(m1, m2, length, width) + GetCFringeCustomDimensions(m1, m2, length)) * Math.Pow(10,-12);
        }
    }
}
