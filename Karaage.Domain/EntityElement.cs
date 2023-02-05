namespace Karaage.Domain;

public class EntityElement
{
    public long Id { get; set; }
    public string ExternalId { get; set; } = null!;
    public EntityType Type { get; set; }
    public DateTime IngestionDate { get; set; }
    public IngestionType IngestionType { get; set; }
}

public enum IngestionType
{
    ManualEntry
}

public enum EntityType
{
    YoutubeVideo
}