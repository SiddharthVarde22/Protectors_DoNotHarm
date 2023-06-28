using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool hasAnimalBeenKilled = false;

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

    public void OnAnimalHasBeenKilled()
    {
        hasAnimalBeenKilled = true;
    }

    public bool GetHasAnimalBeenKilled()
    {
        return hasAnimalBeenKilled;
    }

    public void OnAnimalSpawned()
    {
        hasAnimalBeenKilled = false;
    }
}
