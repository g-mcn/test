using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public playerMvn player;
    //public float dist;

    public float Hp;
    public float rangeToHit;
    public Collider fist;

    public int scoreVal;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<playerMvn>();
    }

    void FixedUpdate()
    {
        rb.velocity = (transform.forward * speed);
        if(player == null)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {


        //if(Vector3.Distance(rb.transform.position, player.movement) < rangeToHit)
        //{
        //    Punch();
        //}

        transform.LookAt(player.transform.position);
        if(Hp == 0)
        {
            ScoreScript.score += scoreVal;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "bullet")
        {
            Hp--;
        }
    }

    //IEnumerator Punch()
    //{
    //    fist.enabled = true;
    //    yield return new WaitForSeconds(1);
    //    fist.enabled = false;
    //}
}
