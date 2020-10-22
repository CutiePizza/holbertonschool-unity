using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CutsceneController : MonoBehaviour
{
    
    public Camera cam;
    public GameObject player;
    public GameObject timerCanvas;
    private Animator anim;
    private PlayerController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {  
            //If normalizedTime is 0 to 1 means animation is playing, if greater than 1 means finished
            cam.gameObject.SetActive(true);
            controller.enabled = true;
            timerCanvas.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }
}
