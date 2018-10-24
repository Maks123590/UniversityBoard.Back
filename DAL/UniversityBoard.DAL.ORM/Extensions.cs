using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UniversityBoard.DAL.ORM
{
    public static class Extensions
    {
        public static async Task AddOrUpdate<T>(this DbSet<T> dbSet, T data) where T : class
        {
            var t = typeof(T);
            PropertyInfo keyField = null;

            foreach (var propt in t.GetProperties())
            {
                var keyAttr = propt.GetCustomAttribute<KeyAttribute>();
                if (keyAttr != null)
                {
                    keyField = propt;
                    break; // assume no composite keys
                }
            }

            if (keyField == null)
            {
                throw new Exception($"{t.FullName} does not have a KeyAttribute field. Unable to exec AddOrUpdate call.");
            }

            var keyVal = keyField.GetValue(data);

            var dbVal = await dbSet.FindAsync(keyVal);

            if (dbVal != null)
            {
                dbSet.Update(data);
                return;
            }

            await dbSet.AddAsync(data);
        }
    }
}