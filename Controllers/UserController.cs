//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq.Expressions;
//using tbackendgp.Models;

//using System.Data;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using tbackendgp.Data.IRepository;


//namespace tbackendgp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IDataRepository<User> _userRepository;
//        private readonly IDataRepository<IdentityCard> _identityCardRepository;

//        public UserController(
//            IDataRepository<User> userRepository,
//            IDataRepository<IdentityCard> identityCardRepository
//            )
//        {
//            _userRepository = userRepository;
//            _identityCardRepository = identityCardRepository;
//        }

//        [Authorize(Roles = "Admin")]
//        [HttpGet("users")]
//        public async Task<IActionResult> GetAllUsers([FromQuery] string? search)
//        {
//            return Ok(await _userRepository.GetAllAsync());
//        }

       

//        [Authorize(Roles = "Admin")]
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(int id)
//        {
//            var user = await _userRepository.GetByIdAsync(id);
//            if (user == null)
//            {
//                return NotFound(new
//                {
//                    message = "User not found"
//                });
//            }

//            await _userRepository.DeleteAsync(user);
//            await _userRepository.Save();
//            return Ok(new
//            {
//                message = "User is deleted"
//            });
//        }


        
//    }
//}



//testtt