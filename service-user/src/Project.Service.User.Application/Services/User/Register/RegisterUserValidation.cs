using FluentValidation;
using Project.Service.User.Application.Interfaces.Repositories;

namespace Project.Service.User.Application.Services.User.Register
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidation(IRepositoryUser repositoryUser)
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);

            RuleFor(x => x)
                .CustomAsync(async (x, ctx, ct) =>
                {
                    if (!string.IsNullOrEmpty(x.Email))
                    {
                        var dt = await repositoryUser.GetByEmailAsync(x.Email);
                        if (dt is not null)
                        {
                            ctx.AddFailure("Username or Email already Exist!");
                        }
                    }
                });
        }
    }
}
