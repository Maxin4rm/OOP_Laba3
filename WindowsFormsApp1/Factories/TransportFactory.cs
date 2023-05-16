using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;

namespace WindowsFormsApp1.Factories
{
    abstract class TransportFactory
    {
        public abstract Transport createTransport(List<string> fields);
    }
}
