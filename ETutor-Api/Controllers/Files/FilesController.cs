﻿using ETutor_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ETutor_Api.Controllers.Files
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesRepositoryAsync filesRepositoryAsync;
        public FilesController(IFilesRepositoryAsync filesRepositoryAsync)
        {
            this.filesRepositoryAsync = filesRepositoryAsync;
        }

        #region POST

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Register(string name, int moduleId, int userId)
        {
            int file = await filesRepositoryAsync.Insert(name, moduleId, userId);

            return Ok(file);
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete_File(int fileId)
        {
            int file = await filesRepositoryAsync.Delete_File(fileId);

            return Ok(file);
        }

        #endregion

        #region GET

        [HttpGet]
        [Route("lecture")]
        public async Task<IActionResult> Login(int lectureId)
        {
            var user = await filesRepositoryAsync.Select_Lecture(lectureId);

            if (null == user)
            {
                return BadRequest("No records found");
            }
            else
            {
                return Ok(user);
            }
        }

       

        [HttpGet]
        [Route("module")]
        public async Task<IActionResult> Moudle(int moduleId)
        {
            var user = await filesRepositoryAsync.Select_Module(moduleId);

            if (null == user)
            {
                return BadRequest("No records found");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet]
        [Route("download")]
        public async Task<IActionResult> File(string name)
        {
            string Filename = name;
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\\Users\\Janu Fourie\\Desktop\\WebApp\\Files\\" + Filename);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Filename);
        }
        #endregion

    }
}
