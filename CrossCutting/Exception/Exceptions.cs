using Shared.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exception
{
    public class EmployeeNotExist : System.Exception
    {
        public EmployeeNotExist() : base() { }
        public EmployeeNotExist(string message) : base(message) { LogMethods.AddLog(message, LogsTypes.Warning); }
        public EmployeeNotExist(string message, System.Exception inner) : base(message, inner) { LogMethods.AddLog(message, LogsTypes.Warning); }

        protected EmployeeNotExist(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }

    }

   
    public class EmployeeDifferentType : System.Exception
    {
        public EmployeeDifferentType() : base() { }
        public EmployeeDifferentType(string message) : base(message) { LogMethods.AddLog(message, LogsTypes.Warning); }
        public EmployeeDifferentType(string message, System.Exception inner) : base(message, inner) { LogMethods.AddLog(message, LogsTypes.Warning); }

        protected EmployeeDifferentType(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }

   
}
