using Microsoft.EntityFrameworkCore;
using AdminPortal.Entities;
namespace AdminPortal.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options){

        }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<AdminDTO> Admins { get; set; }
    }
}