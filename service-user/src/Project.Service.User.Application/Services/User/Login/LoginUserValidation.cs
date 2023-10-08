using FluentValidation;
using Project.Service.User.Application.Helpers;
using Project.Service.User.Application.Interfaces.Repositories;

namespace Project.Service.User.Application.Services.User.Login
{
    public class LoginUserValidation : AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidation(IRepositoryUser repositoryUser)
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(20);

            RuleFor(x => x)
                .CustomAsync(async (x, ctx, ct) =>
                {
                    if (!string.IsNullOrEmpty(x.Email) && !string.IsNullOrEmpty(x.Password))
                    {
                        var dt = await repositoryUser.GetByEmailAndPasswordAsync(x.Email, ExtentionHelper.HashPassword(x.Password));
                        if (dt is null)
                        {
                            ctx.AddFailure("Email or password does not match!");
                        }
                    }
                });
        }
    }
}
