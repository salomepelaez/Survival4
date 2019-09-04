using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Se importaron los Namespace para poder utilizar sus componentes.
using NPC.Enemy;
using NPC.Ally;



public class Manager : MonoBehaviour
{
    GameObject thePeople;

    public const int maxGen = 25; // Se creó una variable constante para el número máximo de generación.
    public readonly int minGen; // Se declaró un readonly para el mínimo posible de generación de objetos. 

    // Las siguientes variables del tipo texto son las que abrigan los contadores del Canvas.
    public Text ZombiesNum;
    public Text VillagersNum;

    public static float sHero; // En esta línea se declara la velocidad estática del héroe, que luego se utiliza en la clase Hero.

    public void Awake() // A continuación se asigna la velocidad mencionada del héroe.
    {
        sHero = Random.Range(0.1f, 0.2f);
    }

    void Start()
    {
        int rnd = Random.Range(minGen, maxGen); // La generación es producida entre el mínimo de objetos y el máximo.

        for (int j = 0; j < rnd; j++) // Este For genera los objetos siguiendo los límites establecidos.
        {
            new minGenerator(minGen);
            thePeople = GameObject.CreatePrimitive(PrimitiveType.Cube); // El GameObject "thePeople" genera los cubos para zombies, aldeanos y héroes.

            // El Vector3 de posición es el que servirá para generar los cubos en una posición aleatoria.
            Vector3 posicion = new Vector3();
            posicion.x = Random.Range(-30, 30);
            posicion.z = Random.Range(-30, 30);
            thePeople.transform.position = posicion; // A los cubos se les asigna la posición aleatoria antes mencionada.
            thePeople.AddComponent<Rigidbody>(); // Se les agrega Rigidbody.
            thePeople.GetComponent<Rigidbody>().freezeRotation = true;
            int change = Random.Range(0, 2); // Se creó un Random con dos únicas opciones.

            // El siguiente bloque de código se encarga de generar el héroe, está separado pues a diferencia de los miembros de la aldea, solo debe ser creado una vez.
            if (j == 0)
            {
                thePeople.AddComponent<Hero>(); // Se le agregan los componentes de la clase Hero.
                thePeople.AddComponent<HeroAim>(); // Igualmente se le agregan los componentes de HeroAim.
                thePeople.GetComponent<Renderer>().material.color = Color.black; // Se le asignó color negro para diferenciarlos de otros objetos.
            }

            else
            {
                switch (change) // La primera posibilidad del Random genera los zombies, la segunda los aldeanos.
                {
                    case 0:
                        thePeople.AddComponent<Zombie>(); // Se agregan los componentes de su respectiva clase.
                        break;
                    case 1:
                        thePeople.AddComponent<Villagers>(); // Se agregan los componentes de su respectiva clase. 
                        break;
                }
            }

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
    }
    
}

// Quise hacer una clase diferente para utilizarla como constructor, en este se establece el readonly.
public class minGenerator
{
    int minGen = Random.Range(5, 15);
    public minGenerator(int g)
    {
        this.minGen = g;
        minGen = Random.Range(5, 15);
    }
}
