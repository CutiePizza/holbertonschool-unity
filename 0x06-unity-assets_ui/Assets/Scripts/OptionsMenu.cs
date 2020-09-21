using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{
    string PrevScene;
    // Start is called before the first frame update
    void Start()
    {
        PrevScene = PlayerPrefs.GetString("SceneNumber");
        PlayerPrefs.SetString("SceneNumber", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene(PrevScene);
    }
}
