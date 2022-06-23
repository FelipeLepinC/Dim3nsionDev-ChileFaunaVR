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
    private GUIStyle algo = new GUIStyle();

    void Start(){
        estadoMensaje = false;
    }
    
    void OnGUI(){
        if (entro && estadoMensaje){
            algo.fontSize = 100;
            GUI.Label(new Rect(500, 800, 200, 30), mensaje, algo);
        }

        if(estadoMensaje){
            if (Input.GetKeyDown(KeyCode.E)){
                LimpiarMensajeTecla();
            }
        }
    }

    private void LimpiarMensajeTecla(){
        SceneManager.LoadScene("Tutorial");
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
