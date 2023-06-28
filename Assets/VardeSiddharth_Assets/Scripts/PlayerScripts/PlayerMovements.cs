using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    int maxGridXSize = 7, maxGridYSize = 7;

    float horizontalInput, verticalInput;
    Vector3 nextPosition;

    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        MoveTurnManager.Instance.SetPlayerRefrences(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            nextPosition =  transform.position + (transform.right * horizontalInput);
            nextPosition.x = Mathf.Clamp(nextPosition.x, 0, maxGridXSize);
            transform.position = nextPosition;
            OnPlayerMovementComplete();
        }
        else if (Input.GetButtonDown("Vertical"))
        {
            nextPosition = transform.position + (transform.up * verticalInput);
            nextPosition.y = Mathf.Clamp(nextPosition.y, 0, maxGridYSize);
            transform.position = nextPosition;
            OnPlayerMovementComplete();
        }
    }

    void OnPlayerMovementComplete()
    {
        canMove = false;
        MoveTurnManager.Instance.ChangeMovementTurn(MovementTurn.Animal);
    }

    public void AllowToMoveAgain()
    {
        canMove = true;
    }
}
