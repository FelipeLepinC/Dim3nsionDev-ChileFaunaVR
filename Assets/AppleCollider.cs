using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollider : MonoBehaviour
{
    public AppleCounter ui_contador;
    //private Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other) {
        //Debug.Log(other.collider.tag);
        if (other.collider.tag == "Apple"){
            //Debug.Log("ES UNA MANZANAA");
            //sonidos.SonidoNuevo(llaveSonido, transform.position);
            //cosa = other;
            //other.gameObject.GetComponent<man>().LightsOn();
            //cosa.gameObject.SetActive(false);

            ui_contador.GetComponent<AppleCounter>().Apple();
            //Destroy(other.gameObject);
            //keys += 1;
            // Apple();


            //other.gameObject.GetComponent<man>(). = 0;
            //StartCoroutine("Respawnear");
            //Reactivar(other);
            //Invoke("Reactivar",10);
            //other.SetActive(false);
        }
    }
}
