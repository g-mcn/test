using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : enemyBehaviour
{
    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        float targetOrientation = target.GetComponent<Enemy>().orientation;
        float rotation = targetOrientation - foe.orientation;
        rotation = MapToRange(rotation);
        float rotationSize = Mathf.Abs(rotation);
        float targetRotation;
        if(rotationSize > slowRadius)
        {
            targetRotation = foe.maxRotation;
        }
        else
        {
            targetRotation = foe.maxRotation * rotationSize / slowRadius;
        }
        targetRotation *= rotation / rotationSize;
        steering.angular = targetRotation - foe.rotation;
        steering.angular /= timeToTarget;
        float angularAccel = Mathf.Abs(steering.angular);
        if(angularAccel > foe.maxAngularAccel)
        {
            steering.angular /= angularAccel;
            steering.angular *= foe.maxAngularAccel;
        }
        return steering;
    }
}
