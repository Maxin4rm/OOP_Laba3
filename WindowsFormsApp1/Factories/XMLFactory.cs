using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApp1.Serializers;

namespace WindowsFormsApp1.Factories
{
    public class XMLFactory : SerializerFactory
    {
        public override SerializerInterface CreateSerializer()
        {
            return new XML_Serializer();
        }
    }
}
