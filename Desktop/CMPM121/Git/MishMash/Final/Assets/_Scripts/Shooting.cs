using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Space))
        {

            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidBody.AddForce(transform.forward * bulletSpeed);

            Destroy(instBullet, .75F);

        }
    }
}
