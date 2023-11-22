
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Text.Json;
using Service;
using Entities;
using Repository;
using DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstWebApiHw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IMapper _mapper;

        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [Route("UserNameAndPassword")]
        // GET: api/<user>
        [HttpPost]
        public async Task<ActionResult<UserIdDto>> Post([FromBody] UserNameAndPassword userNameAndPassword )
        {
            try
            {
            User user = await _userService.getUserByUserNameAndPassword(userNameAndPassword.UserName, userNameAndPassword.Password);
                UserIdDto UserIdDto = _mapper.Map<User, UserIdDto>(user);
                return user != null ? Ok(UserIdDto) : Unauthorized();
            }
             catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        // POST api/<user>
        [HttpPost]
        public async  Task<ActionResult<User>> Post([FromBody] UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<UserDto,User>(userDto);
                User newUser = await _userService.createNewUser(user);
                return newUser != null ?CreatedAtAction(nameof(Get), new { id = userDto.UserId }, userDto) : BadRequest();
            }
            catch (Exception ex)
            {

               throw new Exception(ex.Message);
            }
        }

        // PUT api/<user>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserIdDto>> Put(int id, [FromBody] UserDto userToUpdate)
        {
            try
            {
                User UserToUpdateDto = _mapper.Map<UserDto, User>(userToUpdate);
                User updateUser = await _userService.update(id, UserToUpdateDto);
                UserIdDto UpdateUserId = _mapper.Map<User, UserIdDto>(updateUser);
                return UpdateUserId != null ? Ok(UpdateUserId) : BadRequest("user didnt found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        //GETuserById api/<user>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get( int id)
        {
            try
            {
                User user = await _userService.getUserById(id);
                return user != null ?  Ok(user) :  BadRequest("user didnt found");               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("password")]
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            var result = _userService.checkPassword(password);
            return result < 2 ? BadRequest("Password is too weak") : Ok(result);
        }

    }

    }
