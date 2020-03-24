using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TIMEFRAME_windows.MODELS;
using TIMEFRAME_windows.SERVICES;
using TIMEFRAME_windows.SERVICES.Interfaces;

namespace TIMEFRAME_windows.VIEWMODELS
{
    public class VM_Main : Base.GEN_ObservableObject
    {
        //  -----------------------------
        //  Private variable declarations
        //  -----------------------------
        // UI related
        private ObservableCollection<Customer> _allCustomers;
        private List<Customer> _allcustomers_placeholder;

        // Commands


        // Services
        private IBackendService myBackendService;


        //  -----------------------------
        //  Actual Class variables
        //  -----------------------------


        //  -----------
        //  CONSTRUCTOR
        //  -----------
        public VM_Main()
        {
            // Inject Services
            //InitializeServiceInjections(new BackendService());
            myBackendService = new BackendService();
            allCustomers = new ObservableCollection<Customer>();
            allcustomers_placeholder = new List<Customer>();

            // Initializations
            InitializeData();

            // Load commands
            LoadCommands();

            // Initialize process
            Logger.SetPath(Environment.GetEnvironmentVariable("TEMP"));
            Logger.Initialize();
            
            // Search Background Worker event handler initialization
            
        }

        // ----------------------------
        // Public variable declarations
        // ----------------------------
        #region PROPERTIES
        public ObservableCollection<Customer> allCustomers
        {
            get { return _allCustomers; }
            set { if (value != _allCustomers) { _allCustomers = value; RaisePropertyChangedEvent("allCustomers"); } }
        }

        public List<Customer> allcustomers_placeholder
        {
            get { return _allcustomers_placeholder; }
            set { if(value != _allcustomers_placeholder) { _allcustomers_placeholder = value; RaisePropertyChangedEvent("allcustomers_placeholder"); ParseCustomerData(); } }
        }
        #endregion


        // ---------------------------
        // Public command declarations
        // ---------------------------
        #region COMMANDS

        #endregion


        //  -----------------
        //  Private functions
        //  -----------------
        //public void InitializeServiceInjections(IBackendService backendService)
        //{
        //    myBackendService = backendService;
        //}

        private async Task InitializeData()
        {
            // Get all customers of database
            allcustomers_placeholder = await myBackendService.Customer_Get();

            //System.Windows.MessageBox.Show("Data initialized!");
        }

        private void ParseCustomerData()
        {
            Logger.Write("PARSING CUSTOMER DATA:");
            Logger.Write("allcustomers_placeholder.Count = " + allcustomers_placeholder.Count.ToString());

            allCustomers.Clear();

            foreach (Customer customer in allcustomers_placeholder)
            {
                allCustomers.Add(customer);
                Logger.Write("- Added:  " + customer.Name.ToUpper());
            }
        }

        //private ObservableCollection<MODELS.Customer> ConvertListToObsColl_Cust(List<Customer> ListCustomers)
        //{
        //    ObservableCollection<Customer> newCustomerColl = new ObservableCollection<Customer>();

        //    try
        //    {
        //        foreach (Customer customer in ListCustomers)
        //        {
        //            newCustomerColl.Add(customer);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.Write("!ERROR occurred : " + Environment.NewLine +
        //            e.ToString());
        //    }

        //    return newCustomerColl;
        //}

        //  ----------------------
        // COMMAND RELATED METHODS
        //  ----------------------
        /// <summary>
        /// Load all GUI commands
        /// </summary>
        private void LoadCommands()
        {
            
        }
    }
}
