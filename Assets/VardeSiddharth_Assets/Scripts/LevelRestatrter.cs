using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelRestatrter : MonoBehaviour
{
    Button buttonComponent;
    // Start is called before the first frame update
    void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(RestartTheLevel);
    }

    public void RestartTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
