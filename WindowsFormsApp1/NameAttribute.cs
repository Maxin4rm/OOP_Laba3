using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [AttributeUsage(AttributeTargets.Field)]
    class NameAttribute : System.Attribute
    {
        private string name;
        public NameAttribute(string _name)
        {
            this.name = _name;
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}