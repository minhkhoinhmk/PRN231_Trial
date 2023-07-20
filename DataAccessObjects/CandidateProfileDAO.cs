using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CandidateProfileDAO
    {
        private static CandidateProfileDAO instance = null;
        private static readonly object instanceLock = new object();

        private CandidateProfileDAO() { }

        public static CandidateProfileDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CandidateProfileDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<CandidateProfile> GetCandidateProfiles()
        {
            List<CandidateProfile> candidateProfiles;
            try
            {
                var context = new CandidateManagementContext();
                candidateProfiles = context.CandidateProfiles.Include(p => p.Posting).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return candidateProfiles;
        }

        public CandidateProfile GetCandidateProfileByID(string id)
        {
            CandidateProfile candidateProfile = null;
            try
            {
                var context = new CandidateManagementContext();
                candidateProfile = context.CandidateProfiles.Include(c => c.Posting)
                    .SingleOrDefault(c => c.CandidateId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("CandidateProfile not found");
            }
            return candidateProfile;
        }

        public void Update(CandidateProfile candidateProfile)
        {
            try
            {
                CandidateProfile _candidateProfile = GetCandidateProfileByID(candidateProfile.CandidateId);
                if (_candidateProfile != null)
                {
                    var context = new CandidateManagementContext();
                    context.Entry<CandidateProfile>(candidateProfile).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The CandidateProfile does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void AddNew(CandidateProfile candidateProfile)
        {
            try
            {
                CandidateProfile _candidateProfile = GetCandidateProfileByID(candidateProfile.CandidateId);
                if (_candidateProfile == null)
                {
                    var context = new CandidateManagementContext();
                    context.CandidateProfiles.Add(candidateProfile);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The CandidateProfile is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Remove(string id)
        {
            try
            {
                CandidateProfile _candidateProfile = GetCandidateProfileByID(id);
                if (_candidateProfile != null)
                {
                    var context = new CandidateManagementContext();
                    context.Remove(_candidateProfile);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The CandidateProfile does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public IEnumerable<CandidateProfile> SearchCandidateProfiles(DateTime? birthday, string fullName)
        {
            List<CandidateProfile> candidateProfiles;
            try
            {
                var context = new CandidateManagementContext();
                if (!birthday.HasValue && !string.IsNullOrEmpty(fullName))
                {
                    candidateProfiles = context.CandidateProfiles
                        .Include(c => c.Posting)
                        .Where(c => c.Fullname.Contains(fullName)).ToList();
                }
                else if (birthday.HasValue && string.IsNullOrEmpty(fullName))
                {
                    candidateProfiles = context.CandidateProfiles
                        .Include(c => c.Posting)
                        .Where(c => c.Birthday == birthday).ToList();
                }
                else if(birthday.HasValue && !string.IsNullOrEmpty(fullName))
                {
                    candidateProfiles = context.CandidateProfiles
                        .Include(c => c.Posting)
                        .Where(c => c.Birthday == birthday && c.Fullname.Contains(fullName)).ToList();
                }
                else
                {
                    candidateProfiles = context.CandidateProfiles.Include(p => p.Posting).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return candidateProfiles;
        }
    }
}
