using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exception
{
    [Serializable()]
    public class EmployeeNotExist : System.Exception
    {
        public EmployeeNotExist() : base() { }
        public EmployeeNotExist(string message) : base(message) { }
        public EmployeeNotExist(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected EmployeeNotExist(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }

    }

    [Serializable()]
    public class EmployeeDifferentType : System.Exception
    {
        public EmployeeDifferentType() : base() { }
        public EmployeeDifferentType(string message) : base(message) { }
        public EmployeeDifferentType(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected EmployeeDifferentType(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
