using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCConduct : MonoBehaviour
{
    Vector3 direction;
    public float attackRange = 5f;
    public GameObject player;

    void Start()
    {        
        player.AddComponent<Hero>();               
    }

    public void Update()
    {
        //player = new GameObject();
        float NPCSpeed = 2f; // Se creó una variable para la velocidad de los zombies.
        float rotationSpeed = 25f; // Se creó una variable mucho mayor que la velocidad general del zombie, para que su rotación pueda ser visible.

        if (move == "Forwards")
        {
            float rotat = transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0.0f, rotat, 0.0f);
            transform.position += transform.forward * NPCSpeed * Time.deltaTime;
        }

        else if (move == "Idle")
        {
            // ...
        }

        else if (move == "Rotating")
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

       /* Vector3 myVector = player.transform.position;
        float distance = myVector.magnitude;
        
        if(distance < attackRange)
        {
            m = Move.Pursuing;
        }

        if(m == Move.Pursuing)
        {
            direction = Vector3.Normalize(player.transform.position - transform.position);
            transform.position += direction * NPCSpeed * Time.deltaTime;
        }*/
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
                move = "Forwards";
                break;
                           
            case 1:
                m = Move.Idle;
                move = "Idle";
                break;

            case 2:
                m = Move.Rotating;
                move = "Rotating";
                break;

            case 3:
                m = Move.Pursuing;
                move = "Pursuing";
                break;
        }
    }

    public enum Move // Enum del movimiento
    {
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


