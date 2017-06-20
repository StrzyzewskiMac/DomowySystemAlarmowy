using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class MinimumPrivilegeLevelAttribute : System.Attribute
    {
        public int PrivilegeLevel { get; private set; }

        public MinimumPrivilegeLevelAttribute(int privilegeLevel)
        {
            PrivilegeLevel = privilegeLevel;
        }
    }
}
