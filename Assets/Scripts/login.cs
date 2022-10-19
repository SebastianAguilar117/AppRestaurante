using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    public InputField Usuario;
    public InputField Contraseña;
    public GameObject falso; 

    public void IniciarSesion()
    {
        if (Usuario.text == "Usuario" && Contraseña.text == "123")
        {
            SceneManager.LoadScene("Pedidos");
        }
        else
        {
            Debug.Log("Papi esa no es la cuenta");
        }
    }
}
