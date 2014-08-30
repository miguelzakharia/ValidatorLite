using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Validator.Test
{
    public class ValidatorTest
    {
        [Test]
        public void Validate_indicates_valid_and_does_not_contain_messages_when_all_rules_pass()
        {
            var validatorStub = MockRepository.GenerateStub<IValidator<string>>();
            var ruleStub = MockRepository.GenerateStub<Func<string, ValidationResult>>();
            ruleStub.Stub(rule => rule(null))
                    .IgnoreArguments()
                    .Return(new ValidationResult() { IsValid = true });

            validatorStub.Rules = new List<Func<string, ValidationResult>>() { ruleStub };
            var validationManager = new ValidationManager<string>(validatorStub);

            var actual = validationManager.Validate(null);

            Assert.That(actual.IsValid, Is.True);
            Assert.That(actual.Messages.Any(), Is.False);
        }

        [Test]
        public void Validate_indicates_invalid_and_contains_messages_when_any_rule_fails()
        {
            var validatorStub = MockRepository.GenerateStub<IValidator<string>>();
            var ruleStub = MockRepository.GenerateStub<Func<string, ValidationResult>>();
            ruleStub.Stub(rule => rule(null))
                    .IgnoreArguments()
                    .Return(new ValidationResult() { IsValid = false, ValidationMessage = "test" });

            validatorStub.Rules = new List<Func<string, ValidationResult>>() { ruleStub };
            var validationManager = new ValidationManager<string>(validatorStub);

            var actual = validationManager.Validate(null);

            Assert.That(actual.IsValid, Is.False);
            Assert.That(actual.Messages.Any(), Is.True);
        }

        [Test]
        [ExpectedException(typeof (ValidationException))]
        public void Validate_throws_exception_when_not_valid_and_ThrowValidationException_property_set_to_true()
        {
            var validatorStub = MockRepository.GenerateStub<IValidator<string>>();
            var ruleStub = MockRepository.GenerateStub<Func<string, ValidationResult>>();
            ruleStub.Stub(rule => rule(null))
                    .IgnoreArguments()
                    .Return(new ValidationResult() { IsValid = false, ValidationMessage = "test" });

            validatorStub.Rules = new List<Func<string, ValidationResult>>() { ruleStub };
            var validationManager = new ValidationManager<string>(validatorStub, true);

            validationManager.Validate(null);            
        }
    }
}
