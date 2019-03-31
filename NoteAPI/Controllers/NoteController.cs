using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteServiceLayer.Models;
using NoteServiceLayer.Services;

namespace NoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IConfiguration configuration ;
        private readonly INoteService service ;


        public NoteController(INoteService serv,IConfiguration con)
        {
            service = serv;
            configuration = con;
        }

        [HttpGet("notes")]
        [Authorize]
        public async Task<ActionResult<List<Note>>> Get ()
        {
            return await service.All();
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddNote(Note note)
        {
            await  service.Add(note);
            return Ok(note);
        }



        [HttpGet("token")]
        public ActionResult Token()
        {

            //создаем токен и отдаем его в ответ
            var jwttoken = JwtTokenBuilder();


            return Ok(new { access_token = jwttoken });
        }




        [NonAction]
        private string JwtTokenBuilder()
        {
            // подготовим ключ и креденшел заранее для удобства
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //создаем токен с временем жизни 15 минут
            var jwttoken = new JwtSecurityToken(
                                                issuer: configuration["JWT:issuer"],
                                                audience: configuration["JWT:audience"],
                                                signingCredentials: credentials,
                                                expires: DateTime.Now.AddMinutes(15)
                                                );

            // вписываем наш токен и посылаем на..куда нам надо
            return new JwtSecurityTokenHandler().WriteToken(jwttoken);

        }









    }
}