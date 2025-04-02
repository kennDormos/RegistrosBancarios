using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegistrosBancarios.Serializers
{
    public interface ISerializer
    {
        void Serialize(List<Record> records, string filePath);
        List<Record> Deserialize(string filePath);
    }
}
