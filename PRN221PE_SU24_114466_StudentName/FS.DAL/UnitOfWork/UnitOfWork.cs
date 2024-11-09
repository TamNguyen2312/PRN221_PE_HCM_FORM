﻿using ConsultingKoiFish.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.DAL;

namespace ConsultingKoiFish.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MasterDBContext _context;
		private readonly IServiceProvider _serviceProvider;
		private IDbContextTransaction _transaction;
		public UnitOfWork(MasterDBContext masterContext, IServiceProvider serviceProvider)
		{
			_context = masterContext;
			_serviceProvider = serviceProvider;
		}
		public async Task BeginTransactionAsync()
		{
			_transaction = await _context.Database.BeginTransactionAsync();
		}

		public async Task CommitTransactionAsync()
		{
			try
			{
				await _transaction.CommitAsync();
			}
			catch
			{
				await _transaction.RollbackAsync();
			}
			finally
			{
				await _transaction.DisposeAsync();
				_transaction = null!;
			}
		}

		private bool disposed = false;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				this.disposed = true;
			}
		}

		public IRepoBase<T> GetRepo<T>() where T : class
		{
			return _serviceProvider.GetRequiredService<IRepoBase<T>>();
		}

		public async Task RollBackAsync()
		{
			await _transaction.RollbackAsync();
			await _transaction.DisposeAsync();
			_transaction = null!;
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<bool> SaveAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
