using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Areas.Identity.Data;

namespace ProjetoMVC.Data;

public class ProjetoMVCContext : IdentityDbContext<UsuarioModel>
{
    public ProjetoMVCContext(DbContextOptions<ProjetoMVCContext> options)
        : base(options)
    {
    }

    [Authorize]
    public class DataManagementModel : PageModel
    {
        public void OnGet()
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
