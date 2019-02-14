using System;
using System.Collections.Generic;
using System.Text;
using Her.Domain.Entities;

namespace Her.Repository.User
{
    public class UserRepository: SqlRepository<Domain.Entities.ApplicationUser>, IUserRepository
    {
    }
}
