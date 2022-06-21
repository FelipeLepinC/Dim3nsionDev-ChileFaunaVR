using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mensaje : MonoBehaviour
{

    public string mensaje;
    public bool entro = false;
    private bool estadoMensaje;

    void Start(){
        estadoMensaje = false;
    }
    
    void OnGUI(){
        if (entro && estadoMensaje){
            GUI.Label(new Rect(Screen.width/2-100, 200, 200, 30), mensaje);
        }

        if(estadoMensaje){
            if (Input.GetKeyDown(KeyCode.E)){
                LimpiarMensajeTecla();
            }
        }
    }

    private void LimpiarMensajeTecla(){
        SceneManager.LoadScene("SampleScene");
    }

    private void OnTriggerEnter(Collider other){
        entro = true;
        estadoMensaje = true;
    }

    private void OnTriggerExit(Collider other){
        entro = false;
        estadoMensaje = false;
    }
}
