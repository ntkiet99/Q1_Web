using System.Data.Entity;

namespace QuanLyDatNen.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=ConnectionString")
        {
        }
        public DbSet<Nen> Nens { get; set; }
    }
}