using System;

namespace FakerLibraryMy
{
    public class GeneratorBoolType:IGenerator
    {
        public object generate()
        {
            return true;
        }

        public string getTypeName()
        {
            return "Boolean";
        }
    }
}