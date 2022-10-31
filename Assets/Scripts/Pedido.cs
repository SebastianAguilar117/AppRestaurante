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
        if (getMethod.listaPedidos.Count > 0) { 
        for (int i = 0; i < getMethod.listaPedidos.Count; i++)
        {
            //Debug.Log(getMethod.listaPedidos[i].name);
            if(getMethod.listaPedidos[i].name == fakeId && getMethod.listaPedidos.Count >1)
            {
                    Debug.Log("ctm");
                getMethod.listaPedidos.Remove(getMethod.listaPedidos[i]);
            }
                
            if (getMethod.listaPedidos[i].name != "1") {
                Debug.Log("entro");
            getMethod.listaPedidos[i].transform.SetPositionAndRotation(new Vector3(getMethod.listaPedidos[i].transform.position.x, getMethod.listaPedidos[i].transform.position.y + 280, getMethod.listaPedidos[i].transform.position.z), getMethod.listaPedidos[i].transform.rotation);
            }

            
        }
            
        }
        getMethod.myOrdersList._orders[id].Estado = "Completado";
        Object.Destroy(this.gameObject);
        Debug.Log(getMethod.listaPedidos.Count);

    }
}
