using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using SimpleJSON;
using UnityEngine.Networking;

public class InterfaceController : MonoBehaviour
{
    // URL base de la API del tiempo, la documentación está en https://www.el-tiempo.net/api
    const string apiDirection = "https://www.el-tiempo.net/api/json/v2";
    // Objeto Dropdown de las provincias
    [SerializeField] private TMP_Dropdown myDropdown;
    // Objeto de Texto que debe contener la información
    [SerializeField] private TMP_Text resultText;
    // Panel inicial
    [SerializeField] private GameObject mainPanel;
    // Panel del tiempo
    [SerializeField] private GameObject weatherPanel;
    // Botón de búsqueda
    [SerializeField] private Button buttonSearch;
    // Botón de volver
    [SerializeField] private Button buttonBack;

    Dictionary<string,string> provinceWithId = new Dictionary<string, string>();


    /// <summary>
    /// Corrutina que hace la petición a la API para obtener las provincias
    /// Habrá que guardar los nombres y las ids de cada provincia para su acceso en el futuro
    /// </summary>
    /// <returns></returns>
    public IEnumerator provinceRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiDirection + "/provincias");

        // Enviamos la petición a la API
        yield return request.SendWebRequest();

        JSONNode myNode = JSON.Parse(request.downloadHandler.text);
       
        // Guardamos los valores en el dicionario de provincias con su ID
        // (se puede acceder a los valores de un JSONNode como un array normal)
        for (int i = 0; ; i++)
        {
            if (myNode["provincias"][i]["NOMBRE_PROVINCIA"] == null || i > 120)
                break;
            provinceWithId.Add(myNode["provincias"][i]["NOMBRE_PROVINCIA"], myNode["provincias"][i]["CODPROV"]);
        }

        populateDropdown(provinceWithId);
    }

    /// <summary>
    /// Corrutina que hace la petición a la API para obtener la información de una provincia
    /// </summary>
    /// <param name="idProvince">Id de la provincia que se busca</param>
    /// <returns></returns>
    public IEnumerator weatherRequest(string idProvince)
    {
        // Aquí habrá que recuperar la información de la provincia mediante una petición a la API y 
        // llevar la propia información a la función writeWeather();

        yield return null;
        writeWeather("[Tiempo atmosférico]");
    }

    /// <summary>
    /// Función que modifica el texto que contiene la información sobre el tiempo
    /// </summary>
    /// <param name="weather">El tiempo atmosférico</param>
    private void writeWeather(string weather)
    {
        // Aquí habrá que escribir el tiempo en el campo de texto y cambiar el panel
    }

    /// <summary>
    /// Función que debe ser llamada cuando se quiera obtener el tiempo atmosférico pulsando el botón
    /// </summary>
    private void getWeather()
    {
        // Aquí habrá que iniciar la corrutina para obtener el tiempo
    }

    /// <summary>
    /// Función que debe modificar el Objeto Dropdown introduciendo las provincias
    /// </summary>
    /// <param name="newDict">Diccionario de las provincias</param>
    private void populateDropdown(Dictionary<string,string> newDict)
    {
        // Aquí habrá que introducir las opciones en el Objeto Dropdown
    }

    /// <summary>
    /// En la función Awake se debe rellenar el Objeto Dropdown con las provincias que nos dé la API, 
    /// además de asignar los listeners que sean necesarios
    /// </summary>
    private void Awake()
    {
        // Iniciamos la corrutina para conseguir la lista de provincias
        StartCoroutine(provinceRequest());
    }
}