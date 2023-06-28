using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovements : MonoBehaviour
{
    Transform playerTransform;
    Vector3 directionToMove;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = MoveTurnManager.Instance.GetPlayerTransform();
        MoveTurnManager.Instance.SetAnimalMovements(this);
    }

    public void Move()
    {
        CalculateDirectionOfMovement();

        transform.position += directionToMove;
    }

    void CalculateDirectionOfMovement()
    {
        // calculate the direction
        directionToMove = MoveTurnManager.Instance.GetPlayerTransform().position - transform.position;

        //decide the random direction to move if both are not zero
        int randomvalue = Random.Range(0, 2);
        if(randomvalue == 0)
        {
            if (directionToMove.x != 0)
            {
                directionToMove.y = 0;
            }
        }
        else
        {
            if (directionToMove.y != 0)
            {
                directionToMove.x = 0;
            }
        }

        //normalize the direction so the entity moves only one tile
        directionToMove.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthSystem playerHealth;

        if(collision.TryGetComponent<PlayerHealthSystem>(out playerHealth))
        {
            playerHealth.HurtPlayer();
        }
    }
}
