﻿using Application.Interfaces;
using Application.Models.Register;
using Application.Models.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RegisterController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(CreateRegisterUserDto registerDto)
        {
            try
            {
                var userDto = _mapper.Map<CreateUserDto>(registerDto);
                var createdUser = await _userService.Create(userDto);
                return Ok("Se ha enviado un correo de verificación. Por favor revisa tu bandeja de entrada.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error durante el registro: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateUserDto userDto)
        {
            await _userService.Update(userDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}