using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } 

    [SerializeField]
    GameObject levelWinPanel, levelFailedPanel;
    [SerializeField]
    TextMeshProUGUI levelFailedText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnLevelEndReached()
    {
        if(GameManager.Instance.GetHasAnimalBeenKilled())
        {
            levelFailedText.text = "Level Failed!\n\nYou have killed the Protector";
            levelFailedPanel.SetActive(true);
        }
        else
        {
            levelWinPanel.SetActive(true);
        }
    }

    public void OnPlayerDied()
    {
        levelFailedText.text = "Level Failed!\n\nYou Died";
        levelFailedPanel.SetActive(true);
    }
}
