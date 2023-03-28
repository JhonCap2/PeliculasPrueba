using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.Core.DTOs;
using Peliculas.Core.Entities;
using Peliculas.Core.Interface;
using Peliculas.Infraestructure.Data;
using Peliculas.Infraestructure.Repositories;

namespace Peliculas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        
        private IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersRepository.GetUsers();
            var usersDto = _mapper.Map<IEnumerable<UsersDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _usersRepository.GetUsers(id);
            var usersDto = _mapper.Map<UsersDto>(user);
            return Ok(usersDto);
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser(Users newuser)
        { 
            await _usersRepository.InsertUsers(newuser);
            var usersDto = _mapper.Map<UsersDto>(newuser);
            return Ok(usersDto);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UsersDto upuser)
        { 
            var user = _mapper.Map<Users>(upuser);
            await _usersRepository.UpdateUsers(user);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _usersRepository.DeleteUsers(id);
            return Ok(user);
        }
    }
}
