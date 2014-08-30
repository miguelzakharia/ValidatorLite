using System;
using NUnit.Framework;
using Validator.Extensions;

namespace Validator.Test
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        [Test]
        public void IsWithinRange_returns_true_when_input_is_in_defined_bounds()
        {
            Assert.That(DateTime.Parse("1/1/2013").IsWithinRange(DateTime.Parse("12/1/2012"), DateTime.Parse("2/1/2013")), Is.True);
        }

        [Test]
        public void IsWithinRange_returns_false_when_input_is_not_in_defined_bounds()
        {
            Assert.That(DateTime.Parse("1/1/2013").IsWithinRange(DateTime.Parse("12/1/2012"), DateTime.Parse("12/21/2012")), Is.False);
        }
    }
}
