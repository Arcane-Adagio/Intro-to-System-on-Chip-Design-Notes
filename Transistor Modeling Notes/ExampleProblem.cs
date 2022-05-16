using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transistor_Modeling_Notes
{
    public class ExampleProblem
    {
        public double width;
        public double length;
        public double vdd;
        public wireMaterial material;
        public Metals metals;
        public bool nmos;

        public ExampleProblem()
        {
            width = 4 * Math.Pow(10, -6); // 4 micrometers
            length = 2 * Math.Pow(10, -6); // 2 micrometers
            vdd = 2.5; //2.5 volts
            material = wireMaterial.Aluminum;
            metals = Metals.metal1;
            nmos = true;
        }
    }
}
