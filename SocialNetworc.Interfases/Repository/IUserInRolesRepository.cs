﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialNetwork.Core;
using SocialNetwork.Interfases.Repository;

namespace SocialNetwork.Interfases.Repository
{
    public interface IUserInRolesRepository<T> : IRepository<T> where T : UserInRoles
    {

    }
}
