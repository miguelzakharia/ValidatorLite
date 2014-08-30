using System.Collections.Generic;

namespace Validator
{
    public class ValidationResults
    {
        public bool IsValid { get; set; }
        public IList<string> Messages { get; set; }

        public ValidationResults()
        {
            IsValid = true;
            Messages = new List<string>();
        }

        public void Add(ValidationResult result)
        {
            if (!result.IsValid)
            {
                IsValid = result.IsValid;
                Messages.Add(result.ValidationMessage);
            }
        }
    }
}