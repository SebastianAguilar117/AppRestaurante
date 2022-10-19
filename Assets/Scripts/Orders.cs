using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Orders
{
    [Serializable]
    public class Orders
    {
        public string createdAt;
        public string Oriental;
        public string id;
        public string title;
        public string Mesa;
        public string Pedido;
        public string Precio;


    }
    [Serializable]
    public class Orders_List
    {
        public Orders[] _orders;
    }

   

}
