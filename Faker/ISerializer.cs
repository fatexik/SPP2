using System.IO;

namespace Faker
{
    public interface ISerializer
    {
        MemoryStream serialize(object result);
    }
}