namespace rest.Shared.Ports
{
    public interface IDatabaseInstaller
    {
        Task InstallDatabaseAsync();
        Task SetupDatabaseTablseAsync();
    }
}
