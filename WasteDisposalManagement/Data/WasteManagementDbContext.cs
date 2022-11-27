using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace WasteDisposalManagement.Models;


public partial class WasteManagementDbContext : IdentityDbContext<User>
{
    public WasteManagementDbContext()
    {
    }

    public WasteManagementDbContext(DbContextOptions<WasteManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<Card>? Cards { get; set; }

    public DbSet<FirstTimeOrder>? FirstTimeOrders { get; set; }

    public DbSet<Order>? Orders { get; set; }

    public DbSet<Service>? Services { get; set; }
    public IEnumerable<User> Users { get; set; }
}
