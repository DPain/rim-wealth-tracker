using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rim_wealth_tracker.API {
    /// <summary>
    /// Wrapper class used to describe API calls.
    /// </summary>
    class Courier {
        // Instance fields.
        public string name;
        public string description;
        public string funcName;
        public Type returnType;

        public Courier(string name, string description, string funcName, Type returnType) {
            this.name = name;
            this.description = description;
            this.funcName = funcName;
            this.returnType = returnType;
        }
    }
}
