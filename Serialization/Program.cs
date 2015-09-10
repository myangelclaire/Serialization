using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyObjSerial;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee mp = new Employee();
            mp.EmpId = 10;
            mp.EmpName = "Omkumar";

            //XmlSerializer writer = new XmlSerializer(typeof(Employee));
            //StreamWriter file = new StreamWriter(@"c:\temp\Overview.xml");
            //writer.Serialize(file, mp);
            //Console.WriteLine(file.ToString());
            //file.Close();
            StringWriter file = new StringWriter();
            Console.WriteLine(ProgramExt.SerializeObject(mp, file));

            //XmlSerializer reader = new XmlSerializer(typeof(Employee));
            //StreamReader file1 = new StreamReader(@"c:\temp\Overview.xml");
            //mp = (Employee)reader.Deserialize(file1);
            //Console.WriteLine("Employee Id: {0}, Employee Name: {1}", mp.EmpId.ToString(), mp.EmpName);
            Employee mp1 = ProgramExt.DeSerializeObject(mp, file);
            Console.WriteLine("Employee Id: {0}, Employee Name: {1}", mp1.EmpId.ToString(), mp1.EmpName);

            ////Serialization
            //Stream stream = File.Open("EmployeeInfo.txt", FileMode.Create);
            //BinaryFormatter bFormatter = new BinaryFormatter();

            //Console.WriteLine("Writing Employee Informatrion");
            //bFormatter.Serialize(stream, mp);
            //stream.Close();

            ////Deserialization
            //mp = null;

            //stream = File.Open("EmployeeInfo.txt", FileMode.Open);
            //bFormatter = new BinaryFormatter();

            //Console.WriteLine("Reading Employee Informatrion");
            //mp = (Employee)bFormatter.Deserialize(stream);
            //stream.Close();

            //Console.WriteLine("Employee Id: {0}", mp.EmpId.ToString());
            //Console.WriteLine("Employee Name: {0}", mp.EmpName);
            
        }
        
    }

    public static class ProgramExt
    {
        public static string SerializeObject<T>(this T toSerialize, StringWriter file)
        {
            XmlSerializer writer = new XmlSerializer(toSerialize.GetType());
            writer.Serialize(file, toSerialize);
            return file.ToString();
        }

        public static T DeSerializeObject<T>(this T toSerialize, StringWriter file)
        {
            XmlSerializer reader = new XmlSerializer(toSerialize.GetType());
            StringReader file1 = new StringReader(file.ToString());
            toSerialize = (T)reader.Deserialize(file1);
            return toSerialize;
        }
    }
}
