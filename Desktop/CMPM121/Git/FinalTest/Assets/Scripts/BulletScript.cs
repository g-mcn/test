using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Obj")
        {
            //Destroy(collision.gameObject);

            this.gameObject.SetActive(false);
        }
    }
}
