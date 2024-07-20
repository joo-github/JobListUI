using JobDL;
using JobModel;
using System.Collections.Generic;

namespace JobBL
{
    public class BL
    {
        private DL dl;

        public BL()
        {
            dl = new DL();
        }

        public List<Job> GetAllJobs()
        {
            return dl.GetAllJobs();
        }

        public Job GetJobByTitle(string jobTitle)
        {
            return dl.GetJobByTitle(jobTitle);
        }

        public void AddNewJob(Job newJob)
        {
            dl.AddNewJob(newJob);
        }

        public void DeleteJob(string jobTitle)
        {
            dl.DeleteJobByTitle(jobTitle);
        }

        public void UpdateJob(Job updatedJob)
        {
            dl.UpdateJob(updatedJob);
        }

        public bool ValidateUser(string username, string password)
        {
            return dl.ValidateUser(username, password);
        }
    }
}
