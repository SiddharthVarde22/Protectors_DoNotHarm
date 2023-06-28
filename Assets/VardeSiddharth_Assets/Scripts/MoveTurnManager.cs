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

    private void Update()
    {
        
    }

    public void SetPlayerRefrences(Transform player)
    {
        playerTransform = player;
        playerMovements = player.GetComponent<PlayerMovements>();
    }

    public void SetAnimalMovements(AnimalMovements animalMovements)
    {
        this.animalMovemetns = animalMovements;
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
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
            StartCoroutine(MoveAnimal());
        }
    }

    IEnumerator MoveAnimal()
    {
        yield return new WaitForSeconds(1);
        animalMovemetns.Move();
        ChangeMovementTurn(MovementTurn.Player);
    }
}
