using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUiBehaviour : MonoBehaviour
{
    [SerializeField]
    Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(QuitTheGame);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
