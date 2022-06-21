using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cazador : MonoBehaviour
{
    // Variables generales
    public float movementSpeed = 3f;
    public float rotationSpeed = 100f;

    // Errante
    private bool isWandering = false;
    private bool isRotationLeft = false;
    private bool isRotationRight = false;
    private bool isWalking = false;

    // Perseguimiento
    public Vector3 posicionPerseguido;
    public Vector3 posicionPerseguidor;
    public Vector3 direccionPersecucion;
    public GameObject perseguido;
    public AppleCounter interfaz;

    public FieldOfView campoVision;

    Rigidbody rb;

    //Perseguimiento V2
    public Transform target;
    NavMeshAgent nav;
    private bool visto = false;

    // Animaciones
    Animator animator;

    // Reset
    public GameObject madriguera;
    public CharacterController controller;
    public AppleCounter ui_contador;
    public Vector3 pos;

    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (campoVision.GetComponent<FieldOfView>().visibleTargets.Count == 0)
        {
            if (visto == true){
                rb.velocity = new Vector3(0f, 0f, 0f);
                nav.ResetPath();
            }
            visto = false;
            interfaz.GetComponent<AppleCounter>().not_persued();
            if (isWandering == false)
            {
                StartCoroutine(Wander());
            }
            if (isRotationRight == true)
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
                transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
                
            }
            if (isRotationLeft == true)
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
                transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            }
            if (isWalking == true)
            {
                rb.AddForce(transform.forward * movementSpeed);
                animator.SetBool("isRunning", true);
            }
            if (isWalking == false)
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            
            if (visto == false){
                //rb.AddForce(-(transform.forward * movementSpeed));
                rb.velocity = new Vector3(0f, 0f, 0f);
            }
            visto = true;
            interfaz.GetComponent<AppleCounter>().persued();
            ProcessPosition();
            perseguir();
            //MoveToPerseguido();
        }
    }

    // Modo errante
    IEnumerator Wander()
    {
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 3);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateDirection == 1 || rotateDirection == 3) 
        {
            isRotationLeft = true;
            animator.SetBool("isRotatingLeft", true);
            yield return new WaitForSeconds(rotationTime);
            animator.SetBool("isRotatingLeft", false);
            isRotationLeft = false;

        }
        if (rotateDirection == 2)
        {
            isRotationRight = true;
            animator.SetBool("isRotatingRight", true);
            yield return new WaitForSeconds(rotationTime);
            animator.SetBool("isRotatingRight", false);
            isRotationRight = false;

        }
        isWandering = false;
    }

    // Perseguir
    private void ProcessPosition()
    {
        posicionPerseguidor = this.gameObject.transform.position;
        posicionPerseguido = perseguido.transform.position;
        float direccionX = posicionPerseguido.x - posicionPerseguidor.x;
        float direccionY = posicionPerseguido.y - posicionPerseguidor.y;
        float direccionZ = posicionPerseguido.z - posicionPerseguidor.z;
        direccionPersecucion = new Vector3(direccionX, direccionY, direccionZ);
    }
    private void MoveToPerseguido()
    {
        animator.SetBool("isRunning", true);
        rb.AddForce(Vector3.Normalize(direccionPersecucion) * movementSpeed);
        transform.forward = Vector3.Normalize(direccionPersecucion);
    }

    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.layer == 8)
        {
            Debug.Log("Han pillado al jugador");
            controller.enabled = false;
            perseguido.transform.position = new Vector3(680.26f, 144.70f, 423.88f);
            controller.enabled = true;
            ui_contador.GetComponent<AppleCounter>().Reset();
        }
    }

    private void perseguir(){
        animator.SetBool("isRunning", true);
        nav.SetDestination(target.position);
    }
}
