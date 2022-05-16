// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Console.WriteLine(Transistor_Modeling_Notes.TransistorResistorTable.GetValue(true, 1));

using Transistor_Modeling_Notes;


double answer = WireResistanceTable.GetRWireValue(
    wireMaterial.Aluminum, 
    UnitConverter.ConvertToStandardUnits(Units.micrometer, 1), 
    UnitConverter.ConvertToStandardUnits(Units.centimeter, 1)
    );

double answer2 = CapacitanceTable.GetCapacitanceOfWireInPicos(
    Metals.metal1,
    Math.Pow(10, -6), //1 micrometer
    Math.Pow(10, -6) * Math.Pow(10,4) //1 centimeter
    );


(double, Prefix) answerRounded = UnitConverter.ConvertFromStandard(answer);
Console.WriteLine(answer2);

LumpedRCModel.ExampleRun();

//Console.WriteLine(WireResistanceTable.GetRSheetValue(wireMaterial.Aluminum));