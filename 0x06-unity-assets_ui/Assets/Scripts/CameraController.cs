using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public Transform player;
    public Transform lookTarget;
    public float speed = 3.0f;
    private Vector3 offset = new Vector3(0, 1.5f, -6.25f);

    //Rotate
    public bool rotateAroundPlayer = true;

    public bool rotateAbovePlayer = true;

    public bool isInverted;
    public float rotationSpeed = 3.0f;

    int inverted;
    

    void Update()
    {
        inverted = PlayerPrefs.GetInt("invertedY");
        if (inverted == 1)
        {
            isInverted = true;
        }
        else
            isInverted = false;
    }


    void FixedUpdate()
    {
        Vector3 dPos = player.position + offset;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, speed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
       
    } 
    void LateUpdate()
    {
        if (rotateAroundPlayer && Input.GetMouseButton(1))
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            offset = camTurnAngle * offset;    
        }

        if (rotateAbovePlayer && Input.GetMouseButton(1))
        {   
            Vector3 vector;
            if (isInverted == false)
                vector = Vector3.left;
            else
                vector = Vector3.right;
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, vector);
            offset = camTurnAngle * offset;    
        }
    }
}

