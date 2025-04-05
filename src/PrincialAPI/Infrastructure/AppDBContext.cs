﻿using Microsoft.EntityFrameworkCore;
namespace PrincipalAPI.Infrastructure;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}


