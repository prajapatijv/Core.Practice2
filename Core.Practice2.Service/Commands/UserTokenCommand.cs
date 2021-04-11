using Core.Practice2.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Practice2.Service.Commands
{
    public class UserTokenCommand: IRequest<UserToken>
    {
    }

    public class UserTokenCommandHandler : IRequestHandler<UserTokenCommand, UserToken>
    {
        public async Task<UserToken> Handle(UserTokenCommand request, CancellationToken cancellationToken)
        {
            // Ideally this should be some token provider service or databse check.
            return new UserToken { Name = "test", Token = "1234-455662-22233333-3333" };
        }
    }
}
