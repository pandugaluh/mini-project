using FluentValidation;
using Project.Service.User.Application.Interfaces.Repositories;

namespace Project.Service.User.Application.Services.User.Remove
{
    public class RemoveUserValidation : AbstractValidator<RemoveUserRequest>
    {
        public RemoveUserValidation(IRepositoryUser repositoryUser)
        {
            RuleFor(x => x.UserGuid).NotEmpty();

            RuleFor(x => x)
                .CustomAsync(async (x, ctx, ct) =>
                {
                    if (x.UserGuid != Guid.Empty)
                    {
                        var dt = await repositoryUser.GetByUserGuidAsync(x.UserGuid);
                        if (dt is null)
                        {
                            ctx.AddFailure("User not found!");
                        }
                    }
                });
        }
    }
}
