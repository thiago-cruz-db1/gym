namespace GymApi.Data.Data;

public class GymDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string GymCollectionName { get; set; } = null!;
}