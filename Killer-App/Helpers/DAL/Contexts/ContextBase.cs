namespace Killer_App.Helpers.DAL.Contexts
{
    public class ContextBase
    {
        private readonly string _connectionString;

        public ContextBase(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}