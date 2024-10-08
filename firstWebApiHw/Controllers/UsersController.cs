﻿
using Microsoft.AspNetCore.Mvc;
using Entities;
using DTO;
using AutoMapper;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstWebApiHw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IMapper _mapper;
        ILogger<UsersController> _logger;

        public UsersController(IUserService userService,IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }
        [Route("login")]
        // GET: api/<user>//=======login;
        [HttpPost]
        public async Task<ActionResult<UserIdNameDto>> Get([FromBody] UserLoginDto userLoginDto)
        {
                User userLogin = _mapper.Map<UserLoginDto, User>(userLoginDto);
                User user = await _userService.getUserByUserNameAndPasswordAsync(userLoginDto.UserName, userLoginDto.Password);
                UserIdNameDto UserIdDto = _mapper.Map<User, UserIdNameDto>(user);
                _logger.LogInformation("Login to user {0} and password {1}", userLoginDto.UserName, userLoginDto.Password);
                return user != null ? Ok(UserIdDto) : Unauthorized();
        }

       
        // POST api/<user>//=======register;
        [HttpPost]
        public async  Task<ActionResult<UserIdNameDto>> Post([FromBody] UserDto userDto)
        {
            
                User user = _mapper.Map<UserDto,User>(userDto);
                User newUser = await _userService.createNewUserAsync(user);
                return newUser != null ?CreatedAtAction(nameof(Get), new { id = userDto.UserId }, userDto) : BadRequest();
           
        }

        // PUT api/<user>/5 //=======update;
        [HttpPut("{id}")]
        public async Task<ActionResult<UserIdNameDto>> Put(int id, [FromBody] UserDto userToUpdateDto)
        {
           
                User userToUpdate = _mapper.Map<UserDto, User>(userToUpdateDto);
                User updateUser = await _userService.updateAsync(id, userToUpdate);
                UserIdNameDto userIdNameDto = _mapper.Map<User, UserIdNameDto>(updateUser);
                return userIdNameDto != null ? Ok(userIdNameDto) : BadRequest("user didnt found");
         

        }
        //GETuserById api/<user>/5 //=======getUserById
        [HttpGet("{id}")]
        public async Task<ActionResult<UserIdNameDto>> Get(int id)
        {
                User user = await _userService.getUserByIdAsync(id);
                UserIdNameDto userIdNameDto = _mapper.Map<User, UserIdNameDto>(user);
                return user != null ?  Ok(userIdNameDto) :  BadRequest("user didnt found");               
        }

        [Route("password")]
        [HttpPost]  //=======checkSrengthPassword;
        public ActionResult<int> checkPassword([FromBody] string password)
        {
            var result = _userService.checkPassword(password);
            return result < 2 ? BadRequest("Password is too weak") : Ok(result);
        }

    }

    }
