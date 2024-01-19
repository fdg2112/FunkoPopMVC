using Data;
using Enities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class UserLogic
    {
        private readonly UserData objUser = new UserData();

        public List<User> GetList()
        {
            return objUser.GetList();
        }
    }
}
