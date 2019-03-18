using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMvn : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    private Quaternion targetRotation;

    private Vector3 movement;
    private Vector3 rotation;
    private Rigidbody rig;

    float angle;
    private float InputX;
    private float InputY;
    Transform cam;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");

        //movement = (InputX * transform.right + InputY * transform.forward).normalized * speed;
        //transform.position += movement * Time.deltaTime;

        Vector3 newPosition = new Vector3(InputX, 0.0f, InputY);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);


        // if (Mathf.Abs(InputX) < 1 && Mathf.Abs(InputY) < 1) return;

        // calcDir();
        // rote();
    }


    void calcDir()
    {
        angle = Mathf.Atan2(InputX, InputY);
        angle = Mathf.Rad2Deg * angle;
        //angle += cam.eulerAngles.y;
    }

    void rote()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
