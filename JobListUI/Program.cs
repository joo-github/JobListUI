using System;
using JobBL;
using JobModel;

namespace JobUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BL bl = new BL();

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            //DL.Connect();

            if (bl.ValidateUser(username, password))
            {
                while (true)
                {
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. View Jobs");
                    Console.WriteLine("2. Add New Job");
                    Console.WriteLine("3. Update Job Details");
                    Console.WriteLine("4. Delete Job");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            var jobs = bl.GetAllJobs();
                            Console.WriteLine("Job Lists:");
                            foreach (var job in jobs)
                            {
                                Console.WriteLine($"Job Title: {job.JobTitle}");
                                Console.WriteLine($"Description: {job.JobDescription}");
                                Console.WriteLine($"Company: {job.Company}");
                                Console.WriteLine($"Salary: {job.Salary}");
                                Console.WriteLine($"Location: {job.Location}");
                                Console.WriteLine();
                            }
                            break;

                        case "2":
                            Console.Write("Job Title: ");
                            string newTitle = Console.ReadLine();
                            Console.Write("Job Description: ");
                            string newDescription = Console.ReadLine();
                            Console.Write("Company: ");
                            string newCompany = Console.ReadLine();
                            Console.Write("Salary: ");
                            string newSalary = Console.ReadLine();
                            Console.Write("Location: ");
                            string newLocation = Console.ReadLine();

                            Console.Write("Type Done to Save: ");
                            string doneInput = Console.ReadLine();

                            if (doneInput.Equals("DONE", StringComparison.OrdinalIgnoreCase))
                            {
                                Job newJob = new Job
                                {
                                    JobTitle = newTitle,
                                    JobDescription = newDescription,
                                    Company = newCompany,
                                    Salary = newSalary,
                                    Location = newLocation
                                };

                                bl.AddNewJob(newJob);
                                Console.WriteLine("New job added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Process Cancelled. No changes made.");
                            }
                            break;

                        case "3":
                            Console.Write("Enter Job Title to update details: ");
                            string updateTitle = Console.ReadLine();

                            var jobToUpdate = bl.GetJobByTitle(updateTitle);
                            if (jobToUpdate != null)
                            {
                                Console.Write($"Enter new Job Description (current: {jobToUpdate.JobDescription}): ");
                                string updateDescription = Console.ReadLine();

                                Console.Write($"Enter new Company (current: {jobToUpdate.Company}): ");
                                string updateCompany = Console.ReadLine();

                                Console.Write($"Enter new Salary (current: {jobToUpdate.Salary}): ");
                                string updateSalary = Console.ReadLine();

                                Console.Write($"Enter new Location (current: {jobToUpdate.Location}): ");
                                string updateLocation = Console.ReadLine();

                                Console.Write("Enter DONE to save changes: ");
                                string doneUpdate = Console.ReadLine();

                                if (doneUpdate.Equals("DONE", StringComparison.OrdinalIgnoreCase))
                                {
                                    jobToUpdate.JobDescription = updateDescription;
                                    jobToUpdate.Company = updateCompany;
                                    jobToUpdate.Salary = updateSalary;
                                    jobToUpdate.Location = updateLocation;

                                    bl.UpdateJob(jobToUpdate);
                                    Console.WriteLine("Job details updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Process cancelled. No changes made.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Job not found.");
                            }
                            break;

                        case "4":
                            Console.Write("Enter Job Title to delete: ");
                            string deleteTitle = Console.ReadLine();

                            var jobToDelete = bl.GetJobByTitle(deleteTitle);
                            if (jobToDelete != null)
                            {
                                bl.DeleteJob(deleteTitle);
                                Console.WriteLine("Job deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Job not found.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                    Console.WriteLine("Do you want to perform another operation? (yes/no): ");
                    string continueChoice = Console.ReadLine();
                    if (continueChoice.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }
    }
}
