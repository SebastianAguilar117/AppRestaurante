using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Orders;

public class GetMethod : MonoBehaviour
{
    public GameObject go_Field;
    public TMP_InputField outputArea;
    public string stuff;
    Orders_List myOrdersList;

    void Start()
    {
        myOrdersList = new Orders_List();
        go_Field = GameObject.Find("OutputArea");
        outputArea = go_Field.GetComponent<TMP_InputField>();
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }
 
    void GetData() => StartCoroutine(GetData_Coroutine());

    public void DeserializeJsonString()
    {
        myOrdersList = JsonUtility.FromJson<Orders_List>("{\"_orders\":" + stuff.ToString() + "}");
        Debug.Log(stuff.ToString());
        stuff = stuff.ToString();
        string[] qtty = stuff.Split('}');
        print(qtty[0]);
        Debug.Log(myOrdersList._orders[0].Mesa);
        
    }
 
    IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading...";
        string uri = "https://6327fad49a053ff9aaadb7e8.mockapi.io/Pedido";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
                stuff = request.downloadHandler.text;
                outputArea.text = request.downloadHandler.text;
                

        }
    }
}