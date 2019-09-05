using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se importaron los Namespace para poder utilizar sus componentes.
using NPC.Enemy;
using NPC.Ally;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    HeroData hs; // Se creó una variable del Struct.
    GameObject pov; // Se creó un GameObject al que se le asignarán los componentes de la cámara. (pov: point of view)
    public readonly float sHero = Manager.sHero; // La variable se asignó como readonly, obteniéndola desde la clase Manager.
    public Text Message;

    void Start()
    {
        transform.name = "Hero"; // Se transformó su nombre para identificarlo más rápidamente.
        // Vector3 que almacena la posición, las otras dos variables la asignan de manera aleatoria en los ejes X y Z.
        Vector3 posicion = new Vector3();
        posicion.x = Random.Range(-30, 30);
        posicion.z = Random.Range(-30, 30);

        // Al GameObject se le asignaron los componentes de cámara, rotación y movimiento.
        GameObject pov = new GameObject();
        pov.AddComponent<Camera>();
        pov.AddComponent<HeroAim>();
        gameObject.AddComponent<HeroMove>();
        gameObject.GetComponent<HeroMove>().speed = sHero; // Se utilizaron los miembros del Enum "Speed", y se reasigna la velocidad.

        pov.transform.SetParent(this.transform);
        pov.transform.localPosition = Vector3.zero;
    }

    //Rotación en Y.
    public void Update()
    {
        float rotat = transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0.0f, rotat, 0.0f);

    }

    // La siguiente función es la encargada de imprimir los mensajes cuando hay colisión, utilizando las etiquetas.
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Villager")
        {
            Message.text = ;
        }

        if (collision.transform.tag == "Zombie")
        {
            collision.transform.GetComponent<Zombie>().PrintMessages();
        }
    }

    static float speed; // La velocidad se declaró como estática.
}

public struct HeroData // Este Struct almacena las variables.
{
    public static float sHero;
}