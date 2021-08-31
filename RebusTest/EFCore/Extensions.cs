using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebusTest.EFCore.Models;

namespace RebusTest.EFCore
{
    public static class Extensions
    {
        public static async Task<T> FindById<T>(this IQueryable<T> query, T entity) where T : ModelBase
        {
            return await query.FirstOrDefaultAsync(t => t.Id == entity.Id);
        }
    }
}