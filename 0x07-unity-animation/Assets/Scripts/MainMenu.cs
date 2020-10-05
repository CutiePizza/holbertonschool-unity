using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("SceneNumber", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
       
}
