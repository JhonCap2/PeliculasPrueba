using Microsoft.EntityFrameworkCore;
using Peliculas.Core.Entities;
using Peliculas.Core.Interface;
using Peliculas.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MovieContext _context;

        public UsersRepository(MovieContext context)
        { 
            _context = context;
        }

        public async Task<bool> DeleteUsers(int Id)
        {
            var currentuser = await GetUsers(Id);
            _context.Users.Remove(currentuser);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<Users> GetUsers(int Id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserId == Id);
            return user;
        }

        public async Task InsertUsers(Users newUsers)
        {
            await _context.Users.AddAsync(newUsers);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateUsers(Users user)
        {
            var currentmovie = await GetUsers(user.UserId);
            currentmovie.UserName = user.UserName;
            currentmovie.User = user.User;
            currentmovie.UserEmail = user.UserEmail;
            currentmovie.Password = user.Password;


            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
