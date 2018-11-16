namespace Course_kepeer_1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class First_model : DbContext
    {
        public First_model()
            : base("name=First_model")
        {
        }

        public virtual DbSet<Resource_info> Resource_info { get; set; }
        public virtual DbSet<User_info> User_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_info>()
                .HasMany(e => e.Resource_info)
                .WithOptional(e => e.User_info)
                .HasForeignKey(e => e.User_id);
        }
    }
}
