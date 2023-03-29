using Microsoft.EntityFrameworkCore;
using Peliculas.Core.Entities;
using Peliculas.Core.Interface;
using Peliculas.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Infraestructure.Repositories
{
    public class ClassificationRepository : IClassificationRepository
    {
        private readonly MovieContext _context;
        public ClassificationRepository(MovieContext context)
        {
            _context = context;

        }
        public async Task<bool> DeleteClassification(int id)
        {
            var currentclassification = await GetClassification(id);
            _context.Classifications.Remove(currentclassification);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Classifications>> GetClassifications()
        {
            var classifications = await _context.Classifications.ToListAsync();
            return classifications;
        }

        public async Task<Classifications> GetClassification(int id)
        {
            var clasification = await _context.Classifications.SingleOrDefaultAsync(x =>x.IdClassification == id);
            return clasification;
        }

        public async Task InsertClassification(Classifications newclassifications)
        {
            await _context.Classifications.AddAsync(newclassifications);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateClassification(Classifications classifications)
        {
            var currentclassification = await GetClassification(classifications.IdClassification);
            currentclassification.Name = classifications.Name;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
