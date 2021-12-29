using Ecommerce.Validation.Exceptions;
using System;
using System.Collections.Generic;

namespace Ecommerce.Validation
{
    public abstract class BaseValidator<T> where T : class
    {
        private IList<string> _erros = new List<string>();
        protected IList<string> Erros
        {
            get => _erros;
            set => _erros = value;
        }
        
        public abstract void Validate(T dto);

        protected void CheckErrors()
        {
            if (Erros.Count > 0)
            {
                throw new ValidationException(Erros);
            }
        }
    }
}