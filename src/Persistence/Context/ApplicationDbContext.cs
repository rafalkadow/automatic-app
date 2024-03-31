using Domain.Interfaces;
using Domain.Modules.Base.Models;
using Domain.Modules.PlcDriverGroup.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Enums;
using Persistence.Helpers;
using Shared.Interfaces;
using Shared.Helpers;
using Domain.Modules.PlcDriver.Models;
using Microsoft.Extensions.Logging;
using Domain.Modules.PlcParameterHistory.Models;
using Domain.Modules.PlcParameter.Models;
using Domain.Modules.DictionaryOfParameterInterval.Models;
using Domain.Modules.DictionaryOfParameterCategory.Models;
using Domain.Modules.PlcDriverAlarm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Modules.Identity;
using Application.Common.Interfaces;
using Domain.Modules.Account;

namespace Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, RoleClaim, IdentityUserToken<string>>, IDbContext
    {
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AccountModel> Account { get; set; }
        public DbSet<PlcDriverGroupModel> PlcDriverGroup { get; set; }
        public DbSet<PlcDriverModel> PlcDriver { get; set; }
        public DbSet<DictionaryOfParameterIntervalModel> DictionaryOfParameterInterval { get; set; }

        public DbSet<DictionaryOfParameterCategoryModel> DictionaryOfParameterCategory { get; set; }

        public DbSet<PlcParameterModel> PlcParameter { get; set; }
        public DbSet<PlcParameterHistoryModel> PlcParameterHistory { get; set; }

        public DbSet<PlcDriverAlarmModel> PlcDriverAlarm { get; set; }


        private ILogger<ApplicationDbContext> _logger { get; set; }

        private IUserAccessor _userAccessor { get; set; }
        /// <summary>
        /// Constructor class.
        /// </summary>
        public ApplicationDbContext(DbContextOptions options, ILogger<ApplicationDbContext> logger, IUserAccessor userAccessor)
            : base(options)
        {
            _logger = logger;
            _userAccessor = userAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //kodowanie duże znaki - porównywanie w sql
            modelBuilder.UseCollation("SQL_Latin1_General_CP1250_CS_AS");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                // EF Core 5
                property.SetPrecision(18);
                property.SetScale(6);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
            base.OnModelCreating(modelBuilder);

            //UTC Time
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.FromDefaultTimeZoneToUtc(),
                v => DateTime.SpecifyKind(v.FromUtcToDefaultTimeZone(), DateTimeKind.Local));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? v.Value.FromDefaultTimeZoneToUtc() : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value.FromUtcToDefaultTimeZone(), DateTimeKind.Local) : v);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {

                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(nullableDateTimeConverter);
                    }
                }
            }
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Enum>()
                .HaveConversion<string>();
        }
        public IQueryable<TEntity> GetQueryable<TEntity>()
                where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
        }

        public async Task CreateAsync<TEntity>(TEntity entity, IUserAccessor userAccessor)
            where TEntity : class, IEntity
        {
            _userAccessor = userAccessor;
            await this.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
            this.Entry(entity).State = EntityState.Detached;
            await Task.CompletedTask;
        }

        public async Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
            this.Entry(entity).State = EntityState.Detached;
            await Task.CompletedTask;
        }

        public Task DetachedAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Entry(entity).State = EntityState.Detached;
            return Task.CompletedTask;
        }

        public async Task UpdatePropertiesAsync<TEntity>(TEntity entity, ICommand command, IUserAccessor userAccessor)
            where TEntity : class, IEntity
        {
            _userAccessor = userAccessor;
            //this.Entry(entity).State = EntityState.Detached;

            this.Entry(entity).CurrentValues.SetValues(command);
            this.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            this.Entry(entity).State = EntityState.Detached;

            await Task.CompletedTask;
        }

        public Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync<TEntity>(IList<TEntity> entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().RemoveRange(entity);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOnDateTimeUTC = DateTime.UtcNow;
                        entry.Entity.CreatedUserId = _userAccessor.UserGuid;
                        entry.Entity.CreatedUserName = _userAccessor.UserName;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedOnDateTimeUTC = DateTime.UtcNow;
                        entry.Entity.ModifiedUserId = _userAccessor.UserGuid;
                        entry.Entity.ModifiedUserName = _userAccessor.UserName;
                        break;
                }
            }

            if (_userAccessor != null && _userAccessor.UserGuid != Guid.Empty)
                await AuditLogging();

            await base.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await this.Database.BeginTransactionAsync();
        }

        public Task CommitTransactionAsync()
        {
            this.Database.CommitTransaction();
            return Task.CompletedTask;
        }
        public Task RollbackTransactionAsync()
        {
            this.Database.RollbackTransaction();
            return Task.CompletedTask;
        }

        public Task<bool> HasChangesAsync()
        {
            return Task.FromResult(this.ChangeTracker.HasChanges());
        }

        private async Task AuditLogging()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                System.ComponentModel.DataAnnotations.Schema.TableAttribute tableAttr = entry.Entity.GetType().GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute), false).FirstOrDefault() as System.ComponentModel.DataAnnotations.Schema.TableAttribute;

                string tableName = tableAttr != null ? tableAttr.Name : entry.Entity.GetType().Name;

                if (tableAttr != null) 
                    tableName = tableAttr.Name;
                else
                    tableName = entry.Entity.GetType().Name;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = tableName,
                    UserId = _userAccessor.UserGuid,
                    UserName = _userAccessor.UserName
                };

                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    var propertyName = property.Metadata.Name;
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
                await Audits.AddAsync(auditEntry.ToAudit());
            }
        }
    }
}
