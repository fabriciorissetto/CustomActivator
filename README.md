# CustomActivator 
Is a very simple C# .NET library that is able to create a proxy to an interface at runtime, implementing their properties with the default values or custom values passed by parameter. 

### How it works
It creates a ExpandoObject at runtime and uses the [impromptu-interface] to make it "Act Like" an interface. 

### How to Use
Given you have this interface
```sh
public interface IParametersTest
{
    int Integer { get; set; }
    bool Boolean { get; set; }
    int AnotherInteger { get; set; }
    bool AnotherBoolean { get; set; }
    int? IntegerNullable { get; set; }
}
```
You can instantiate an dynamic object that implemet this interface by simply calling: 
```sh
CustomActivator.CreateInstance<IParametersTest>();
```
It will return the instance of an object that implements the interface **and each property will have its default value**.

> Note: The call CustomActivator.CreateInstance<> works with classes too (not only interfaces) just like the Ativator.CreateInstance<> from the .NET Framework.

###Other Features

#####Instantiate with custom values
You can also call it passing a Dictionary<string, object> as parameter to set the default values to the properties:
```sh
var properties = new Dictionary<string, object>();
properties.Add("Integer", 30);
properties.Add("Boolean", true);
properties.Add("AnotherInteger", "99"); //Passing with incorrect type works to ;D
properties.Add("AnotherBoolean", "true");

var resultObject = CustomActivator.CreateInstance<IParametersTest>(properties);
resultObject.Integer.Should().Be(30);
resultObject.Boolean.Should().Be(true);
resultObject.AnotherInteger.Should().Be(99);
resultObject.AnotherBoolean.Should().Be(true);
resultObject.IntegerNullable.Should().Be(null);
```

#####Setting properties to an existing object
Only call it again passing a Dictionary<string, object> 
```sh
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
```


 [impromptu-interface]:https://github.com/ekonbenefits/impromptu-interface

 