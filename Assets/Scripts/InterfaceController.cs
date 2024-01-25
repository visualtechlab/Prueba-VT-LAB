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
    // URL base de la API del tiempo, la documentaci�n est� en https://www.el-tiempo.net/api
    const string apiDirection = "https://www.el-tiempo.net/api/json/v2";
    // Objeto Dropdown de las provincias
    [SerializeField] private TMP_Dropdown myDropdown;
    // Objeto de Texto que debe contener la informaci�n
    [SerializeField] private TMP_Text resultText;
    // Panel inicial
    [SerializeField] private GameObject mainPanel;
    // Panel del tiempo
    [SerializeField] private GameObject weatherPanel;
    // Bot�n de b�squeda
    [SerializeField] private Button buttonSearch;
    // Bot�n de volver
    [SerializeField] private Button buttonBack;

    Dictionary<string,string> provinceWithId = new Dictionary<string, string>();


    /// <summary>
    /// Corrutina que hace la petici�n a la API para obtener las provincias
    /// Habr� que guardar los nombres y las ids de cada provincia para su acceso en el futuro
    /// </summary>
    /// <returns></returns>
    public IEnumerator provinceRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiDirection + "/provincias");

        // Enviamos la petici�n a la API
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
    /// Corrutina que hace la petici�n a la API para obtener la informaci�n de una provincia
    /// </summary>
    /// <param name="idProvince">Id de la provincia que se busca</param>
    /// <returns></returns>
    public IEnumerator weatherRequest(string idProvince)
    {
        // Aqu� habr� que recuperar la informaci�n de la provincia mediante una petici�n a la API y 
        // llevar la propia informaci�n a la funci�n writeWeather();

        yield return null;
        writeWeather("[Tiempo atmosf�rico]");
    }

    /// <summary>
    /// Funci�n que modifica el texto que contiene la informaci�n sobre el tiempo
    /// </summary>
    /// <param name="weather">El tiempo atmosf�rico</param>
    private void writeWeather(string weather)
    {
        // Aqu� habr� que escribir el tiempo en el campo de texto y cambiar el panel
    }

    /// <summary>
    /// Funci�n que debe ser llamada cuando se quiera obtener el tiempo atmosf�rico pulsando el bot�n
    /// </summary>
    private void getWeather()
    {
        // Aqu� habr� que iniciar la corrutina para obtener el tiempo
    }

    /// <summary>
    /// Funci�n que debe modificar el Objeto Dropdown introduciendo las provincias
    /// </summary>
    /// <param name="newDict">Diccionario de las provincias</param>
    private void populateDropdown(Dictionary<string,string> newDict)
    {
        // Aqu� habr� que introducir las opciones en el Objeto Dropdown
    }

    /// <summary>
    /// En la funci�n Awake se debe rellenar el Objeto Dropdown con las provincias que nos d� la API, 
    /// adem�s de asignar los listeners que sean necesarios
    /// </summary>
    private void Awake()
    {
        // Iniciamos la corrutina para conseguir la lista de provincias
        StartCoroutine(provinceRequest());
    }
}