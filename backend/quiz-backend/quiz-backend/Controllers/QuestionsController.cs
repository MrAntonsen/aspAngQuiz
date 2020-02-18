using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizBackend.Models;

namespace QuizBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private readonly QuizContext context;

        public QuestionsController(QuizContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return context.Questions;
        }
        [HttpGet("{quizId}")]
        public IEnumerable<Question> Get([FromRoute] int quizId)
        {
            return context.Questions.Where(q => q.QuizId == quizId);
        }
        // POST api/Questions
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Question question)
        {
            var quiz = context.Quiz.SingleOrDefault(q => q.Id == question.QuizId);
            if (quiz == null)
            {
                return NotFound();
            }
            context.Questions.Add(question);
            await context.SaveChangesAsync();

            return Ok(question);
        }

        //PUT api/Questions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Question question)
        {
            if(id != question.Id)
            {
                return BadRequest();
            }
            context.Entry(question).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return Ok(question);
        }

    }
}