using System.IO;

namespace FakerLibraryMy
{
    public interface ISerializer
    {
        MemoryStream serialize(object result);
    }
}