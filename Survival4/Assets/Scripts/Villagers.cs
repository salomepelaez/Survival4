using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            void Start()
            {
                transform.tag = "Villager"; // El cambiar el nombre de la etiqueta, permite encontrar de manera sencilla el objeto con el que se colisiona.
                transform.name = "Villager"; // Se cambió el nombre del objeto para poder identificarlo fácilmente.

                GetComponent<Renderer>().material.color = Color.yellow; // Se añadió el color amarillo a los aldeanos para poder distinguirlos de los zombies.

                // A continuación se añadieron las variables del tipo Random para la edad y nombre.
                // Este bloque de código se realizó en el Start, porque de esta manera se asignan las variables solo una vez por objeto creado.

                villagersData.age = Random.Range(15, 101);
                villagersData.peopleNames = (Names)Random.Range(0, 20);

                InvokeRepeating("NPCMove", 3.0f, 3.0f);
            }
            
            public void PrintNames() // Esta función es la encargada de imprimir los mensajes con las variables de los Enums.
            {
               Debug.Log("Hola soy " + villagersData.peopleNames + ". Y tengo " + villagersData.age + " años.");
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
                        
        }
    }
}