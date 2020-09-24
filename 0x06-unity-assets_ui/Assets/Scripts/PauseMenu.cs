using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas options;
    public Button butt;
    Timer timer;
    bool triggered;
    public bool isPaused;
    GameObject trigger;
    string PrevScene;
    // Start is called before the first frame update
    void Start()
    {
        PrevScene = PlayerPrefs.GetString("SceneNumber");
        PlayerPrefs.SetString("SceneNumber", SceneManager.GetActiveScene().name);
        timer = this.GetComponent<Timer>();
        trigger = GameObject.Find("TimerTrigger");
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Cancel"))
            {
                if (isPaused == true)
                    Resume();
                else
                    Pause();
            }
        
    }
    public void Pause()
    {
        options.gameObject.SetActive(true);
        timer.enabled = false;
        isPaused = true;
    }

    public void Resume()
    {
        options.gameObject.SetActive(false);
        triggered = trigger.GetComponent<TimerTrigger>().isTrigger;
        if (triggered == true)
            timer.enabled = true;
        isPaused = false;
    }

    void Awake()
    {
        butt.onClick.AddListener(() => {Resume();});
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        SceneManager.LoadScene(4);
    }
}
