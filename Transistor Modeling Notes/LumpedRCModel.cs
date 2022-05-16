using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_Modeling_Notes
{
    public class LumpedRCModel
    {
        public static double LumpedModelStatic = 0.69;
        static double given_C_diff = 18.24 * Math.Pow(10,-15); //fentoFarads

        /*
         * R_driver = R_eq-nmos / (W_nmos/L_nmos)
         * 
         * aka
         * 
         * Resistance of Transistor = R / (Width/Length)

        //C_wire = C_pp + C_fringe
        */

        public static void ExampleRun()
        {
            ExampleProblem exam = new ExampleProblem();

            //Calculate transistor resistance
            double res = TransistorResistorTable.GetTransistorResistance(exam.nmos, exam.vdd, exam.width / exam.length);

            //Calculate Wire Capacitance
            double cap = CapacitanceTable.GetCapacitanceOfWire(exam.metals, exam.width, exam.length);

            //Print out total propogation for circuit
            double prop = LumpedModelStatic * res * (given_C_diff + cap);
            Console.WriteLine("The propogation delay is: {0}", prop);
        }
    }
}
