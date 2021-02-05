using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Security;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.UpdateUserRole
{
  [AuthorizeAttribute(Domain.Enums.Action.UPDATE_USER)]
  public class UpdateUserRolesCommand : IRequest<UserRoleDto>
  {
    public UserRoleDto User { get; set; }

    public class UpdateUserRolesCommandHandler : IRequestHandler<UpdateUserRolesCommand, UserRoleDto>
    {
      private readonly IApplicationDbContext _context;

      public UpdateUserRolesCommandHandler(IApplicationDbContext context)
      {
        _context = context;
      }

      public async Task<UserRoleDto> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
      {
        var userEntity = await _context.Users
          .Include(x => x.Roles)
          .ThenInclude(x => x.Role)
          .Where(x => x.Username.Equals(request.User.Username))
          .FirstOrDefaultAsync(cancellationToken);
        if (userEntity == null)
        {
          throw new ArgumentException("Username doesn't exist");
        }

        var roleEntity = await _context.Roles
          .Where(x => x.Name.Equals(request.User.Role))
          .FirstOrDefaultAsync(cancellationToken);
        if (roleEntity == null)
        {
          throw new ArgumentException("No such role.");
        }

        var userRole = await _context.UserRoles
          .Where(x => x.UserId == userEntity.Id)
          .FirstOrDefaultAsync(cancellationToken);

        if (userRole != null)
        {
          userRole.Role = roleEntity;
          _context.UserRoles.Update(userRole);
        }
        else
        {
          userRole = new UserRole
          {
            User = userEntity,
            Role = roleEntity
          };
          _context.UserRoles.Add(userRole);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return request.User;
      }
    }
  }
}
