
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Text.Json;
using Service;
using Entities;
using Repository;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstWebApiHw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserService userService = new UserService();
        // GET: api/<user>
        [HttpGet]
        public ActionResult<User> Get([FromQuery] string UserName, [FromQuery] string Password)
        {
            try
            {
            User user = userService.getUserByUserNameAndPassword(UserName, Password);
            if (user != null)
                return Ok(user);
            else return BadRequest();
            }
             catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // POST api/<user>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                User newUser = userService.createNewUser(user);
                if (newUser != null)
                    return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
                else return BadRequest();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        // PUT api/<user>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] User userToUpdate)
        {
            try
            {
                var result = userService.checkPassword(userToUpdate.Password);
                if (result < 2)
                    return BadRequest(result);
                else
                {
                    userService.update(id, userToUpdate);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        //// DELETE api/<user>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //} 

        [Route("password")]
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            var result = userService.checkPassword(password);
            if (result < 2)
                return BadRequest(result);
            else
                return Ok(result);
        }

    }

    }
