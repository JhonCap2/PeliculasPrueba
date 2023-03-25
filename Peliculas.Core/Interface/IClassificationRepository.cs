using Peliculas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Core.Interface
{
    public interface IClassificationRepository
    {
        Task<IEnumerable<Classifications>> GetClassifications();
        Task<Classifications> GetClassifications(int id);
        Task InsertClassification(Classifications newclassifications);
        Task <bool> UpdateClassification(Classifications classifications);
        Task <bool> DeleteClassification(int id);
    }
}
