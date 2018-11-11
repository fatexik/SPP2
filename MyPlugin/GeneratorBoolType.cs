using System;
using FakerLibraryMy;

namespace MyPlugin
{
    public class GeneratorBoolType : IGenerator
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