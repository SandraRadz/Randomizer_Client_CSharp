﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomizer_Client.Models;

namespace Randomizer_Client.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool UserExists(string login);

        User GetUserByLoginAndPassword(string login, string password);

        void AddUser(User user);

    }
}