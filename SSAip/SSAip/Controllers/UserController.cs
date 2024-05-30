﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSAip.DTO;
using SSAip.Interfaces;

namespace SSAip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository , IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var list = _mapper.Map<List<UserDTO>>(_repository.GetAll());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(list);

        }
        [HttpGet]
        [Route("GetUserByName")]
        public IActionResult GetUserByName(string name)
        {
            var list = _mapper.Map<List<UserDTO>>(_repository.GetUserByName(name));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(list);

        }
        [HttpGet]
        [Route("GetUserByID")]
        public IActionResult GetUserByID(string id)
        {
            var user = _mapper.Map<List<UserDTO>>(_repository.GetById(id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(user );

        }
        [HttpGet]
        [Route("GetUserLogin")]
        public IActionResult GetUserLogin(string email,string pass)
        {
            var user = _mapper.Map<UserDTO>(_repository.CheckAccound(email, pass));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(user);

        }

        [HttpGet]
        [Route("GetUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _mapper.Map<UserDTO>(_repository.GetByEmail(email));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(user);    
        }

        [HttpPut]
        [Route("PutUser")]
        public IActionResult PutUser(UserDTO u)
        {
            var up = _repository.UpdateUser(u);
            if (up==false) return BadRequest(ModelState);

            return Ok();

        }

    }
}
