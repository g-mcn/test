using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : Flee
{
    public float maxPrediction;
    private GameObject targetAux;
    private Enemy targetFoe;

    public override void Awake()
    {
        base.Awake();
        targetFoe = targetAux.GetComponent<Enemy>();
        targetAux = target;
        targetAux = new GameObject();
    }

    void OnDestroy()
    {
        Destroy(targetAux);
    }
    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = foe.velocity.magnitude;
        float prediction;
        if (speed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = distance / speed;
        }
        target.transform.position = targetAux.transform.position;
        targetAux.transform.position += targetFoe.velocity * prediction;
        return base.GetSteering();
    }
}
