using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName("Level03"))
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
