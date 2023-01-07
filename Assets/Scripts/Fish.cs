using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    protected float speed;
    protected float timeBetweenDecisions;
    protected float timeToStarvation;

    protected Vector3 objectivePosition;
    protected float timeSinceDecision = 1000f;
    protected float timeSinceLastMeal = 0f;

    // Define volume that fish can swim in
    protected Vector3 lowerLimit = new Vector3( -20f,  -10f, -10f);
    protected Vector3 upperLimit = new Vector3(20f, 10f, 10f);
    private float positionTolerance = .5f;

    // Default fish behaviour
    void Update()
    {
        MakeDecision();
        Swim();
        Starve();
    }

    // Change objective position
    // ENCAPSULATION
    protected virtual void MakeDecision()
    {
        if (timeSinceDecision > timeBetweenDecisions)
        {
            timeSinceDecision = 0;

            float xObjective = Random.Range(lowerLimit.x, upperLimit.x);
            float yObjective = Random.Range(lowerLimit.y, upperLimit.y);
            float zObjective = Random.Range(lowerLimit.z, upperLimit.z);
            objectivePosition = new Vector3(xObjective, yObjective, zObjective);

            // Rotate fish to face their new goal (models are rotated 90 degrees)
            Vector3 directionOfTravel = objectivePosition - transform.position;
            transform.rotation = Quaternion.LookRotation(directionOfTravel) * Quaternion.Euler(0, 90, 0);
        }
        else
        {
            timeSinceDecision += Time.deltaTime;
        }
    }

    // Move fish towards objective
    protected void Swim()
    {
        Vector3 directionToSwim = objectivePosition - transform.position;
        if(directionToSwim.magnitude > positionTolerance)
        {
            transform.Translate(directionToSwim.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            timeSinceDecision = 1000; // destination reached, time to choose another target
        }
        
    }

    private void Starve()
    {
        if (timeSinceLastMeal > timeToStarvation)
        {
            Destroy(gameObject);
        }

        timeSinceLastMeal += Time.deltaTime;
    }
}