namespace SailClubLibrary.Services
{
    // Opbevares lokalt
    public class Connection
    {
        public static readonly string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=SailClubDatabase;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=True;" +
            "Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False;" +
            "Command Timeout=30";
    }
}
