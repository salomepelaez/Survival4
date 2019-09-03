using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Se importó el Namespace para poder utilizar sus componentes.
using NPC;

namespace NPC // Este Namespace abriga los otros dos correspondientes: Ally and Enemy
{
    namespace Ally // Este es el namespace anidado
    {
        public class Villagers : MonoBehaviour
        {
            VillagersData villagersData; // Se creó una variable del Struct.

            void Start()
            {
                transform.tag = "Villager"; // El cambiar el nombre de la etiqueta, permite encontrar de manera sencilla el objeto con el que se colisiona.
                transform.name = "Villager"; // Se cambió el nombre del objeto para poder identificarlo fácilmente.

                GetComponent<Renderer>().material.color = Color.yellow; // Se añadió el color amarillo a los aldeanos para poder distinguirlos de los zombies.

                // A continuación se añadieron las variables del tipo Random para la edad y nombre.
                // Este bloque de código se realizó en el Start, porque de esta manera se asignan las variables solo una vez por objeto creado.

                villagersData.age = Random.Range(15, 101);
                villagersData.peopleNames = (Names)Random.Range(0, 20);
                InvokeRepeating("VillagerMove", 3.0f, 3.0f);
            }

            public void Update()
            {
                float villagerSpeed = 1f; // Se creó una variable para la velocidad de los zombies.
                float rotationSpeed = 25f; // Se creó una variable mucho mayor que la velocidad general del zombie, para que su rotación pueda ser visible.

                if (move == "Forwards")
                {
                    transform.position += transform.forward * villagerSpeed * Time.deltaTime;
                }

                else if (move == "Backwards")
                {
                    transform.position -= transform.forward * villagerSpeed * Time.deltaTime;
                }

                else if (move == "Right")
                {
                    transform.position += transform.right * villagerSpeed * Time.deltaTime;
                }

                else if (move == "Left")
                {
                    transform.position -= transform.right * villagerSpeed * Time.deltaTime;
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

            public void PrintNames() // Esta función es la encargada de imprimir los mensajes con las variables de los Enums.
            {
                Debug.Log("Hola soy " + villagersData.peopleNames + ". Y tengo " + villagersData.age + " años.");
            }

            public Move zM;
            string move;

            // Esta es la función de movimiento antes mencionada.
            void VillagerMove() // Se encarga de asignar variables aleatorias, creando las posibilidades de dirección.
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

        }

        public enum Names // Este Enum abriga los nombres.
        {
            Rose,
            Ophelie,
            Celeste,
            Mérida,
            Catrina,
            Dean,
            Will,
            Lucas,
            Dustin,
            Mike,
            Sophie,
            Isabella,
            Amelie,
            Charlotte,
            Milo,
            Dante,
            Ariel,
            Suhail,
            Jake,
            David
        }

        public enum Move // Enum del movimiento
        {
            Idle,
            Moving,
            Rotating
        }

        public struct VillagersData // Este Struct almacena las variables.
        {
            public Move zM;
            public int age;
            public Names peopleNames;
            public string move;
        }
    }
}