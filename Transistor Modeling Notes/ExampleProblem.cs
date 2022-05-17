using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_Modeling_Notes
{
    public class ExampleProblem
    {
        public Wire wire = new Wire();
        public Transistor transistor = new Transistor();

        public ExampleProblem()
        {

        }

        public ExampleProblem(Transistor t, Wire w)
        {
            Transistor transistor = t;
            Wire wire = w;
        }


    }

    public class Transistor
    {
        public double transistorWidth;
        public double transistorLength;
        public double vdd;
        public bool nmos;

        public Transistor()
        {
            transistorWidth = 4 * Math.Pow(10, -6); // 4 micrometers
            transistorLength = 2 * Math.Pow(10, -6); // 2 micrometers
            vdd = 2.5; //2.5 volts
            nmos = true;
        }
    }

    public class Wire
    {
        public double wireWidth;
        public double wireLength;
        public wireMaterial material;
        public Metals metals;

        public Wire()
        {
            wireWidth = 1 * Math.Pow(10, -6); // 1 micrometers
            wireLength = 1 * Math.Pow(10, -2); // 1 centimeters
            material = wireMaterial.Aluminum;
            metals = Metals.metal1;
        }
    }
}
