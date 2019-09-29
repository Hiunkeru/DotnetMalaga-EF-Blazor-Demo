using BlazorApp1.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.DataAccess.Contracts
{
    public interface IDemoContext
    {
        DbSet<Warrior> Warrior { get; set; }
    }
}
