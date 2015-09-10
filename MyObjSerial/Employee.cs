using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace MyObjSerial
{
    [Serializable()]
    public class Employee : ISerializable
    {
        public int EmpId;
        public string EmpName;

        public Employee()
        {
            EmpId = 0;
            EmpName = null;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EmployeeId", EmpId);
            info.AddValue("EmployeeName", EmpName);
        }

        public Employee(SerializationInfo info, StreamingContext context)
        {
            EmpId = (int)info.GetValue("EmployeeId", typeof(int));
            EmpName = (string)info.GetValue("EmployeeName", typeof(string));
        }
    }
}
