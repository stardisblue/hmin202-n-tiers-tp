using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

using ClientWebService.ConvertTemperatureService;
using ClientWebService.PeriodicTableService;

namespace ClientWebService
{
    using ClientWebService.ConvertTemperatureService;
    using ClientWebService.PeriodicTableService;

    class Program
    {
        static void Main(string[] args)
        {
            // Premiere partie, 
            Debug.WriteLine("PeriodicTable :");
            Debug.Indent();
            PeriodicTable();
            Debug.Unindent();

            Debug.WriteLine("Convert Temperature :");
            Debug.Indent();
            ConvertTemperature();
            Debug.Unindent();
        }

        private static void PeriodicTable()
        {
            periodictable periodicTable = new periodictable();
            XmlDocument atomsXml = new XmlDocument();
            atomsXml.LoadXml(periodicTable.GetAtoms());

            XmlNode node = atomsXml.SelectSingleNode("NewDataSet/Table/ElementName");

            String elementName = node.InnerText;
            Debug.WriteLine(elementName);

            String element = periodicTable.GetAtomicNumber(elementName);
            XmlDocument atomXml = new XmlDocument();
            atomXml.LoadXml(element);

            XmlNode elementXml = atomXml.SelectSingleNode("NewDataSet/Table");
            Debug.WriteLine(elementXml.SelectSingleNode("ElementName").InnerText);
            Debug.Indent();
            foreach (XmlNode childNode in elementXml.ChildNodes)
            {
                Debug.WriteLine(childNode.Name + " : " + childNode.InnerText);
            }
            Debug.Unindent();
        }

        private static void ConvertTemperature()
        {
            ConvertTemperature convertTemperature = new ConvertTemperature();
            double celsuis = 100;
            double fahrenheit = convertTemperature.ConvertTemp(celsuis, TemperatureUnit.degreeCelsius, TemperatureUnit.degreeFahrenheit);
            double rankine = convertTemperature.ConvertTemp(fahrenheit, TemperatureUnit.degreeFahrenheit, TemperatureUnit.degreeRankine);
            double reaumur = convertTemperature.ConvertTemp(rankine, TemperatureUnit.degreeRankine, TemperatureUnit.degreeReaumur);
            double newCelsuis = convertTemperature.ConvertTemp(reaumur, TemperatureUnit.degreeReaumur, TemperatureUnit.degreeCelsius);

            Debug.WriteLine("celsuis: " + celsuis);
            Debug.WriteLine("fahrenheit: " + fahrenheit);
            Debug.WriteLine("rankine: " + rankine);
            Debug.WriteLine("reaumur: " + reaumur);
            Debug.WriteLine("newCelsuis: " + newCelsuis);
        }
    }
}
