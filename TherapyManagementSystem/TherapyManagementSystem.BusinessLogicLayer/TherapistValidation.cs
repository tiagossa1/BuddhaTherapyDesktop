using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyManagementSystem.Common;
using TherapyManagementSystem.Common.Models;
using TherapyManagementSystem.DataAccessLayer;

namespace TherapyManagementSystem.BusinessLogicLayer
{
    public class TherapistValidation : AbstractValidator<Therapist>
    {
        public TherapistValidation()
        {
            RuleFor(x => x.ID).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.MobileNumber).NotNull().NotEmpty().Length(9).Custom((mobilePhone, context) =>
            {
                if (IsMobilePhoneTaken(mobilePhone))
                    context.AddFailure("Mobile phone is already taken.");
            });
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email)).Custom((email, context) =>
            {
                if (IsEmailTaken(email) && !string.IsNullOrWhiteSpace(email))
                    context.AddFailure("Email is already taken.");
            });
            RuleFor(x => x.Username).NotEmpty().NotNull().Custom((username, context) =>
            {
                if (IsUsernameTaken(username))
                    context.AddFailure("Username is already taken.");
            });
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }

        private bool IsUsernameTaken(string username)
        {
            TherapistDAL therapistDal = new TherapistDAL();

            List<Therapist> therapists = therapistDal.GetAllTherapists();
            return therapists.Any(x => x.Username == username);
        }

        private bool IsEmailTaken(string email)
        {
            TherapistDAL therapistDal = new TherapistDAL();

            List<Therapist> therapists = therapistDal.GetAllTherapists();
            return therapists.Any(x => x.Email == email);
        }

        private bool IsMobilePhoneTaken(string mobilePhone)
        {
            TherapistDAL therapistDal = new TherapistDAL();

            List<Therapist> therapists = therapistDal.GetAllTherapists();
            return therapists.Any(x => x.MobileNumber == mobilePhone);
        }
    }
}
