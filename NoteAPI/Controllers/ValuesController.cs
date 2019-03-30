using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteServiceLayer.Models;
using NoteServiceLayer.Services;

namespace NoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly INoteService nservise;

        public ValuesController(INoteService service)
        {
            nservise = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("note")]
        public ActionResult<List<Note>> All()
        {
            return nservise.All();
        }
        
        [HttpPost("add")]
        public async Task<ActionResult> AddNote(Note note)
        {
           await nservise.Add(note);
           return Ok(note);
        }
    }
}
