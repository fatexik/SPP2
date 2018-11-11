using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FakerLibraryMy
{
    public class JSONSerializer : ISerializer
    {
        public MemoryStream serialize(object result)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result, Formatting.Indented));
            return new MemoryStream(bytes);
        }
    }
}