using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICandidateProfileRepository
    {
        IEnumerable<CandidateProfile> GetCandidateProfiles();

        CandidateProfile GetCandidateProfileById(string id);

        void Uppdate(CandidateProfile candidateProfile);

        void Add(CandidateProfile candidateProfile);

        void Delete(string id);

        IEnumerable<CandidateProfile> SearchCandidateProfiles(DateTime? birthday, string fullName);
    }
}
