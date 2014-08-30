using System;

namespace Validator
{
    public class ValidationManager<T>
    {
        private readonly IValidator<T> _validator;

        public bool ThrowValidationException { get; set; }

        public ValidationManager(IValidator<T> validator)
            : this(validator, false) { }

        public ValidationManager(IValidator<T> validator, bool throwValidationException)
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }

            _validator = validator;
            ThrowValidationException = throwValidationException;
        }

        public ValidationResults Validate(T validateThis)
        {
            var validationResults = new ValidationResults();
            foreach (var rule in _validator.Rules)
            {
                validationResults.Add(rule(validateThis));
            }

            if (ThrowValidationException)
            {
                if (!validationResults.IsValid)
                {
                    throw new ValidationException() { ValidationMessages = validationResults.Messages };
                }
            }

            return validationResults;
        }
    }
}
