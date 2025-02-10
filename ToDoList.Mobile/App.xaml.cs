using ToDoList.Data.Context;

namespace ToDoList.Mobile
{
    public partial class App : Application
    {

        public static IServiceProvider Services;

        private static SQLiteDatabase _database;

        // Create the database connection as a singleton.
        public static SQLiteDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteDatabase();
                }
                return _database;
            }
        }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Services = serviceProvider;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}