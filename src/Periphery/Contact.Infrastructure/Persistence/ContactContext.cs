using Contact.Domain.Common;
using Contact.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Persistence
{
	public class ContactContext : DbContext
	{
		public DbSet<ContactEntity> Contacts { get; set; }

		public ContactContext(DbContextOptions<ContactContext> Options) : base(Options)
		{
			
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			SetTracker();
			return base.SaveChangesAsync(cancellationToken);
		}

		private void SetTracker()
		{
			IEnumerator<EntityEntry<EntityBase>> enumrator = ChangeTracker.Entries<EntityBase>().GetEnumerator();
			while (enumrator.MoveNext())
			{
				EntityEntry<EntityBase> item = enumrator.Current;
				switch (item.State)
				{
					case EntityState.Added:
						item.Entity.CreatedDate = DateTime.Now;
						item.Entity.CreatedBy = "EMPTY-VALUE";
						break;
					case EntityState.Modified:
						item.Entity.LastModifiedDate = DateTime.Now;
						item.Entity.LastModifiedBy = "EMPTY-VALUE";
						break;
				}
			}
		}

	}
}
