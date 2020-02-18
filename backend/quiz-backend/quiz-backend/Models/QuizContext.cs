﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizBackend.Models;

namespace QuizBackend.Models
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizBackend.Models.Quiz> Quiz { get; set; }
    }
}
