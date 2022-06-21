using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo, mensaje;
    private float restante;
    private bool enMarcha;
    // Start is called before the first frame update
    void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
        mensaje.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha){
            restante -= Time.deltaTime;
            if (restante < 1){
                enMarcha = false;
                mensaje.enabled = true;
                Debug.Log("Se acabó el tiempo");
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
