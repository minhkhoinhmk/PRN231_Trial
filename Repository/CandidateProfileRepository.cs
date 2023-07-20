using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        public void Add(CandidateProfile candidateProfile)
        {
            CandidateProfileDAO.Instance.AddNew(candidateProfile);
        }

        public void Delete(string id)
        {
            CandidateProfileDAO.Instance.Remove(id);
        }

        public CandidateProfile GetCandidateProfileById(string id)
        {
            return CandidateProfileDAO.Instance.GetCandidateProfileByID(id);
        }

        public IEnumerable<CandidateProfile> GetCandidateProfiles()
        {
            return CandidateProfileDAO.Instance.GetCandidateProfiles();
        }

        public IEnumerable<CandidateProfile> SearchCandidateProfiles(DateTime? birthday, string fullName)
        {
            return CandidateProfileDAO.Instance.SearchCandidateProfiles(birthday, fullName);
        }

        public void Uppdate(CandidateProfile candidateProfile)
        {
            CandidateProfileDAO.Instance.Update(candidateProfile);
        }
    }
}
