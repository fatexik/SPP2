namespace Faker
{
    public interface IGenerator
    {
        object generate();
        string getTypeName();
    }
}