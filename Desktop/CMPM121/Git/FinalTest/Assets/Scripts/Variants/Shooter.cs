using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 100f;

    float timer;
    public int waitingTime;

    public AudioClip fire;
    public AudioSource enemyAudio;

    // Update is called once per frame
    void Update()
    {
        //Fire();

        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            enemyAudio.clip = fire;
            enemyAudio.Play();

            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidBody.AddForce(transform.forward * bulletSpeed);

            //Destroy(instBullet, .75F);
            timer = 0;
        }
    }

    IEnumerator Fire()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidBody.AddForce(transform.forward * bulletSpeed);

        //Destroy(instBullet, .75F);

        yield return new WaitForSeconds(3);
    }
}
