using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace WasteDisposalManagement.Models;


public class WasteManagementDbContext : IdentityDbContext<User>
{
    public WasteManagementDbContext()
    {
    }

    public WasteManagementDbContext(DbContextOptions<WasteManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<Card> Cards { get; set; } = null!; 

    public DbSet<FirstTimeOrder> FirstTimeOrders { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;   

    public DbSet<Service> Services { get; set; } = null!;
    public IEnumerable<User> Users { get; set; } = null!;
    public object Card { get; internal set; }
}
