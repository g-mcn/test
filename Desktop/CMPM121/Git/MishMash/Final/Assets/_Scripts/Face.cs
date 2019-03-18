using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    protected GameObject targetAux;

    public override void Awake()
    {
        base.Awake();
        targetAux = targetAux;
        targetAux = new GameObject();
        targetAux.AddComponent<Enemy>();
    }

    void OnDestroy()
    {
        Destroy(target);
    }

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        if(direction.magnitude > 0.0f)
        {
            float targetOrientation = Mathf.Atan2(direction.x, direction.z);
            targetOrientation *= Mathf.Rad2Deg;
            target.GetComponent<Enemy>().orientation = targetOrientation;
        }
        return base.GetSteering();
    }
}
