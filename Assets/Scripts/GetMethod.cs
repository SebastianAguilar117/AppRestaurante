using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using Orders;
using System;

public class GetMethod : MonoBehaviour
{
    public GameObject go_Field;
    public TMP_InputField outputArea;
    public string ordersListString;
    public Orders_List myOrdersList;

    public TMP_Text mesa, pan, carnes, panabajo, cantidad, estado, pedido;
    public GameObject prefabPedido, content;
    private int posY = 85;
    private int pedidosQtty;

    public List<GameObject> listaPedidos;



    void Start()
    {
        
        myOrdersList = new Orders_List();
        go_Field = GameObject.Find("OutputArea");
        outputArea = go_Field.GetComponent<TMP_InputField>();
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
        
    }

    void Update()
    {
       // CreateRows();
    }


    void GetData() => StartCoroutine(GetData_Coroutine());

    public void DeserializeJsonString()
    {
        myOrdersList = JsonUtility.FromJson<Orders_List>("{\"_orders\":" + ordersListString.ToString() + "}");
        posY = 85;
        
        Debug.Log(myOrdersList._orders[0].id);
        CreateRows();
        
    }

    public void CreateRows()
    {
        for (int i = 0; i < myOrdersList._orders.Length ; i++)
        {
            
            if(myOrdersList._orders[i].Estado != "Completado")
            {
                if(listaPedidos.Count < myOrdersList._orders.Length) { 
                GameObject myNewPedido = Instantiate(prefabPedido, new Vector3(6, posY, 0), Quaternion.identity);
                myNewPedido.transform.SetParent(content.transform, false);
                myNewPedido.name = myOrdersList._orders[i].id;
                listaPedidos.Add(myNewPedido);
                TMP_Text[] textsComponents = myNewPedido.GetComponentsInChildren<TMP_Text>();
                textsComponents[0].text = myOrdersList._orders[i].Mesa;
                textsComponents[1].text = myOrdersList._orders[i].Pan + "\n" + myOrdersList._orders[i].Carnes + "\n" + myOrdersList._orders[i].PanAbajo;
                textsComponents[2].text = "1";
                textsComponents[3].text = myOrdersList._orders[i].Estado;
                textsComponents[4].text = myOrdersList._orders[i].id;
                Debug.Log("coso");
                posY = posY - 20;
                }
                else
                {
                    Debug.Log("No hay pedidos nuevos");
                }
            }
            
            
        }
    }

    //public void DeleteRow()
    //{
    //    listaPedidos.
    //    print(this.gameObject.name);
    //    id = int.Parse(textsComponents[4].text);
    //    myOrdersList._orders[id].Estado = "Completado";
    //}

 
    IEnumerator GetData_Coroutine()
    {
        
        outputArea.text = "Loading...";
        string uri = "https://634fafae78563c1d82acbefa.mockapi.io/orders";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
                ordersListString = request.downloadHandler.text;
                outputArea.text = request.downloadHandler.text;

            


        }
    }

    
}