
using System.Text.Json;
using System.Net.Http;
class Program {
private static readonly HttpClient client = new HttpClient();
private static async Task GetEndpointClase()
{
    var url = "https://jsonplaceholder.typicode.com/todos";
    HttpResponseMessage respuesta = await client.GetAsync(url);
    respuesta.EnsureSuccessStatusCode();

    string cuerpo = await respuesta.Content.ReadAsStringAsync();
    List<Tarea> listaTareas = JsonSerializer.Deserialize<List<Tarea>>(cuerpo);

    List<Tarea> pendientes = new List<Tarea>();
    List<Tarea> realizadas = new List<Tarea>();
    foreach (var tarea in listaTareas)
        {
            if (tarea.Completada)
            {
                realizadas.Add(tarea);
            } else
            {
                pendientes.Add(tarea);
            }
        }

    Console.WriteLine("------------------ Listado de tareas Pendientes ------------------\n");
    foreach (var tarea in pendientes){

        Console.WriteLine($"Título: {tarea.Titulo} ----- Estado: {(tarea.Completada ? "completada" : "pendiente")}");
    }

    Console.WriteLine("------------------ Listado de tareas Realizadas ------------------\n");
    foreach (var tarea in realizadas){

        Console.WriteLine($"Título: {tarea.Titulo} ----- Estado: {(tarea.Completada ? "completada" : "pendiente")}");
    }
 }
}