using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MovementTurn
{
    Player,
    Animal
}

public class MoveTurnManager : MonoBehaviour
{
    public static MoveTurnManager Instance { get; private set; }

    Transform playerTransform;
    PlayerMovements playerMovements;
    AnimalMovements animalMovemetns;
    MovementTurn movementTurn = MovementTurn.Player;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerRefrences(Transform player)
    {
        playerTransform = player;
        playerMovements = player.GetComponent<PlayerMovements>();
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }

    public void SetAnimalMovements(AnimalMovements animalMovements)
    {
        this.animalMovemetns = animalMovements;
        GameManager.Instance.OnAnimalSpawned();
    }

    public void ChangeMovementTurn(MovementTurn movementTurn)
    {
        this.movementTurn = movementTurn;

        if(movementTurn == MovementTurn.Player)
        {
            playerMovements.AllowToMoveAgain();
        }
        else
        {
            if (animalMovemetns != null)
            {
                StartCoroutine(MoveAnimal());
            }
            else
            {
                ChangeMovementTurn(MovementTurn.Player);
            }
        }
    }

    IEnumerator MoveAnimal()
    {
        yield return new WaitForSeconds(1);
        if (animalMovemetns != null)
        {
            animalMovemetns.Move();
        }
        ChangeMovementTurn(MovementTurn.Player);
    }
}
