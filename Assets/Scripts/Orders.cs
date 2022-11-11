using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Orders
{
    [Serializable]
    public class Orders
    {
        public string id;
        public string Mesa;
        public string Estado;
        public string Pan;
        public string Carnes;
        public string PanAbajo;
        public string Vegetales = "Sin vegetales";
        public string Salsas = "Sin salsas";
        public string Precio;
        public string Termino_Carne = "Hecho";



    }
    [Serializable]
    public class Orders_List
    {
        public Orders[] _orders;
    }

   

}
