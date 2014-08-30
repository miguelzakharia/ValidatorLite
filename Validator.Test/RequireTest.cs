using System;
using NUnit.Framework;

namespace Validator.Test
{
    [TestFixture]
    public class RequireTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Argument_throws_ArgumentException_when_argumentValue_is_null()
        {
            Require.Argument(null, "myArg");
        }

        [Test]
        public void Argument_does_not_throw_ArgumentException_when_argumentValue_is_not_null()
        {
            Require.Argument("test", "myArg");
        }
    }
}
