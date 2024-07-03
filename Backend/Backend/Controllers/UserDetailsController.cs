using Backend.Dtos;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailRepository _userDetailRepository;

        public UserDetailsController(IUserDetailRepository userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
            var userDetails = await _userDetailRepository.GetAll();
            return Ok(userDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
            var userDetail = await _userDetailRepository.GetById(id);
            if (userDetail == null)
            {
                return NotFound();
            }
            return Ok(userDetail);
        }

        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetailCreateDto request)
        {
            var userDetail = new UserDetail
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Username = request.Username,
                Password = request.Password
            };

            await _userDetailRepository.Add(userDetail);
            await _userDetailRepository.SaveChanges();

            return Ok(userDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetail(int id, UserDetailUpdateDto request)
        {
            var existingUserDetail = await _userDetailRepository.GetById(id);
            if (existingUserDetail == null)
            {
                return NotFound();
            }

            existingUserDetail.Firstname = request.Firstname;
            existingUserDetail.Lastname = request.Lastname;
            existingUserDetail.Username = request.Username;
            existingUserDetail.Password = request.Password;

            _userDetailRepository.Update(existingUserDetail, id);
            await _userDetailRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetail(int id)
        {
            var userDetail = await _userDetailRepository.GetById(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _userDetailRepository.Remove(id);
            await _userDetailRepository.SaveChanges();

            return NoContent();
        }
    }
}
