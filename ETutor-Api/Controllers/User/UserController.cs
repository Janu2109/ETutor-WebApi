﻿using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryAsync userRepositoryAsync;
        public UserController(IUserRepositoryAsync userRepositoryAsync)
        {
            this.userRepositoryAsync = userRepositoryAsync;
        }

        #region GET

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await userRepositoryAsync.Select(username, password);

            if (null == user)
            {
                return BadRequest("Incorrect login details");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Select_All()
        {
            var users = await userRepositoryAsync.Select_All();

            if (users.Count < 0 || null == users)
            {
                return BadRequest("Error fetching users");
            }
            else
            {
                return Ok(users);
            }
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string userName, string password, string firstName, string lastName, long idNo, string city, string email)
        {
            int user = await userRepositoryAsync.Insert(userName, password, firstName, lastName, idNo, city, email);

            return Ok(user);
        }

        #endregion

    }
}
