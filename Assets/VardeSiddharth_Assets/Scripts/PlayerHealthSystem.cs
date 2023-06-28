using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField]
    int playerHealth = 3;
    [SerializeField]
    Transform playerHealthUiParent;

    [SerializeField]
    GameObject playerHeartIcon;

    // Start is called before the first frame update
    void Start()
    {
        ShowPlayerHealthUi();
    }

    public void HurtPlayer()
    {
        playerHealth--;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            //player deth
            return;
        }
        Destroy(playerHealthUiParent.GetChild(0).gameObject);
        ShowPlayerHealthUi();
    }

    void ShowPlayerHealthUi()
    {
        if(playerHealthUiParent.childCount < playerHealth)
        {
            for (int i = playerHealthUiParent.childCount; i < playerHealth; i++)
            {
                Instantiate(playerHeartIcon, playerHealthUiParent);
            }
        }
    }
}
