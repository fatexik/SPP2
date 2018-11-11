using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Faker
{
    public class JSONSerializer : ISerializer
    {
        public MemoryStream serialize(object result)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result, Formatting.Indented));
            return new MemoryStream(bytes);
        }

        public List<Type> deserialize(MemoryStream memoryStream)
        {
            var serializer = new JSONSerializer();
            return serializer.deserialize(memoryStream);
        }
    }
}