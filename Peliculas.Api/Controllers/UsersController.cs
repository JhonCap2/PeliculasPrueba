using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.Api.Response;
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
            var response = new ApiResponse<IEnumerable<UsersDto>>(usersDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _usersRepository.GetUsers(id);
            var usersDto = _mapper.Map<UsersDto>(user);
            var response = new ApiResponse<UsersDto>(usersDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser(Users newuser)
        { 
            await _usersRepository.InsertUsers(newuser);
            var usersDto = _mapper.Map<UsersDto>(newuser);
            var reponse = new ApiResponse<UsersDto>(usersDto);
            return Ok(reponse);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UsersDto upuser)
        { 
            var user = _mapper.Map<Users>(upuser);
            await _usersRepository.UpdateUsers(user);
            var reponse = new ApiResponse<Users>(user);
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _usersRepository.DeleteUsers(id);
            return Ok(user);
        }
    }
}
