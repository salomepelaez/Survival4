﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Se importaron los Namespace para poder utilizar sus componentes.
using NPC.Enemy;
using NPC.Ally;

public class Manager : MonoBehaviour
{
    public static bool inGame = true; // Se creó un booleano que controla el estado activo del juego.

    GameObject thePeople; // Se creó un GameoObject con este nombre, pues será utilizado para Zombies, Ciudadanos y Héroe.

    System.Random random = new System.Random(); 

    public const int maxGen = 25; // Se creó una variable constante para el número máximo de generación.
    public readonly int minGen; // Se declaró un readonly para el mínimo posible de generación de objetos. 

    // Las siguientes variables del tipo texto son las que abrigan los contadores del Canvas.
    public Text ZombiesNum;
    public Text VillagersNum;
    public string message;
    public static string goMessage;

    public static float sHero; // En esta línea se declara la velocidad estática del héroe, que luego se utiliza en la clase Hero.

    // A continuación en el constructor se asignó el número aleatorio para el mínimo de la creación de objetos.
    public Manager()
    {
        minGen = random.Next(5, 15);
    }

    void Awake()
    {
        sHero = Random.Range(0.1f, 0.2f);

        int rnd = Random.Range(minGen, maxGen); // La generación es producida entre el mínimo de objetos y el máximo.

        for (int j = 0; j < rnd; j++) // Este For genera los objetos siguiendo los límites establecidos.
        {
            thePeople = GameObject.CreatePrimitive(PrimitiveType.Cube); // El GameObject "thePeople" genera los cubos para zombies, aldeanos y héroes.

            // El Vector3 de posición es el que servirá para generar los cubos en una posición aleatoria.
            Vector3 posicion = new Vector3();
            posicion.x = Random.Range(-50, 50);
            posicion.z = Random.Range(-50, 50);
            thePeople.transform.position = posicion; // A los cubos se les asigna la posición aleatoria antes mencionada.
            
            thePeople.AddComponent<Rigidbody>(); // Se les agrega Rigidbody.
            thePeople.GetComponent<Rigidbody>().freezeRotation = true;
            int change = Random.Range(0, 2); // Se creó un Random con dos únicas opciones.

            // El siguiente bloque de código se encarga de generar el héroe, está separado, pues a diferencia de los miembros de la aldea, solo debe ser creado una vez.
            if (j == 0)
            {
                thePeople.AddComponent<Hero>(); // Se le agregan los componentes de la clase Hero.
                thePeople.AddComponent<HeroAim>(); // Igualmente se le agregan los componentes de HeroAim.
                thePeople.GetComponent<Renderer>().material.color = Color.black; // Se le asignó color negro para diferenciarlos de otros objetos.
            }

            else
            {
                switch (change) 
                {
                    case 0:
                        thePeople.AddComponent<Zombie>(); // Se agregan los componentes de su respectiva clase.
                        break;
                    case 1:
                        thePeople.AddComponent<Villagers>(); // Se agregan los componentes de su respectiva clase. 
                        break;
                }
            }
        }
    }

    private void Start()
    {
        goMessage = GameOver(); // Se asignó el mensaje para el momento en el que el jugador pierda.
    }

    private void Update()
    {
        // El siguiente bloque de código genera los contadores de NPC´s en la escena.
        int v = 0;
        int z = 0;

        foreach (Zombie zombie in Transform.FindObjectsOfType<Zombie>())
        {
            z = z + 1;
            ZombiesNum.text = "Zombies: " + z;
        }

        foreach (Villagers villagers in Transform.FindObjectsOfType<Villagers>())
        {
            v = v + 1;
            VillagersNum.text = "Villagers: " + v;
        }
    }

    // Se creó un String que retorna el mensaje, que luego es asignado en el Start.
    public string GameOver()
    {
        message = "Game Over";

        return message;
    }
}

