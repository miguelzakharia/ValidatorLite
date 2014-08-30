using System;
using System.Collections.Generic;
using System.Text;

namespace Validator
{
    public class ValidationException : ApplicationException
    {
        public IList<string> ValidationMessages { get; set; }

        public override string Message
        {
            get
            {
                var message = base.Message;

                if (ValidationMessages != null && ValidationMessages.Count > 0)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Validation messages:");

                    foreach (var validationMessage in ValidationMessages)
                    {
                        sb.AppendLine(string.Format("- {0}", validationMessage));
                    }

                    message = sb.ToString();
                }

                return message;
            }
        }
    }
}
