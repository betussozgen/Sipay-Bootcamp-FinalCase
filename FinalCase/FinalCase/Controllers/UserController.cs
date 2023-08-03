
using AutoMapper;
using FinalCase.Command.UserCommand;
using FinalCase.DBOperations;
using FinalCase.Validator.UserValidator;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static FinalCase.Command.UserCommand.CreateUserCommand;
using static FinalCase.Command.UserCommand.UpdateUserCommand;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalCase.Controllers
{

    [ApiController]
    [Route("[controller]s")]

    public class UserController : ControllerBase
    {

        private readonly SiteManagementDbContext _context;
        private readonly IMapper _mapper;

        public UserController(SiteManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            GetUsersQuery query = new GetUsersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        //
        [HttpGet("{tc}")]
        public IActionResult GetUserId(string tc)
        {
            UserDetailViewModel result;
            try
            {
                GetUserDetailQuery query = new GetUserDetailQuery(_context, _mapper);
                query.UserTcNo = tc;
                GetUserDetailQueryValidator validator = new GetUserDetailQueryValidator();
                validator.ValidateAndThrow(query);

                result = query.Handle();
            }
            catch (Exception ex)  
            { 
                return BadRequest(ex.Message);  
            
            }
            return Ok(result);
           
        }

        //Post
        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);

            try
            {
                command.Model = newUser;
                CreateUserCommandValidator validator = new CreateUserCommandValidator();
                validator.ValidateAndThrow(command);



                command.Handle();

            }catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            
            }
            return Ok();
        }



        //Put
        [HttpPut("{tc}")]
        public IActionResult UpdateUser(string tc, [FromBody] UpdateUserModel updatedBook)
        {
            try
            {
                UpdateUserCommand command = new UpdateUserCommand(_context);
                command.UserTcNo = tc;
                command.Model = updatedBook;

                UpdateUserCommandValidator validator = new UpdateUserCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();


        }

        //Delete
        [HttpDelete("{tc}")]
        public IActionResult DeleteUserTC(string tc)
        {
            try
            {
                DeleteUserCommand command = new DeleteUserCommand(_context);
                command.UserTcNo = tc;
                DeleteUserCommandValidator validator = new DeleteUserCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

     }
}
