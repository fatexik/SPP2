using System.IO;

namespace FakerLibraryMy
{
    public interface IResultWriter
    {
        void write(MemoryStream memoryStream);
    }
}