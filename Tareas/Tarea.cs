using System.Text.Json.Serialization;
public class Tarea
{
    [JsonPropertyName("userId")]
    public int UserID {get; set;}

    [JsonPropertyName("id")]
    public int ID {get; set;}

    [JsonPropertyName("title")]
    public string? Titulo {get; set;}

    [JsonPropertyName("completed")]
    public bool Completada {get;set;}
}