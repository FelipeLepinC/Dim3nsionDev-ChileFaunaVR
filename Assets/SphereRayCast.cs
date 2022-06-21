using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRayCast : MonoBehaviour
{
    public float radius = 1;
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;
    public AppleCounter ui_contador;
    Collider[] Apples;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        Apples = Physics.OverlapSphere(this.transform.position, radius);
        foreach(Collider apple in Apples){
            if (apple.tag == "Player"){
                ui_contador.GetComponent<AppleCounter>().InHome();
            }
            
        }
    }

    private void OnDrawGizmos() {
        if (showGizmos){
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
        
    }
}
