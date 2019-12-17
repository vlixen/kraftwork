using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LaBlisteria.Models
{
    public class CuentaDbContext : DbContext
    {
        public DbSet <CuentaUsuario> CuentaUsuario { get; set; }
    }
}