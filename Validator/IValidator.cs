using System;
using System.Collections.Generic;

namespace Validator
{
    public interface IValidator<T>
    {
        //[mz] Made the Set public for unit tests. I don't like it.
        IList<Func<T, ValidationResult>> Rules { get; set; }
    }
}
