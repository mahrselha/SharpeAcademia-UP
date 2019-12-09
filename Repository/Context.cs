using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository {
    public class Context : IdentityDbContext<UsuarioLogado>
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Treino> Treinos { get; set; }        
        public DbSet<Exercicios> Exercicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
