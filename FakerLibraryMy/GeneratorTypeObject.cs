namespace FakerLibraryMy
{
    public class GeneratorTypeObject:IGenerator
    {
        public object generate()
        {
            return new object();
        }

        public string getTypeName()
        {
            return "Object";
        }
    }
}