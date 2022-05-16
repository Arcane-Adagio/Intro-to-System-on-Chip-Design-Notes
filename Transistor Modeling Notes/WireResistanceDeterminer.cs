using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C_internal = C_diff = C_g x Factor
// R_wire = R_sheet (L/W)


namespace Transistor_Modeling_Notes
{
    public enum wireMaterial {negativeWellDiffusion, positiveDiffusion, positiveDiffusionWithSilicide, positivePolysilicon, 
                              positivePolysiliconWithSilicide, Aluminum};

    public static class WireResistanceTable
    {
        /*

        */



        static Dictionary<wireMaterial, double> SheetResistanceValues = new Dictionary<wireMaterial, double>(){
            //For modeling, it is standand to use the middle of the resistance range for a given material
            //      The ranges are commented, the avg is returned
            {wireMaterial.negativeWellDiffusion, 1250}, //1000 - 1500
            {wireMaterial.positiveDiffusion, 100}, // 50 - 150
            {wireMaterial.positiveDiffusionWithSilicide, 4}, // 3 - 5
            {wireMaterial.positivePolysilicon, 175}, // 150 - 200
            {wireMaterial.positivePolysiliconWithSilicide, 4.5}, //4 - 5
            {wireMaterial.Aluminum, 0.075}, //0.05 - 0.1
        };


        public static double GetRSheetValue(wireMaterial material)
        {
            /*Returns the Sheet Resistance of a material*/
            return SheetResistanceValues[material];
        }

        public static double GetRWireValue(wireMaterial material, double w, double l)
        {
            /*Returns the Resistance of a wire*/
            return SheetResistanceValues[material] * (l/w);
        }



    }
}
