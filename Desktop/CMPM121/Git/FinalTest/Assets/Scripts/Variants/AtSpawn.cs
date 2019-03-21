using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtSpawn : MonoBehaviour
{
    public bool taken;

    void OnTriggerStay(Collider other)
    {
        if(other.attachedRigidbody)
        {
            taken = true;
        }
    }
}
