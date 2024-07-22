using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Shared.Extensions.DataExtension;

using Microsoft.EntityFrameworkCore;

namespace FundacionAMA.Infrastructure.Persistence.Repository
{
    /// <summary>
    /// Contexto para la base de datos del proyecto FundacionAMA
    /// </summary>
    public class FundacionAMADbContext : DbContext
    {
        /// <summary>
        /// Constructor del contexto
        /// </summary>
        /// <param name="options"></param>
        public FundacionAMADbContext(DbContextOptions<FundacionAMADbContext> options) : base(options)
        {
            Database.Migrate();
        }

        /// <summary>
        /// Clase Person tiene tabla person en la db
        /// </summary>
        public virtual DbSet<Person> person { get; set; }
        /// <summary>
        /// Clase User tiene tabla user en la db
        /// </summary>
        public virtual DbSet<User> user { get; set; }
        /// <summary>
        /// Clase Cliente tiene tabla cliente en la db
        /// </summary>
        public virtual DbSet<Cliente> cliente { get; set; }
        /// <summary>
        /// Clase Grupo tiene tabla grupo en la db
        /// </summary>
        public virtual DbSet<Grupo> grupo { get; set; }
        /// <summary>
        /// Clase GrupoCliente tiene tabla grupoCliente en la db
        /// </summary>
        public virtual DbSet<GrupoCliente> grupoCliente { get; set; }

        /// <summary>
        /// Metodo para guardar lo cargado
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            SetAuditoria();
            return base.SaveChanges();
        }

        /// <summary>
        /// Metodo asincronico para guardar lo cargado
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditoria();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditoria()
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    _ = entry.SetProperty("UpdatedAt", DateTime.UtcNow)

                        .SetProperty("Status", "A");

                }

                if (entry.State == EntityState.Added)
                {
                    _ = entry.SetProperty("CreatedAt", DateTime.UtcNow)

                    .SetProperty("Active", true)
                    .SetProperty("Status", "A");
                }
            }
        }
        /// <summary>
        /// Forma de crear el modelo datos adicionales
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(FundacionAMADbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}