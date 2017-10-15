using Microsoft.EntityFrameworkCore;

namespace AngularTest2.Models
{
    public class QuotesContext : DbContext
    {
        /// <summary>
        /// <see cref="DbSet{TEntity}"/> que almacena la tabla de 
        /// <see cref="Quote"/> en la base de datos.
        /// </summary>
        public DbSet<Quote> Quotes { get; set; }
        /// <summary>
        /// Realiza tareas de configuración al inicializar este
        /// <see cref="DbContext"/>.
        /// </summary>
        /// <param name="optionsBuilder">
        /// Objeto utilizado para configurar este <see cref="DbContext"/>.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // FIXME: Por alguna razón, SQL LocalDB no permite iniciar sesión.
            // Conector de SQL Server
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=quotesdb;Trusted_Connection=True;Integrated security=True;");

            // Conector de PostgreSQL
            optionsBuilder.UseNpgsql(@"User ID=root;Password=TrustN@12543156;Host=thexds-srv1;Port=5432;Database=quotesdb;Pooling=true;");
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase 
        /// <see cref="QuotesContext"/>.
        /// </summary>
        public QuotesContext()
        {            
            try
            {
                //TODO: implementar función que permita establecer servidores de respaldo.
                Database.EnsureCreated();
            }
            catch
            {
                System.Diagnostics.Debug.Print("ERROR: El servidor SQL parece no estar disponible.");
                // Suprimir errores...
            }
        }
    }
}