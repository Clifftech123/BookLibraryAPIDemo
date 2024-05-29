
using BookLibraryAPIDemo.Application.Exceptions;
using BookLibraryAPIDemo.Infrastructure.Context;
using BookLibraryAPIDemo.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPIDemo.Infrastructure.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BookLibraryContext _context;

        public BaseRepository(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred while creating the entity.", ex);
            }
        }

        public async Task<T> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred while deleting the entity.", ex);
            }
        }

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<List<T>> GetAllBookAsync(ISpecification<T> spec = null)
        {

            var query = _context.Set<T>().AsQueryable();

            if (spec != null)
            {
                if (spec.Criteria != null)
                {
                    query = query.Where(spec.Criteria);
                }

                if (spec.Includes != null)
                {
                    foreach (var include in spec.Includes)
                    {
                        query = query.Include(include);
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("An error occurred while updating the entity.", ex);
            }
        }
    }


}