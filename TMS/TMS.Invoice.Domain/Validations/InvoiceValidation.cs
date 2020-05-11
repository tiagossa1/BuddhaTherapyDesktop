using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Models;

namespace TMS.Invoice.Domain.Validations
{
    public class InvoiceValidation<T> : AbstractValidator<T> where T : InvoiceModel
    {
        protected void ValidateInvoiceDate()
        {
            RuleFor(r => r.InvoiceDate).Must(BeAValidDate).WithMessage("Invalid invoice date.");
        }

        protected void ValidatePrice()
        {
            RuleFor(r => r.Price).NotEmpty().WithMessage("Invalid price.");
        }

        private bool BeAValidDate(DateTime dateTime)
        {
            return dateTime != default;
        }
    }
}
