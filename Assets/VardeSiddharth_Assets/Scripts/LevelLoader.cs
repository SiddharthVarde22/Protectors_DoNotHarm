using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    int indexOfLevelToLoad;

    Button buttonComponent;

    // Start is called before the first frame update
    void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(indexOfLevelToLoad);
    }
}
