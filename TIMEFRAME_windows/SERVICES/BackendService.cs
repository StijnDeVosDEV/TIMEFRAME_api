using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TIMEFRAME_windows.MODELS;

namespace TIMEFRAME_windows.SERVICES
{
    public class BackendService
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
        private void InitializeHTTPclient()
        {
            client.BaseAddress = new Uri("http://localhost:44303/");        // DEVELOPMENT URI
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region CRUD - CUSTOMER
        async void AddCustomer(Customer customer)
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

        async Task<List<Customer>> Customer_Get()
        {
            List<Customer> allCustomers = null;

            try
            {
                Logger.Write("--- GETTING ALL CUSTOMERS ---");

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + @"api/customers");

                if (response.IsSuccessStatusCode)
                {
                    allCustomers = await response.Content.ReadAsAsync<List<Customer>>();
                }

                return allCustomers;
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR occurred while getting all customers : " + Environment.NewLine +
                    e.ToString());
                return allCustomers;
            }
        }
        #endregion
    }
}
