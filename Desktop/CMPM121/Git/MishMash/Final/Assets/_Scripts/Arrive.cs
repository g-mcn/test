using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : enemyBehaviour
{
    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float targetSpeed;
        if(distance < targetRadius)
        {
            return steering;
        }
        if(distance > slowRadius)
        {
            targetSpeed = foe.maxSpeed;
        }
        else
        {
            targetSpeed = foe.maxSpeed * distance / slowRadius;
        }

        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering.linear = desiredVelocity - foe.velocity;
        steering.linear /= timeToTarget;
        if(steering.linear.magnitude > foe.maxAccel)
        {
            steering.linear.Normalize();
            steering.linear *= foe.maxAccel;
        }
        return steering;
    }
}
