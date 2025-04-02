using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrosBancarios.Serializers;

namespace RegistrosBancarios.Factories
{
    public class XmlSerializerFactory : SerializerFactory
    {
        public override ISerializer CreateSerializer()
        {
            return new XmlSerializerClass();
        }
    }
}
