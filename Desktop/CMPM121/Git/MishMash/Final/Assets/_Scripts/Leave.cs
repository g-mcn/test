using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : enemyBehaviour
{
    public float escapeRadius;
    public float dangerRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 direction = transform.position - target.transform.position;

        float distance = direction.magnitude;
        if(distance > dangerRadius)
        {
            return steering;
        }
        float reduce;
        if(distance < escapeRadius)
        {
            reduce = 0f;
        }
        else
        {
            reduce = distance / dangerRadius * foe.maxSpeed;
        }
        float targetSpeed = foe.maxSpeed - reduce;

        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering.linear = desiredVelocity - foe.velocity;
        steering.linear /= timeToTarget;
        if (steering.linear.magnitude > foe.maxAccel)
        {
            steering.linear.Normalize();
            steering.linear *= foe.maxAccel;
        }
        return steering;

    }
}
