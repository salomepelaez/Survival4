using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Se importó el Namespace para poder utilizar sus componentes.
using NPC;

namespace NPC // Este Namespace abriga los otros dos correspondientes: Ally and Enemy
{
    namespace Enemy // Este es el namespace anidado
    {
        public class Zombie : MonoBehaviour
        {
            ZombieData zombieData; // Se creó una variable del Struct.

            public void Start()
            {
                zombieData.taste = (MyTaste)Random.Range(0, 5); // Al igual que en la clase "Villagers", la variable Random se utilizó en el Start para asignarla una vez por objeto.  
                Coloring(); // Se llamó a la función que asigna los colores.
                InvokeRepeating("ZombieMove", 3.0f, 3.0f); // Se utilizó una función de repetición para el movimiento de los zombies.
                transform.tag = "Zombie"; // Se cambió el nombre de la etiqueta.
                transform.name = "Zombie"; // Se cambió el nombre del objeto para poder identificarlo fácilmente.
            }

            // En el Update se asignaron las posibilidades de movimiento, basándose en una función creada unas líneas más abajo.
            public void Update()
            {
                float zombieSpeed = 0.3f; // Se creó una variable para la velocidad de los zombies.
                float rotationSpeed = 25f; // Se creó una variable mucho mayor que la velocidad general del zombie, para que su rotación pueda ser visible.

                if (move == "Forwards")
                {
                    transform.position += transform.forward * zombieSpeed * Time.deltaTime;
                }

                else if (move == "Backwards")
                {
                    transform.position -= transform.forward * zombieSpeed * Time.deltaTime;
                }

                else if (move == "Right")
                {
                    transform.position += transform.right * zombieSpeed * Time.deltaTime;
                }

                else if (move == "Left")
                {
                    transform.position -= transform.right * zombieSpeed * Time.deltaTime;
                }

                else if (move == "Idle")
                {
                    // ...
                }

                else if (move == "Rotating")
                {
                    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                }
            }

            public Move zM;
            string move;

            // Esta es la función de movimiento antes mencionada.
            void ZombieMove() // Se encarga de asignar variables aleatorias, creando las posibilidades de dirección.
            {
                switch (Random.Range(0, 6))
                {
                    case 0:

                        zM = Move.Moving;
                        move = "Forwards";
                        break;

                    case 1:
                        zM = Move.Moving;
                        move = "Backwards";
                        break;

                    case 2:
                        zM = Move.Moving;
                        move = "Right";
                        break;

                    case 3:
                        zM = Move.Moving;
                        move = "Left";
                        break;

                    case 4:
                        zM = Move.Idle;
                        move = "Idle";
                        break;

                    case 5:
                        zM = Move.Rotating;
                        move = "Rotating";
                        break;
                }
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
            public Move zM;
            public MyTaste taste;
            public ZombieColor mC;
            public string move;
        }

        public enum MyTaste // Enum de los gustos
        {
            Cerebros,
            Corazones,
            Ojos,
            Orejas,
            Bocas
        }

        public enum Move // Enum del movimiento
        {
            Idle,
            Moving,
            Rotating
        }

        public enum ZombieColor // Enum de los colores
        {
            Celeste,
            Lila,
            Verde
        }
    }
}
