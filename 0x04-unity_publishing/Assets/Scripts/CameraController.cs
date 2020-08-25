using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        // Without Capital T refers to our current object
        transform.position = new Vector3(player.position.x, 26, player.position.z)  + offset;
    }
}
 