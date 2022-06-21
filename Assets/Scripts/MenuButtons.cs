using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
        public void Jugar(){
            SceneManager.LoadScene("Juego");
        }

        public void Salir(){
            Application.Quit();
        }
}
