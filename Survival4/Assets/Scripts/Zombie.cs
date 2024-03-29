﻿using System.Collections;
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

            Vector3 direction; // Se creó un Vector3 para la dirección.

            public void Start()
            {
                target = FindObjectOfType<Hero>().GetComponent<Transform>(); //Se asignó al héroe como target.
                
                zombieData.taste = (MyTaste)Random.Range(0, 5); // Al igual que en la clase "Villagers", la variable Random se utilizó en el Start para asignarla una vez por objeto.  
                Coloring(); // Se llamó a la función que asigna los colores.
                InvokeRepeating("NPCAssignment", 3.0f, 3.0f); // Se llama la repetición para el comportamiento.
                transform.tag = "Zombie"; // Se cambió el nombre de la etiqueta.
                transform.name = "Zombie"; // Se cambió el nombre del objeto para poder identificarlo fácilmente.
                
                if(zombieData.age == 0)
                    zombieData.age = Random.Range(15, 101); // Si la edad está en 0 se le asigna una.

                npcSpeed = (15f * npcSpeed) / zombieData.age; // Esta regla de tres inversa se encarga de asignar una velocidad, dependiendo de la edad.               
            }

            private void Update()
            {
                NPCMove(); 

                // El siguiente bloque de código lee la posición de los aldeanos, cuando la distancia es menor al rango, los zombies pasan a perseguirlos.
                Villagers closest = null;
                float closestDistance = 5.0f;

                foreach (var v in FindObjectsOfType<Villagers>())
                {
                    float distance = Vector3.Distance(v.transform.position, transform.position);

                    if (distance < closestDistance)
                    {
                        m = Move.Pursuing;
                        closest = v;
                        closestDistance = distance;
                        direction = Vector3.Normalize(v.transform.position - transform.position);
                        transform.position += direction * npcSpeed * Time.deltaTime;
                    }
                }

                // El siguiente bloque de código imprime los mensajes cuando el héroe entra en el rango de ataque. 
                float zombieAttack = Vector3.Distance(target.position, transform.position); 

                if (zombieAttack <= 5.0f && closest == null)
                {
                    StartCoroutine("PrintMessages");
                }                
            }

            IEnumerator PrintMessages() // Esta Corutina asigna el mensaje de los zombies.
            {
                Hero.Message.text = "Waaaarr, soy un Zombie, quiero comer " + zombieData.taste + ", y tengo " + zombieData.age + " años.";
                yield return new WaitForSeconds(3);
                Hero.Message.text = "";
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
