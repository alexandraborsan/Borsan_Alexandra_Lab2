﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Borsan_Alexandra_Lab2.Models;

namespace Borsan_Alexandra_Lab2.Data
{
    public class Borsan_Alexandra_Lab2Context : DbContext
    {
        public Borsan_Alexandra_Lab2Context (DbContextOptions<Borsan_Alexandra_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Borsan_Alexandra_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Borsan_Alexandra_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Borsan_Alexandra_Lab2.Models.Author>? Author { get; set; }
    }
}
