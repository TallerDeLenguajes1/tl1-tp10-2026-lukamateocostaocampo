
using System.Text.Json;
using System.Net.Http;
class Program {
private static readonly HttpClient client = new HttpClient();
static async Task Main()
    {
        await GetEndpointClase();
    }
private static async Task GetEndpointClase()
{
    var url = "https://jsonplaceholder.typicode.com/todos";
    HttpResponseMessage respuesta = await client.GetAsync(url);
    respuesta.EnsureSuccessStatusCode();

    string cuerpo = await respuesta.Content.ReadAsStringAsync();
    List<Tarea>? listaTareas = JsonSerializer.Deserialize<List<Tarea>>(cuerpo);

    List<Tarea> pendientes = new List<Tarea>();
    List<Tarea> realizadas = new List<Tarea>();
    foreach (var tarea in listaTareas) // se puede cubrir el caso de nulos en "listaTareas" poniendo listaTareas ?? new List<Tarea>()
        {
            if (tarea.Completada)
            {
                realizadas.Add(tarea);
            } else
            {
                pendientes.Add(tarea);
            }
        }

    Console.WriteLine("\n\n------------------ Listado de tareas Pendientes ------------------\n\n");
    foreach (var tarea in pendientes){

        Console.WriteLine($"Título: {tarea.Titulo} ----- Estado: {(tarea.Completada ? "completada" : "pendiente")}");
    }

    Console.WriteLine("\n\n------------------ Listado de tareas Realizadas ------------------\n\n");
    foreach (var tarea in realizadas){

        Console.WriteLine($"Título: {tarea.Titulo} ----- Estado: {(tarea.Completada ? "completada" : "pendiente")}");
    }
 }
}