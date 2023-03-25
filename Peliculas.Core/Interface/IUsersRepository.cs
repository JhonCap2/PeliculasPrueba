using Peliculas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Core.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>>GetUsers();
        Task<Users> GetUsers(int Id);
        Task InsertUsers(Users newUsers);
        Task <bool> UpdateUsers(Users users);
        Task <bool> DeleteUsers(int Id);
    }
}
