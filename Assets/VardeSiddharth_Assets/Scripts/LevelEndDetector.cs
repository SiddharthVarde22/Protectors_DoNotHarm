using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovements playerMovements;
        if(collision.TryGetComponent<PlayerMovements>(out playerMovements))
        {
            playerMovements.enabled = false;
            LevelManager.Instance.OnLevelEndReached();
        }
    }
}
