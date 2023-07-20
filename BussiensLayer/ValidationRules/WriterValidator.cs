using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BussiensLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(p => p.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soy adını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvanı Boş Geçemezsiniz.");


        }


    }
}
