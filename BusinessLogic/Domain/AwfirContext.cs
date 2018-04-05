
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BusinessLogic.Models
{
    public class AwfirContext : DbContext
    {
        
     
        public AwfirContext(): base("myAwfirDB")
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealReview> DealReviews { get; set; }
        public DbSet<DealLike> DealLikes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<DealOrder> DealOrders { get; set; }
        public DbSet<SendGift> SendGifts { get; set; }
        public DbSet<DealCode> DealCodes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<DealRecom> DealRecoms { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                 .HasRequired(c => c.Location)
                 .WithMany()
                 .WillCascadeOnDelete(false);
            modelBuilder.Entity<DealCode>()
               .HasRequired(c => c.Location)
               .WithMany()
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<Deal>()
               .HasRequired(c => c.User)
               .WithMany()
               .WillCascadeOnDelete(false);
            
        }

      

    }           
}