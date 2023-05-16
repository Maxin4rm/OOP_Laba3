using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Serializers;

namespace WindowsFormsApp1.Factories
{
    public class TxtFactory : SerializerFactory
    {
        public override SerializerInterface CreateSerializer()
        {
            //return null;
            return new Txt_Serializer();
        }
    }
}
