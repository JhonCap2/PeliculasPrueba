using AutoMapper;
using Peliculas.Core.DTOs;
using Peliculas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();

            CreateMap<Classifications, ClassificationsDto>();
            CreateMap<ClassificationsDto, Classifications>();

            CreateMap<Movies, MoviesDto>();
            CreateMap<MoviesDto, Movies>();
        }
    }
}
