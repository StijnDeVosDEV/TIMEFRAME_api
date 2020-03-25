using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        private ObservableCollection<Project> _allProjects;
        private List<Project> _allprojects_placeholder;


        // Record block
        // ------------
        // Selection drop downs
        private ObservableCollection<Project> _availProjects;
        private ObservableCollection<TaskEntry> _availTaskEntries;

        private int _selCustomerID;
        private Customer _selCustomer;
        private int _selProjectID;
        private Project _selProject;
        private int _selTaskEntryID;
        private TaskEntry _selTaskEntry;

        // CONFIG block
        // --------------
        private ObservableCollection<Customer> _db_shownCustomers;
        private ObservableCollection<Project> _db_shownProjects;
        private ObservableCollection<TaskEntry> _db_shownTaskEntries;
        private ObservableCollection<TimeEntry> _db_shownTimeEntries;

        // CUSTOMER CONFIG
        private int _config_customer_selID;
        private Customer _config_customer_selCustomer;
        // Customer: add/edit
        private Visibility _customer_addedit_Visibility;
        private string _customer_addedit_Title;
        private string _customer_addedit_Name;
        private string _customer_addedit_Surname;
        private string _customer_addedit_Email;
        // Customer: edit
        private bool _customer_edit_IsEnabled;
        private Visibility _customer_edit_Visibility;
        private string _customer_edit_Title;
        private string _customer_edit_Name;
        private string _customer_edit_Surname;
        private string _customer_edit_Email;


        // Commands
        private VIEWMODELS.Base.GEN_RelayCommand _AddCustomer;
        private VIEWMODELS.Base.GEN_RelayCommand _EditCustomer;

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
            allProjects = new ObservableCollection<Project>();
            allprojects_placeholder = new List<Project>();

            availProjects = new ObservableCollection<Project>();
            availTaskEntries = new ObservableCollection<TaskEntry>();

            //selCustomer = new Customer();
            //selProject = new Project();
            //selTaskEntry = new TaskEntry();

            //selCustomerID = -1;
            //selProjectID = -1;
            //selTaskEntryID = -1;

            db_shownCustomers = new ObservableCollection<Customer>();
            db_shownProjects = new ObservableCollection<Project>();
            db_shownTaskEntries = new ObservableCollection<TaskEntry>();
            db_shownTimeEntries = new ObservableCollection<TimeEntry>();
            customer_addedit_Visibility = Visibility.Visible;
            customer_edit_IsEnabled = false;
            customer_edit_Visibility = Visibility.Visible;

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

        public ObservableCollection<Project> allProjects
        {
            get { return _allProjects; }
            set { if (value != _allProjects) { _allProjects = value; RaisePropertyChangedEvent("allProjects"); } }
        }

        public List<Project> allprojects_placeholder
        {
            get { return _allprojects_placeholder; }
            set { if (value != _allprojects_placeholder) { _allprojects_placeholder = value; RaisePropertyChangedEvent("allprojects_placeholder"); ParseProjectData(); } }
        }

        public ObservableCollection<Project> availProjects
        {
            get { return _availProjects; }
            set { if(value != _availProjects) { _availProjects = value; RaisePropertyChangedEvent("availProjects"); } }
        }

        public ObservableCollection<TaskEntry> availTaskEntries
        {
            get { return _availTaskEntries; }
            set { if(value!= _availTaskEntries) { _availTaskEntries = value; RaisePropertyChangedEvent("availTaskEntries"); } }
        }

        public int selCustomerID
        {
            get { return _selCustomerID; }
            set { if(value!= _selCustomerID) { _selCustomerID = value; RaisePropertyChangedEvent("selCustomerID"); 
                    if(selCustomerID > 0) { selCustomer = allCustomers[selCustomerID];}
                    else { selCustomer = null;}
                } }
        }
        public Customer selCustomer
        {
            get { return _selCustomer; }
            set { if(value != _selCustomer) { _selCustomer = value; RaisePropertyChangedEvent("selCustomer"); UpdateRecordData(dataCategory.Customer); } }
        }

        public int selProjectID
        {
            get { return _selProjectID; }
            set { if (value != _selProjectID) { _selProjectID = value; RaisePropertyChangedEvent("selProjectID"); selProject = availProjects[selProjectID]; } }
        }
        public Project selProject
        {
            get { return _selProject; }
            set { if (value != _selProject) { _selProject = value; RaisePropertyChangedEvent("selProject"); UpdateRecordData(dataCategory.Project); } }
        }

        public int selTaskEntryID
        {
            get { return _selTaskEntryID; }
            set { if (value != _selTaskEntryID) { _selTaskEntryID = value; RaisePropertyChangedEvent("selTaskEntryID"); selTaskEntry = availTaskEntries[selTaskEntryID]; } }
        }
        public TaskEntry selTaskEntry
        {
            get { return _selTaskEntry; }
            set { if (value != _selTaskEntry) { _selTaskEntry = value; RaisePropertyChangedEvent("selTaskEntry"); } }
        }



        public ObservableCollection<Customer> db_shownCustomers
        {
            get { return _db_shownCustomers ; }
            set { if(value != _db_shownCustomers) { _db_shownCustomers = value; RaisePropertyChangedEvent("db_shownCustomers"); } }
        }

        public ObservableCollection<Project> db_shownProjects
        {
            get { return _db_shownProjects; }
            set { if (value != _db_shownProjects) { _db_shownProjects = value; RaisePropertyChangedEvent("db_shownProjects"); } }
        }

        public ObservableCollection<TaskEntry> db_shownTaskEntries
        {
            get { return _db_shownTaskEntries; }
            set { if (value != _db_shownTaskEntries) { _db_shownTaskEntries = value; RaisePropertyChangedEvent("db_shownTaskEntries"); } }
        }

        public ObservableCollection<TimeEntry> db_shownTimeEntries
        {
            get { return _db_shownTimeEntries; }
            set { if (value != _db_shownTimeEntries) { _db_shownTimeEntries = value; RaisePropertyChangedEvent("db_shownTimeEntries"); } }
        }




        public int config_customer_selID
        {
            get { return _config_customer_selID; }
            set { if (value != _config_customer_selID) { _config_customer_selID = value; RaisePropertyChangedEvent("config_customer_selID");
                    if (config_customer_selID > 0) { config_customer_selCustomer = db_shownCustomers[config_customer_selID]; customer_edit_IsEnabled = true; Update_EditSelectionData(dataCategory.Customer); }
                    else { config_customer_selCustomer = null; customer_edit_IsEnabled = false; }
                } }
        }

        public Customer config_customer_selCustomer
        {
            get { return _config_customer_selCustomer; }
            set { if (value != _config_customer_selCustomer) { _config_customer_selCustomer = value; RaisePropertyChangedEvent("config_customer_selCustomer"); } }
        }

        public Visibility customer_addedit_Visibility
        {
            get { return _customer_addedit_Visibility; }
            set { if (value != _customer_addedit_Visibility) { _customer_addedit_Visibility = value; RaisePropertyChangedEvent("customer_addedit_Visibility");
                    if (customer_addedit_Visibility == Visibility.Visible) { Update_SecondaryViewVisibilities(dataCategory.Customer, true); }
                } }
        }
        
        public string customer_addedit_Title
        {
            get { return _customer_addedit_Title; }
            set { if (value != _customer_addedit_Title) { _customer_addedit_Title = value; RaisePropertyChangedEvent("customer_addedit_Title"); } }
        }
        
        public string customer_addedit_Name
        {
            get { return _customer_addedit_Name; }
            set { if (value != _customer_addedit_Name) { _customer_addedit_Name = value; RaisePropertyChangedEvent("customer_addedit_Name"); } }
        }

        public string customer_addedit_Surname
        {
            get { return _customer_addedit_Surname; }
            set { if (value != _customer_addedit_Surname) { _customer_addedit_Surname = value; RaisePropertyChangedEvent("customer_addedit_Surname"); } }
        }

        public string customer_addedit_Email
        {
            get { return _customer_addedit_Email; }
            set { if (value != _customer_addedit_Email) { _customer_addedit_Email = value; RaisePropertyChangedEvent("customer_addedit_Email"); } }
        }



        public bool customer_edit_IsEnabled
        {
            get { return _customer_edit_IsEnabled; }
            set { if (value != _customer_edit_IsEnabled) { _customer_edit_IsEnabled = value; RaisePropertyChangedEvent("customer_edit_IsEnabled"); } }
        }

        public Visibility customer_edit_Visibility
        {
            get { return _customer_edit_Visibility; }
            set { if (value != _customer_edit_Visibility) { _customer_edit_Visibility = value; RaisePropertyChangedEvent("customer_edit_Visibility");
                    if (customer_edit_Visibility == Visibility.Visible) { Update_SecondaryViewVisibilities(dataCategory.Customer, false); }
                } }
        }

        public string customer_edit_Title
        {
            get { return _customer_edit_Title; }
            set { if (value != _customer_edit_Title) { _customer_edit_Title = value; RaisePropertyChangedEvent("customer_edit_Title"); } }
        }

        public string customer_edit_Name
        {
            get { return _customer_edit_Name; }
            set { if (value != _customer_edit_Name) { _customer_edit_Name = value; RaisePropertyChangedEvent("customer_edit_Name"); } }
        }

        public string customer_edit_Surname
        {
            get { return _customer_edit_Surname; }
            set { if (value != _customer_edit_Surname) { _customer_edit_Surname = value; RaisePropertyChangedEvent("customer_edit_Surname"); } }
        }

        public string customer_edit_Email
        {
            get { return _customer_edit_Email; }
            set { if (value != _customer_edit_Email) { _customer_edit_Email = value; RaisePropertyChangedEvent("customer_edit_Email"); } }
        }
        #endregion


        // ---------------------------
        // Public command declarations
        // ---------------------------
        #region COMMANDS
        public ICommand AddCustomer { get { return _AddCustomer; } }
        public ICommand EditCustomer { get { return _EditCustomer; } }
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
            // Get all data from database
            allcustomers_placeholder = await myBackendService.GetCustomers();
            allprojects_placeholder = await myBackendService.GetProjects();
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

            db_shownCustomers = allCustomers;
        }

        private void ParseProjectData()
        {
            Logger.Write("PARSING PROJECT DATA:");
            Logger.Write("allprojects_placeholder.Count = " + allprojects_placeholder.Count.ToString());

            allProjects.Clear();

            foreach (Project project in allprojects_placeholder)
            {
                allProjects.Add(project);
                Logger.Write("- Added:  " + project.Name.ToUpper());
            }

            db_shownProjects = allProjects;
        }

        private enum dataCategory
        {
            Customer,
            Project,
            TaskEntry,
            TimeEntry
        }

        private void UpdateRecordData(dataCategory target)
        {
            try
            {
                switch (target)
                {
                    case dataCategory.Customer:
                        availProjects.Clear();
                        foreach (Project project in selCustomer.Projects)
                        {
                            availProjects.Add(project);
                        }

                        availTaskEntries.Clear();
                        selTaskEntry = null;
                        break;

                    case dataCategory.Project:
                        availTaskEntries.Clear();
                        foreach (TaskEntry taskEntry in selProject.TaskEntries)
                        {
                            availTaskEntries.Add(taskEntry);
                        }

                        selTaskEntry = null;
                        break;

                    case dataCategory.TaskEntry:
                        break;
                    case dataCategory.TimeEntry:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR while trying to update record block data: " + Environment.NewLine +
                    e.ToString());
            }
        }


        private void UpdateConfigurationComponent()
        {
            db_shownCustomers = allCustomers;
        }

        private void Update_SecondaryViewVisibilities(dataCategory SecondaryViewShown, bool shouldADDopen)
        {
            try
            {
                switch (SecondaryViewShown)
                {
                    case dataCategory.Customer:
                        if (shouldADDopen) { customer_edit_Visibility = Visibility.Hidden; } else { customer_addedit_Visibility = Visibility.Hidden; }
                        break;
                    case dataCategory.Project:
                        break;
                    case dataCategory.TaskEntry:
                        break;
                    case dataCategory.TimeEntry:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR while trying to update record block data: " + Environment.NewLine +
                    e.ToString());
            }
        }

        private void Update_EditSelectionData(dataCategory targetEditView)
        {
            try
            {
                switch (targetEditView)
                {
                    case dataCategory.Customer:
                        customer_edit_Name = config_customer_selCustomer.Name;
                        customer_edit_Surname = config_customer_selCustomer.Surname;
                        customer_edit_Email = config_customer_selCustomer.Email;
                        break;

                    case dataCategory.Project:
                        break;
                    case dataCategory.TaskEntry:
                        break;
                    case dataCategory.TimeEntry:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR while trying to update record block data: " + Environment.NewLine +
                    e.ToString());
            }
        }

        //  ----------------------
        // COMMAND RELATED METHODS
        //  ----------------------
        /// <summary>
        /// Load all GUI commands
        /// </summary>
        private void LoadCommands()
        {
            _AddCustomer = new Base.GEN_RelayCommand(param => this.Perform_AddCustomer());
            _EditCustomer = new Base.GEN_RelayCommand(param => this.Perform_EditCustomer());
        }

        private async void Perform_AddCustomer()
        {
            try
            {
                // Create new Customer
                Customer newCustomer = new Customer()
                {
                    Name = customer_addedit_Name,
                    Surname = customer_addedit_Surname,
                    Email = customer_addedit_Email,
                    CreationDate = DateTime.Now,
                    Status = "Active"
                };

                // Update in database
                await myBackendService.AddCustomer(newCustomer);

                // Update in current app session
                newCustomer.Id = allCustomers.Count + 1;
                allCustomers.Add(newCustomer);


                // Update UI
                customer_addedit_Name = "";
                customer_addedit_Surname = "";
                customer_addedit_Email = "";
                customer_addedit_Visibility = Visibility.Hidden;
                UpdateConfigurationComponent();
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR occurred while trying to start adding new Customer: " + Environment.NewLine +
                    e.ToString());
            }
        }

        private async void Perform_EditCustomer()
        {
            try
            {
                // Get modified Customer
                Customer modCustomer = new Customer()
                {
                    Id = config_customer_selCustomer.Id,
                    Name = customer_edit_Name,
                    Surname = customer_edit_Surname,
                    Email = customer_edit_Email,
                    CreationDate = config_customer_selCustomer.CreationDate,
                    Status = config_customer_selCustomer.Status
                };

                // Update in database
                await myBackendService.EditCustomer(modCustomer);

                // Update in current app session
                allCustomers[modCustomer.Id - 1] = modCustomer;


                // Update UI
                customer_edit_Visibility = Visibility.Hidden;
                UpdateConfigurationComponent();
            }
            catch (Exception e)
            {
                Logger.Write("!ERROR occurred while trying to start adding new Customer: " + Environment.NewLine +
                    e.ToString());
            }
        }
    }
}
