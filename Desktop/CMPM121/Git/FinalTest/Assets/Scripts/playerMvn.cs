using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerMvn : MonoBehaviour
{
    public float Hp;
    public float flashLength;
    private float flashCounter;
    private Renderer rend;
    private Color storedColor;

    public float speed;
    public float turnSpeed;
    private Quaternion targetRotation;

    public Vector3 movement;
    private Vector3 rotation;
    private Rigidbody rig;
    public Slider healthSlider;

    float angle;
    private float InputX;
    private float InputY;
    Transform cam;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        cam = Camera.main.transform;

        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");

    }

    void Update()
    {
        healthSlider.value = Hp;


        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
        if(flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }

    }

    void FixedUpdate()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");

        Vector3 newPosition = new Vector3(InputX, 0.0f, InputY);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);

    }


    public void HurtPlayer(int dmg)
    {
        Hp -= dmg;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.grey);
    }

    void calcDir()
    {
        angle = Mathf.Atan2(InputX, InputY);
        angle = Mathf.Rad2Deg * angle;
    }

    void rote()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
