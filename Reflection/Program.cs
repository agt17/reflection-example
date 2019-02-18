using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read data with XPath
            XPathDocument doc_xml = new XPathDocument("ReflectionConfiguration.xml");

            XPathNavigator navegador = doc_xml.CreateNavigator();
            XPathNavigator text_nodes = navegador.SelectSingleNode("/Types/Type[@Id='Alumno1']");

            string IdAlumno1 = text_nodes.SelectSingleNode("IdAlumno").Value;
            string Nombre1 = text_nodes.SelectSingleNode("Nombre").Value;
            string Apellidos1 = text_nodes.SelectSingleNode("Apellidos").Value;
            string Dni1 = text_nodes.SelectSingleNode("Dni").Value;

            // Read document
            Assembly myAssembly = typeof(Program).Assembly;
            XPathNavigator text_node = text_nodes.SelectSingleNode("Class");
            Type alumnoType = myAssembly.GetType(text_node.ToString());

            // create instance of class Alumno
            object objetoDeAlumno = Activator.CreateInstance
                (alumnoType, Int32.Parse(IdAlumno1), Nombre1, Apellidos1, Dni1);

            Console.WriteLine(( (Alumno)objetoDeAlumno).Nombre);


            // Read data with XElement
            XElement root = XElement.Load("ReflectionConfiguration.xml");
            // Linq to xml
            IEnumerable<XElement> tests =
                from element in root.Elements("Type")
                where (string)element.Attribute("Id") == "Alumno2"
                select element;
            string cadena = tests.FirstOrDefault().Element("Class").Value;

            XElement cadenaAlumnos = tests.FirstOrDefault();
            string IdAlumno2 = cadenaAlumnos.Element("IdAlumno").Value;
            string Nombre2 = cadenaAlumnos.Element("Nombre").Value;
            string Apellidos2 = cadenaAlumnos.Element("Apellidos").Value;
            string Dni2 = cadenaAlumnos.Element("Dni").Value;
            
            // get type of class Alumno from just loaded assembly
            Type alumno1Type = myAssembly.GetType(cadena);

            // create instance of class Alumno
            object objetoDeAlumno1 =
                Activator.CreateInstance
                (alumno1Type, Int32.Parse(IdAlumno2), Nombre2, Apellidos2, Dni2);

            Console.WriteLine(((Alumno)objetoDeAlumno1).Nombre);
        }
    }
}
