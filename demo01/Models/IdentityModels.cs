using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace demo01.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string PostalCode { get; set; }
        public string PhonePrimary { get; set; }
        public string PhoneSecondary { get; set; }
        public string DataDeNascimento { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Usuario").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuario").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("RegraDeUsuario");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("LoginDeUsuario");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("SolicitacoesDeUsuario");
            modelBuilder.Entity<IdentityRole>().ToTable("Regras");
        }
    }
}