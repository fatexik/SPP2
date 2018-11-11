using System;
using System.IO;

namespace FakerLibraryMy
{
    public class ResultWriter:IResultWriter
    {
        public void write(MemoryStream memoryStream)
        {
            StreamReader streamReader = new StreamReader(memoryStream);
            Console.WriteLine(streamReader.ReadToEnd());
        }
    }
}