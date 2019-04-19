using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validaciones.Models.Validaciones;

namespace Validaciones.Models
{
    public class Persona:IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio man")]
        public string Nombre { get; set; }
        [StringLength(6,MinimumLength =5,ErrorMessage ="El campo {0} debe tener una longitud minima de {2} y un máximo de {1}")]
        public string CodigoPostal { get; set; }
        [Range(18,100,ErrorMessage ="El campo{0} debe de estar entre {1} y {2}")]
        public int Edad { get; set; }
        [Required][StringLength(200)]        
        public string Email { get; set; }
        [NotMapped]//Este valor no mapea este atributo como campo en la base de datos
        [System.ComponentModel.DataAnnotations.Compare("Email",ErrorMessage ="Los emails no concuerdan hermano")]
        public string ConfirmarEmail { get; set; }
        [CreditCard(ErrorMessage ="Tarjeta inválida chaval")]
        public string TarjetaCreditos{ get; set; }
        [Remote("DivisibleEntreDos","Personas",ErrorMessage ="Este Número no es Disible entre 2")]        
        [DivisibleEntre(2,ErrorMessage ="EL numero no es divisble")]
        public int NumeroDivisibleEntre2 { get; set; }
        public decimal Salario { get; set; }
        public decimal MonsoSolicitudPrestamos { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();
            if (Salario *4 < MonsoSolicitudPrestamos)
            {
                errores.Add(new ValidationResult("El Monto Solicitud préstamos no debe exceder 4 veces el salario",
                    new string[] { "MonsoSolicitudPrestamos" }));
            }

            return errores;
        }

        [DataType(DataType.Password)]
        public string Resumen { get; set; }

    }
}