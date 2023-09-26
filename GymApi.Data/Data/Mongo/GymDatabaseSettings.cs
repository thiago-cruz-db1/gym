namespace GymApi.Data.Data.Mongo;

public class GymDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string GymCollectionName { get; set; } = null!;
}