using System;

namespace FakerLibraryMy
{
    public class GeneratorDateTime:IGenerator
    {
        public object generate()
        {
            return DateTime.Now;
        }

        public string getTypeName()
        {
            return "DateTime";
        }
    }
}