using AmanatakBLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace AmanatakBLL
{
    public class AmanatakContext : DbContext
    {
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<History> History { get; set; }

        public DbSet<TestClass> TestClass { get; set; }

        public DbSet<ItemOwner> ItemOwner { get; set; }
        public DbSet<IdentificationType> IdentificationType { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<ConversationMessages> ConversationMessages { get; set; }



        public override int SaveChanges()
        {
            UpdateDateFields();

            return base.SaveChanges();
        }
        private void UpdateDateFields()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
 



            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                     ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow.AddHours(3);
                    ((BaseEntity)entity.Entity).UserCreated = "Operator1";
                    ((BaseEntity)entity.Entity).DateModified = null;
                    ((BaseEntity)entity.Entity).UserModified = null;
                    



               
                }

                 ((BaseEntity)entity.Entity).DateModified = DateTime.UtcNow.AddHours(3);
                ((BaseEntity)entity.Entity).UserModified = "Operator1"; ;
            }
        }

        public System.Data.Entity.DbSet<AmanatakBLL.Models.Country> Countries { get; set; }
    }


}
