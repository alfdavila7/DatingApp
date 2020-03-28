using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    //Code first aproach in entity framework. 
    //It will tell the entity framework about this entity. So that it can create a table for this particular class
    //For the DbContext class we need to add a reference in the DatingApp.API.csproj

    //Install NuGet package Microsoft.EntityFrameworkCore
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        //Tell our DataContext about our entities
        public DbSet<Value> Values {get;set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}