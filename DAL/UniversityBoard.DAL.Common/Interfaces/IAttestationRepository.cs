namespace UniversityBoard.DAL.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.DAL.Common.Models;

    public interface IAttestationRepository : IRepository<Attestation>, IRepository<int, Attestation>
    {
        Task<IEnumerable<Attestation>> GetByGroup(int groupId);
    }
}