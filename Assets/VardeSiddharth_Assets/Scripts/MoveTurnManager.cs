using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurnManager : MonoBehaviour
{
    public static MoveTurnManager Instance { get; private set; }

    Transform playerTransform;

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

    public void SetPlayertransform(Transform player)
    {
        playerTransform = player;
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
}
