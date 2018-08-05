using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentSystem.DTO;
using StudentSystem.API.Models;

namespace StudentSystem.API.AppSettings
{
    public class AutomapperConfig: Profile
    {
        public AutomapperConfig()
        {
            CreateMap<RegisterUserDTO, RegisterRequestApiModel>();
        }
    }
}
