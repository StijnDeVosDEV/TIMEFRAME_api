using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TIMEFRAME_windows.MODELS;
using TIMEFRAME_windows.SERVICES.Interfaces;

namespace TIMEFRAME_windows.SERVICES
{
    public class BackendService : IBackendService
    {
        // FIELDS
        private HttpClient client = new HttpClient();


        // CONSTRUCTOR
        public BackendService()
        {
            // Initialize HTTP client
            InitializeHTTPclient();
        }

        // PROPERTIES


        // METHODS
        public void InitializeHTTPclient()
        {
            //client.BaseAddress = new Uri("http://localhost:44303/");                        // DEVELOPMENT URI
            client.BaseAddress = new Uri("https://timeframeapi-test.azurewebsites.net/");    // PRODUCTION URI
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region CUSTOMERS
        // POST 1 Customer
        public async Task AddCustomer(Customer customer)
        {
            try
            {
                Logger.Write("--- ADDING NEW CUSTOMER ---");
                
                HttpResponseMessage response = await client.PostAsJsonAsync("api/customers", customer);
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR occurred while adding new customer : " + Environment.NewLine +
                    e.ToString());
            }
        }

        // GET all Customers
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> allCustomers = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + @"api/customers");

                if (response.IsSuccessStatusCode)
                {
                    allCustomers = await response.Content.ReadAsAsync<List<Customer>>();
                }
                else
                {
                    System.Windows.MessageBox.Show("ERROR:  " + response.StatusCode.ToString());
                }

                return allCustomers;
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR occurred while getting all customers : " + Environment.NewLine +
                    e.ToString());
                System.Windows.MessageBox.Show("Leaving GetCustomers() : ERROR: " + Environment.NewLine +
                    e.ToString());
                return allCustomers;
            }
        }
        #endregion

        #region PROJECTS
        // POST Project
        public async Task AddProject(Project project)
        {
            try
            {
                Logger.Write("--- ADDING NEW PROJECT ---");

                HttpResponseMessage response = await client.PostAsJsonAsync("api/projects", project);
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR occurred while adding new project : " + Environment.NewLine +
                    e.ToString());
            }
        }
        
        // GET all Customers
        public async Task<List<Project>> GetProjects()
        {
            List<Project> allProjects = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + @"api/projects");

                if (response.IsSuccessStatusCode)
                {
                    allProjects = await response.Content.ReadAsAsync<List<Project>>();
                }
                else
                {
                    System.Windows.MessageBox.Show("ERROR:  " + response.StatusCode.ToString());
                }

                return allProjects;
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR occurred while getting all projects : " + Environment.NewLine +
                    e.ToString());
                System.Windows.MessageBox.Show("Leaving GetProjects() : ERROR: " + Environment.NewLine +
                    e.ToString());
                return allProjects;
            }
        }
        #endregion
    }
}
