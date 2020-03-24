using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIMEFRAME_windows.MODELS;

namespace TIMEFRAME_windows.SERVICES.Interfaces
{
    public interface IBackendService
    {
        // METHODS
        public void InitializeHTTPclient();

        #region CRUD - CUSTOMER
        public Task AddCustomer(Customer customer);

        public Task<List<Customer>> Customer_Get();
        #endregion
    }
}
