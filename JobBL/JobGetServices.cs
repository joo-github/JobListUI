using JobListData;
using JobListModels;
using System.Collections.Generic;

namespace JobListServices
{
    public class JobGetServices
    {
        SqlDbData sqlData = new SqlDbData();

        public List<Job> GetAllJobs()
        {
            return sqlData.GetAllJobs();
        }

        public Job GetJobByTitle(string jobTitle)
        {
            return sqlData.GetJobByTitle(jobTitle);
        }

        public void AddNewJob(Job newJob)
        {
            sqlData.AddNewJob(newJob);
        }

        public void DeleteJob(string jobTitle)
        {
            sqlData.DeleteJobByTitle(jobTitle);
        }

        public void UpdateJob(Job updatedJob)
        {
            sqlData.UpdateJob(updatedJob);
        }
    }

    public class UserGetServices
    {
        SqlDbData sqlData = new SqlDbData();

        public bool ValidateUser(string username, string password)
        {
            return sqlData.ValidateUser(username, password);
        }
    }
}