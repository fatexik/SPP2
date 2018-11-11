using System;
 using FakerLibraryMy;
using UnitTests;

namespace ConsoleApplication1
 {
     internal class Program
     {
         public static void Main(string[] args)
         {
             Faker faker = new Faker();
             Class1 class1 = faker.Create<Class1>();
             ResultWriter resultWriter = new ResultWriter();
             JSONSerializer jsonSerializer = new JSONSerializer();
             Console.Write("\n\n\n");
             Console.ReadLine();
         }
     }
 }