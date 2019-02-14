using System;
using System.Collections.Generic;
using System.Text;
using Her.Domain.Entities;

namespace Her.Repository.User
{
    public interface IUserRepository: ISqlRepository<Domain.Entities.ApplicationUser>
    {
    }
}
