using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionHelperTest
{
    public interface IParametersTest
    {
        int Integer { get; set; }
        bool Boolean { get; set; }
        int AnotherInteger { get; set; }
        bool AnotherBoolean { get; set; }
        int? IntegerNullable { get; set; }
    }
}
