using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public float sensibilidad = 150f;
    public Transform player1;
    float rotacion_x = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        rotacion_x = rotacion_x - mouseY;
        rotacion_x = Mathf.Clamp(rotacion_x, -90f, 75f);

        transform.localRotation = Quaternion.Euler(rotacion_x, 0f, 0f);
        player1.Rotate(Vector3.up * mouseX);
    }
}
