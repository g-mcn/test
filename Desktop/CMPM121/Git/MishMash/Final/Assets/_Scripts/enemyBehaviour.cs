using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public GameObject target;
    protected Enemy foe;

    public float weight = 1.0f;
    public float maxSpeed;
    public float maxAccel;
    public float maxRotation;
    public float maxAngularAccel;

    public virtual void Awake()
    {
        foe = gameObject.GetComponent<Enemy>();
    }

    public float MapToRange(float rotation)
    {
        if(Mathf.Abs(rotation) > 180.0f)
        {
            if(rotation < 0.0f)
            {
                rotation += 360.0f;
            }
            else
            {
                rotation -= 360.0f;
            }
        }
        return rotation;
    }

    public Vector3 OriToVec(float orientation)
    {
        Vector3 vector = Vector3.zero;
        vector.x = Mathf.Sin(orientation * Mathf.Deg2Rad) * 1.0f;
        vector.z = Mathf.Cos(orientation * Mathf.Deg2Rad) * 1.0f;
        return vector.normalized;
    }

    public virtual void Update()
    {
        foe.SetSteering(GetSteering(), weight);
    }
    public virtual Steering GetSteering()
    {
        return new Steering();
    }

}
