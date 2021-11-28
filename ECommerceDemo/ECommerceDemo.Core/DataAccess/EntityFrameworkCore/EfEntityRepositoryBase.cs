using ECommerceDemo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerceDemo.Core.DataAccess.EntityFrameworkCore
{
	public class EfEntityRepositoryBase<T, TContext> : IBaseRepository<T> where T : class, IEntity ,new() where TContext : DbContext, new()
	{
		public T GetById(int id) {
			using (var context = new TContext()) {
				return context.Set<T>().Find(id);
			}
		}

		public T Get(Expression<Func<T, bool>> filter) {
			using (var context = new TContext()) {
				return context.Set<T>().SingleOrDefault(filter);
			}
		}

		public List<T> GetAll(Expression<Func<T, bool>> filter = null) {
			using (var context = new TContext()) 
			{
				return filter == null ?
					context.Set<T>().ToList() :
					context.Set<T>().Where(filter).ToList();
			}
		}

		public T Add(T entity) {
			using (var context = new TContext()) 
			{
				var addedEntity = context.Set<T>().Add(entity);
				context.SaveChanges();
				return entity;
			}
		}

		public T Update(T entity) {
			using (var context = new TContext()) {
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				context.SaveChanges();
				return entity;
			}
		}

		public void Delete(T entity) {
			using (var context = new TContext()) {
				var deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

	}
}
