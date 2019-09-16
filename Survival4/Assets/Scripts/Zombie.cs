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
            public string message;
            public static string zMessage;

            Vector3 direction;
            float attackRange;

            public void Start()
            {
                target = FindObjectOfType<Hero>().GetComponent<Transform>();
                
                zombieData.taste = (MyTaste)Random.Range(0, 5); // Al igual que en la clase "Villagers", la variable Random se utilizó en el Start para asignarla una vez por objeto.  
                Coloring(); // Se llamó a la función que asigna los colores.
                InvokeRepeating("NPCAssignment", 3.0f, 3.0f);
                transform.tag = "Zombie"; // Se cambió el nombre de la etiqueta.
                transform.name = "Zombie"; // Se cambió el nombre del objeto para poder identificarlo fácilmente.
                zMessage = PrintMessages();

                zombieData.age = Random.Range(15, 101);

                npcSpeed = (15f * npcSpeed) / zombieData.age;
                
            }

            private void Update()
            {
                NPCMove();

                Villagers closest = null;
                float closestDistance = 5.0f;

                foreach (var v in FindObjectsOfType<Villagers>())
                {
                    float distance = Vector3.Distance(v.transform.position, transform.position);

                    if (distance < closestDistance)
                    {
                        closest = v;
                        closestDistance = distance;
                        direction = Vector3.Normalize(v.transform.position - transform.position);
                        transform.position += direction * npcSpeed * Time.deltaTime;
                    }
                }
            }

            public string PrintMessages() // Esta función se encarga de generar los mensajes, utilizando los miembros del Enum.
            {
                message = "Waaaarr, soy un Zombie, quiero comer " + zombieData.taste + ", y tengo " + zombieData.age + " años.";
            
                return message;
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
