using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Validator.Extensions;

namespace Validator.Test
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void MeetsLengthRequirements_returns_true_when_string_is_valid()
        {
            Assert.That("abc".MeetsLengthRequirements(1,3), Is.True);
        }
        
        [Test]
        public void MeetsLengthRequirements_returns_false_when_string_is_not_valid()
        {
            Assert.That("abc".MeetsLengthRequirements(4,5), Is.False);
        }

        [Test]
        public void LengthIsExactly_returns_true_when_string_is_valid()
        {
            Assert.That("abc".LengthIsExactly(3), Is.True);
        }
        
        [Test]
        public void LengthIsExactly_returns_false_when_string_is__not_valid()
        {            
            Assert.That("abc".LengthIsExactly(13), Is.False);
        }
        
        [Test]
        public void LengthIsAtLeast_returns_true_when_string_is_valid()
        {
            Assert.That("abc".LengthIsAtLeast(2), Is.True);
        }
    
        [Test]
        public void LengthIsNotLongerThan_returns_true_when_string_is_valid()
        {
            Assert.That("abc".LengthIsNotLongerThan(4), Is.True);
        }
        
        [Test]
        public void LengthIsNotLongerThan_returns_false_when_string_is_not_valid()
        {
            Assert.That("abc".LengthIsNotLongerThan(1), Is.False);
        }

        [Test]
        public void IsEmptyOrAtLeast_returns_true_when_string_is_valid()
        {
            Assert.That("abc".IsEmptyOrAtLeast(3), Is.True);
            Assert.That("".IsEmptyOrAtLeast(3), Is.True);
        }
        
        [Test]
        public void IsEmptyOrAtLeast_returns_false_when_string_is_not_valid()
        {
            Assert.That("abc".IsEmptyOrAtLeast(5), Is.False);
        }
    }
}
