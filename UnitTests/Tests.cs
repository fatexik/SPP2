using System;
using System.Collections.Generic;
using FakerLibraryMy;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        private Faker faker;
        private Ex1<int> Ex1;
        private Class1 _class1;
        [OneTimeSetUp]
        public void setUp()
        {
            faker = new Faker();
            Ex1 = faker.Create<Ex1<int>>();
            _class1 = faker.Create<Class1>();
        }

        [Test]
        public void charGeneratorTest()
        {
            Assert.NotNull(Ex1.getChar());
        }

        [Test]
        public void dateTimeTest()
        {
            Assert.NotNull(Ex1.getDateTime());
        }

        [Test]
        public void doubleGeneratorTest()
        {
            Assert.NotZero(Ex1.getDouble());
        }

        [Test]
        public void intGeneratorTest()
        {
            Assert.NotZero(Ex1.getInt());
        }

        [Test]
        public void listGeneratorTest1()
        {
            Assert.NotNull(Ex1.getList());
            Assert.IsTrue(Ex1.getList() is List<int>);
        }

        [Test]
        public void objectGeneratorTest()
        {
            Assert.NotNull(Ex1.getObj());
        }

        [Test]
        public void longGeneratorTest()
        {
            Assert.NotZero(Ex1.getLong());
        }

        [Test]
        public void stringGeneratorTest()
        {
            Assert.NotNull(Ex1.getString());
            Assert.NotZero(Ex1.getString().Length);
        }

        [Test]
        public void InsertedClassTest1()
        {
            Assert.NotNull(Ex1.getEx2());
        }

        [Test]
        public void InsertedClassTest2()
        {
            Assert.NotNull(Ex1.getEx2()._ex2);
        }

        [Test]
        public void InsertedClassTest3()
        {
            Assert.IsNull(Ex1.getEx2()._ex2._ex2);
        }

        [Test]
        public void booleanGeneratorTest()
        {
            Assert.IsTrue(Ex1.getBool());
        }

        [Test]
        public void booleanGeneratorTest2()
        {
            Assert.IsTrue(Ex1.getEx2()._bool);
        }

        [Test]
        public void testDeep()
        {
            Assert.IsNull(_class1.class2.class1);
            Assert.IsNull(_class1.class2.class11);   
        }
    }
}