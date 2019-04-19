using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validaciones.Models.Validaciones
{
    public class DivisibleEntreAttribute: ValidationAttribute
    {
        public int _Dividendo;

        public DivisibleEntreAttribute(int dividendo)
            : base("El campo {0} es inválido chamo")
        {
            this._Dividendo = dividendo;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext )
        {
            if (value !=null)
            {
                if ((int)value % _Dividendo !=0) {
                    var mensajeDeError = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(mensajeDeError);
                }
            }
            return ValidationResult.Success;
        }
    }
}