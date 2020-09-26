using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{
    string PrevScene;
    int invertedY;
    Toggle inGameToggle;
    // Start is called before the first frame update
    void Start()
    {
        inGameToggle = GameObject.Find("InvertYToggle").GetComponent<Toggle>();
        PrevScene = PlayerPrefs.GetString("SceneNumber");
        PlayerPrefs.SetString("SceneNumber", SceneManager.GetActiveScene().name);
        invertedY = PlayerPrefs.GetInt("invertedY");
        if (invertedY == 1)
            inGameToggle.isOn = true;
        else
            inGameToggle.isOn = false;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene(PrevScene);
    }

    public void Apply()
    {
        if (inGameToggle.isOn)
        {
            PlayerPrefs.SetInt("invertedY", 1);
            Back();
        }
        else
        {
            PlayerPrefs.SetInt("invertedY", 0);
            Back();
        }
    }
}
