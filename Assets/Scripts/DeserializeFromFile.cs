using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
namespace CualquierCosa
{
    public class DeserializeFromFile : MonoBehaviour
    {
        public int Precio { get; set; } 
        public string? Summary { get; set; }
        public GetMethod referencia; 
        public string Resultado;
        public void Start() 
        {
                
        }
        public void Update() {
            Resultado = referencia.stuff; 
            Debug.Log(Resultado);
        }
        public void FuncionBoton()
        {
            DeserializeFromFile deserializefromFile = Newtonsoft.Json..Deserialize<DeserializeFromFile>(Resultado)!;
            Debug.Log($"Precio: {deserializefromFile.Precio}");
        }
    
    } 
    
   /* public class Program
    {
        public static void Main()
        {
            string fileName = "WeatherForecast.json";
            string jsonString = File.ReadAllText(fileName);
            WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString)!;

            Console.WriteLine($"Date: {weatherForecast.Date}");
            Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            Console.WriteLine($"Summary: {weatherForecast.Summary}");
        }
    }*/
}
