using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FluentAssertions;
using FakeItEasy;
using ReflectionHelper;

namespace ReflectionHelperTest
{
    [TestClass]
    public class ReflectionHelperTest
    {
        [TestMethod]
        public void CustomActivatorMustInstantiateIntarfaceWithItsDefaultValues()
        {
            var resultObject = CustomActivator.CreateInstance<IParametersTest>();

            resultObject.Integer.Should().Be(0);
            resultObject.Boolean.Should().Be(false);
            resultObject.AnotherInteger.Should().Be(0);
            resultObject.AnotherBoolean.Should().Be(false);
            resultObject.IntegerNullable.Should().Be(null);
        }

        [TestMethod]
        public void CustomActivatorMustInstantiateIntarfaceWithPopulatedProperties()
        {
            var properties = new Dictionary<string, object>();
            
            //Passing the correct types (int and bool)
            properties.Add("Integer", 30);
            properties.Add("Boolean", true);

            //Passing the types in string to test if CustomActivator will cast correctly
            properties.Add("AnotherInteger", "99");
            properties.Add("AnotherBoolean", "true");

            //We will not pass this property to test if CustomActivator will bring its default value(NULL)
            //properties.Add("IntegerNullable", 50);

            var resultObject = CustomActivator.CreateInstanceAndPopulateProperties<IParametersTest>(properties);

            resultObject.Integer.Should().Be(30);
            resultObject.Boolean.Should().Be(true);
            resultObject.AnotherInteger.Should().Be(99);
            resultObject.AnotherBoolean.Should().Be(true);
            resultObject.IntegerNullable.Should().Be(null);
        }

        [TestMethod]
        public void ReflectionHelperDeveInstanciarObjetoComPropriedadesPopuladas()
        {
            var properties = new Dictionary<string, object>();

            //Passing the correct types (int and bool)
            properties.Add("Integer", 30);
            properties.Add("Boolean", true);

            //Passing the types in string to test if CustomActivator will cast correctly
            properties.Add("AnotherInteger", "99");
            properties.Add("AnotherBoolean", "true");

            //We will not pass this property to test if CustomActivator will bring its default value(NULL)
            //properties.Add("IntegerNullable", 50);

            var resultObject = CustomActivator.CreateInstanceAndPopulateProperties<InstantiableObject>(properties);

            resultObject.Integer.Should().Be(30);
            resultObject.Boolean.Should().Be(true);
            resultObject.AnotherInteger.Should().Be(99);
            resultObject.AnotherBoolean.Should().Be(true);
            resultObject.IntegerNullable.Should().Be(null);
        }

        [TestMethod]
        public void ReflectionHelperDeveSobrescreverPropriedadesDoObjetoJaInstanciado()
        {
            var myObject = new InstantiableObject();
            myObject.Integer = 1;
            myObject.Boolean = false;
            myObject.AnotherInteger = 2;
            myObject.AnotherBoolean = false;
            myObject.IntegerNullable = 3;

            var properties = new Dictionary<string, object>();
            properties.Add("Integer", "10");
            properties.Add("Boolean", "true");
            properties.Add("AnotherInteger", "20");
            properties.Add("AnotherBoolean", "true");
            properties.Add("IntegerNullable", null);

            CustomActivator.PopulateObjectProperties(myObject, properties);

            myObject.Integer.Should().Be(10);
            myObject.Boolean.Should().Be(true);
            myObject.AnotherInteger.Should().Be(20);
            myObject.AnotherBoolean.Should().Be(true);
            myObject.IntegerNullable.Should().Be(null);
        }
    }
}
