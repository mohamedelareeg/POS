﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POS.Domain.Models;
using POS.Domain.Models.Payments;
using POS.Domain.Models.Payments.PaymentMethods;
using POS.Domain.Models.Products;
using POS.Persistence.Configurations;
using POS.Persistence.Models;

namespace POS.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<ReadyProduct> ReadyProducts { get; set; }
        public DbSet<ReadyProductItem> ReadyProductItems { get; set; }


        public DbSet<PriceQuotation> PriceQuotations { get; set; }
        public DbSet<QuotedProduct> QuotedProducts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePayment> InvoicePayments { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }


        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchasePayment> PurchasePayments { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        public DbSet<Expenses> Expenses { get; set; }


        public DbSet<Cash> Cashes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Cheque> Cheques { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Determine the path to your SQLite database file
            string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database");

            // Create directory if it doesn't exist
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            // Set up the SQLite connection
            optionsBuilder.UseSqlite($"Data Source={dbDirectory}\\pos.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync();
            return result;
        }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLogs || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (propertyName == "ModifiedBy" && property.CurrentValue != null)
                    {
                        auditEntry.UserId = property.CurrentValue.ToString();
                    }
                    else if (propertyName == "ModifiedBy" && property.OriginalValue != null)
                    {
                        auditEntry.UserId = property.OriginalValue.ToString();
                    }

                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }
    }

}

