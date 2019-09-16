using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Se importó el Namespace para poder utilizar sus componentes.
using NPC;
using NPC.Enemy;

namespace NPC // Este Namespace abriga los otros dos correspondientes: Ally and Enemy
{
    namespace Ally // Este es el namespace anidado
    {
        public class Villagers : NPCConduct
        {
            public VillagersData villagersData; // Se creó una variable del Struct.
            public string message;
            public static string vNames;

            Vector3 direction;
            float attackRange;

            void Start()
            {
                target = FindObjectOfType<Zombie>().GetComponent<Transform>();

                transform.tag = "Villager"; // El cambiar el nombre de la etiqueta, permite encontrar de manera sencilla el objeto con el que se colisiona.
                transform.name = "Villager"; // Se cambió el nombre del objeto para poder identificarlo fácilmente.

                GetComponent<Renderer>().material.color = Color.yellow; // Se añadió el color amarillo a los aldeanos para poder distinguirlos de los zombies.

                // A continuación se añadieron las variables del tipo Random para la edad y nombre.
                // Este bloque de código se realizó en el Start, porque de esta manera se asignan las variables solo una vez por objeto creado.

                villagersData.age = Random.Range(15, 101);
                villagersData.peopleNames = (Names)Random.Range(0, 20);

                InvokeRepeating("NPCAssignment", 3.0f, 3.0f);

                vNames = PrintNames();

                npcSpeed = (15f * npcSpeed) / villagersData.age;              
            }

            private void Update()
            {
                NPCMove();
                Zombie closest = null;
                float closestDistance = 5.0f;

                foreach (var v in FindObjectsOfType<Zombie>())
                {
                    float distance = Vector3.Distance(v.transform.position, transform.position);

                    if (distance < closestDistance)
                    {
                        closest = v;
                        closestDistance = distance;
                        direction = Vector3.Normalize(v.transform.position - transform.position);
                        transform.position -= direction * npcSpeed * Time.deltaTime;
                    }
                }
            }

            public string PrintNames()
            {
                message = "Hola soy " + villagersData.peopleNames + ". Y tengo " + villagersData.age + " años.";
            
                return message;
            }


            public void OnCollisionEnter(Collision collision)
            {
                if (collision.transform.tag == "Zombie")
                {
                    gameObject.AddComponent<Zombie>();
                    Destroy(gameObject.GetComponent<Villagers>());
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

        public struct VillagersData // Este Struct almacena las variables.
        {
            public int age;
            public Names peopleNames;


            public static explicit operator ZombieData(VillagersData vD)
            {
                ZombieData zD = new ZombieData();
                zD.age = vD.age;

                return zD;
            }
        }
    }
}