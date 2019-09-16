using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;

public class NPCConduct : MonoBehaviour
{
    Vector3 direction;
    float attackRange;
    public Transform target;

    public List<Villagers> FamilyAndFriends = new List<Villagers>();

    public void Update()
    {
        if (Manager.inGame == true)
        {
            attackRange = Vector3.Distance(target.position, transform.position);
            float npcSpeed = 0.3f; // Se creó una variable para la velocidad de los zombies.
            float rotationSpeed = 25f; // Se creó una variable mucho mayor que la velocidad general del zombie, para que su rotación pueda ser visible.
            //float runningSpeed = 0.2f;

            if (move == "Moving")
            {
                float rotat = transform.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0.0f, rotat, 0.0f);
                transform.position += transform.forward * npcSpeed * Time.deltaTime;
            }

            else if (move == "Idle")
            {
                // ...
            }

            else if (move == "Rotating")
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }

            
            if (attackRange < 5.0f)
            {   
                direction = Vector3.Normalize(target.transform.position - transform.position);
                transform.position += direction * npcSpeed * Time.deltaTime;
            }

            Villagers closest = null;
            float closestDistance = 5.0f;

            foreach (var v in FamilyAndFriends)
            {
                float distance = Vector3.Distance(v.transform.position, transform.position);

                if(distance < closestDistance)
                {
                    closest = v;
                    closestDistance = distance;
                    direction = Vector3.Normalize(v.transform.position - transform.position);
                    transform.position += direction * npcSpeed * Time.deltaTime;
                }

                Debug.Log(closestDistance);
            }    
                
            

            
        }
    }

    public Move m;
    string move;

    // Esta es la función de movimiento antes mencionada.
    void NPCMove() // Se encarga de asignar variables aleatorias, creando las posibilidades de dirección.
    {
        switch (Random.Range(0, 6))
        {
            case 0:
                m = Move.Moving;
                move = "Moving";
                break;
                           
            case 1:
                m = Move.Idle;
                move = "Idle";
                break;

            case 2:
                m = Move.Rotating;
                move = "Rotating";
                break;
        }
    }

    public enum Move // Enum del movimiento
    {
        Running,
        Idle,
        Moving,
        Rotating,
        Pursuing
    }

    public struct NPCData
    {
        public Move m;
    }
}


