using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GolyakaSinav.DatabaseSinav.Entities.Concrete;

namespace GolyakaSinav.DatabaseSinav.Business.ValidationRules.FluentValidation
{
    public class DersValidatior : AbstractValidator<Ders>
    {
        public DersValidatior()
        {
            RuleFor(h => h.Id).NotEmpty();
            
            RuleFor(h => h.Adi).NotEmpty();
            RuleFor(h => h.Kodu).NotEmpty();
            RuleFor(h => h.AktifMi).NotNull();

            RuleFor(h => h.Adi).Length(2, 75);
            

        }
    }
}
