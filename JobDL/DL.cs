using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using JobModel;

namespace JobDL
{
    public class DL
    {
        static string connectionString


     = "Server=tcp:20.2.24.32,1433; Database=JobList; User Id= sa; Password=Ramos.bsit21;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);
        static public void Connect()
        {
            sqlConnection.Open();
        }


        public List<Job> GetAllJobs()
        {
            string selectStatement = "SELECT jobTitle, jobDescription, company, salary, location FROM jobs";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Job> jobs = new List<Job>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Job job = new Job
                {
                    JobTitle = reader["jobTitle"].ToString(),
                    JobDescription = reader["jobDescription"].ToString(),
                    Company = reader["company"].ToString(),
                    Salary = reader["salary"].ToString(),
                    Location = reader["location"].ToString()
                };

                jobs.Add(job);
            }

            sqlConnection.Close();

            return jobs;
        }

        public Job GetJobByTitle(string jobTitle)
        {
            string selectStatement = "SELECT jobTitle, jobDescription, company, salary, location FROM jobs WHERE jobTitle = @jobTitle";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@jobTitle", jobTitle);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            Job job = null;
            if (reader.Read())
            {
                job = new Job
                {
                    JobTitle = reader["jobTitle"].ToString(),
                    JobDescription = reader["jobDescription"].ToString(),
                    Company = reader["company"].ToString(),
                    Salary = reader["salary"].ToString(),
                    Location = reader["location"].ToString()
                };
            }

            sqlConnection.Close();

            return job;
        }

        public void AddNewJob(Job newJob)
        {
            string insertStatement = "INSERT INTO jobs (jobTitle, jobDescription, company, salary, location) " +
                                     "VALUES (@jobTitle, @jobDescription, @company, @salary, @location)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@jobTitle", newJob.JobTitle);
            insertCommand.Parameters.AddWithValue("@jobDescription", newJob.JobDescription);
            insertCommand.Parameters.AddWithValue("@company", newJob.Company);
            insertCommand.Parameters.AddWithValue("@salary", newJob.Salary);
            insertCommand.Parameters.AddWithValue("@location", newJob.Location);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteJobByTitle(string jobTitle)
        {
            string deleteStatement = "DELETE FROM jobs WHERE jobTitle = @jobTitle";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@jobTitle", jobTitle);

            sqlConnection.Open();
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateJob(Job updatedJob)
        {
            string updateStatement = "UPDATE jobs SET jobDescription = @jobDescription, company = @company, salary = @salary, location = @location WHERE jobTitle = @jobTitle";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@jobTitle", updatedJob.JobTitle);
            updateCommand.Parameters.AddWithValue("@jobDescription", updatedJob.JobDescription);
            updateCommand.Parameters.AddWithValue("@company", updatedJob.Company);
            updateCommand.Parameters.AddWithValue("@salary", updatedJob.Salary);
            updateCommand.Parameters.AddWithValue("@location", updatedJob.Location);

            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public bool ValidateUser(string username, string password)
        {
            string selectStatement = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@username", username);
            selectCommand.Parameters.AddWithValue("@password", password);

            sqlConnection.Open();
            int userCount = (int)selectCommand.ExecuteScalar();
            sqlConnection.Close();

            return userCount > 0;
        }
    }
}
