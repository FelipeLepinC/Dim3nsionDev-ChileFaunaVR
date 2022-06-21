using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Sonidos : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] sonidos;
    public float volumen;
    private float tiempo_start = 0.0f;
    public float tiempo_end = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Musica();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end){
            Musica();
            tiempo_start = 0.0f;
        }
    }

    void Musica(){
        int r = Random.Range(0, sonidos.Length);
        source.PlayOneShot(sonidos[r], volumen);
    }
}
