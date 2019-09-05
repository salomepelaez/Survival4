using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se importó el Namespace para poder utilizar sus componentes.
using NPC;
using NPC.Ally;

namespace NPC // Este Namespace abriga los otros dos correspondientes: Ally and Enemy
{
    namespace Enemy // Este es el namespace anidado
    {
        public class Zombie : NPCConduct
        {
            public ZombieData zombieData; // Se creó una variable del Struct.

            public void Start()
            {
                zombieData.taste = (MyTaste)Random.Range(0, 5); // Al igual que en la clase "Villagers", la variable Random se utilizó en el Start para asignarla una vez por objeto.  
                Coloring(); // Se llamó a la función que asigna los colores.
                InvokeRepeating("NPCMove", 3.0f, 3.0f);
                transform.tag = "Zombie"; // Se cambió el nombre de la etiqueta.
                transform.name = "Zombie"; // Se cambió el nombre del objeto para poder identificarlo fácilmente.

            }

            public void PrintMessages() // Esta función se encarga de generar los mensajes, utilizando los miembros del Enum.
            {
                Debug.Log("Waaaarr quiero comer " + (zombieData.taste));
            }

            public ZombieColor mC;

            public void Coloring() // Esta función asigna de manera aleatoria los colores, igualmente utilizando un Enum.
            {

                switch (Random.Range(0, 4))
                {
                    case 0:
                        mC = ZombieColor.Celeste;
                        break;

                    case 1:
                        mC = ZombieColor.Lila;
                        break;

                    case 2:
                        mC = ZombieColor.Verde;
                        break;
                }

                if (mC == ZombieColor.Celeste)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                }

                else if (mC == ZombieColor.Lila)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                }

                else if (mC == ZombieColor.Verde)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
            }

        }

        public struct ZombieData // Este Struct almacena todos los datos
        {           
            public MyTaste taste;
            public ZombieColor mC;
            public int age;
            public Names peopleNames;
                        
        }

        public enum MyTaste // Enum de los gustos
        {
            Cerebros,
            Corazones,
            Ojos,
            Orejas,
            Bocas
        }
              

        public enum ZombieColor // Enum de los colores
        {
            Celeste,
            Lila,
            Verde
        }
    }
}
