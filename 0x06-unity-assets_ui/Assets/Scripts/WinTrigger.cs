using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    Timer timer;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player = GameObject.Find("Player");
            timer = player.GetComponent<Timer>();
            timer.enabled = false;
            timer.timerText.color = Color.green;
            timer.timerText.fontSize = 80;
    }
}
