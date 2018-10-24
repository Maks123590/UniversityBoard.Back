namespace UniversityBoard.DAL.ORM.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AttestationOrmRepository : BaseOrmRepository<int, Attestation>, IAttestationRepository
    {
        public AttestationOrmRepository(DbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Attestation>> GetByGroup(int groupId)
        {
            return await this.DbSet.Where(a => a.GroupId == groupId).AsNoTracking().ToListAsync();
        }
    }
}