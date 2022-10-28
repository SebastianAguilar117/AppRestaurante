using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido : MonoBehaviour
{
    public string fakeId;
    public int id;
    public GetMethod getMethod;
    // Start is called before the first frame update
    void Start()
    {
        fakeId = this.gameObject.name;
        id = int.Parse(this.gameObject.name)-1;
        getMethod = GameObject.Find("Canvas2").GetComponent<GetMethod>();
    }

    public void DestroyThis()
    {
        for (int i = 0; i < getMethod.listaPedidos.Count; i++)
        {
            Debug.Log(getMethod.listaPedidos[i].name);
            //if(getMethod.listaPedidos[i].name == )
        }
        //getMethod.myOrdersList._orders[id].Estado = "Completado";
       // Object.Destroy(this.gameObject);
    }
}
