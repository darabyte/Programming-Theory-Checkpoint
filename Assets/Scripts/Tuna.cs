using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuna : Fish
{
    // Characteristics of a tuna
    private static float tunaSpeed = 3.5f;
    private static float tunaTimeBetweenDecisions = 3f;
    public static float probabilityOfBreeding = 0.0075f;
    public static float probabilityOfDrifter = 0.0065f;
    public static float tunaTimeToStarvation = 10f; // seconds

    private GameObject targetMackerel= null; 

    private void Start()
    {
         speed = tunaSpeed;
         timeBetweenDecisions = tunaTimeBetweenDecisions;
         timeToStarvation = tunaTimeToStarvation;
    }

    // Tuna eat mackerel
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mackerel"))
        {
            Destroy(other.gameObject);
            timeSinceLastMeal = 0;
        }
    }

    // Tuna swim towards the closest mackerel
    // POLYMORPHISM
    protected override void MakeDecision()
    {
        if (timeSinceDecision > timeBetweenDecisions || targetMackerel == null)
        {

            if (targetMackerel == null)
            {

                GameObject[] mackerels = GameObject.FindGameObjectsWithTag("Mackerel");

                if (mackerels.Length == 0)
                {
                    base.MakeDecision();
                    return;
                }
                else
                {
                    timeSinceDecision = 0;
                    int i_closest = 0;
                    float distance;
                    float closest_distance = 10_000;
                    for (int i = 1; i < mackerels.Length; i++)
                    {
                        distance = (transform.position - mackerels[i].transform.position).magnitude;
                        if (distance < closest_distance)
                        {
                            closest_distance = distance;
                            i_closest = i;
                        }
                    }
                    targetMackerel = mackerels[i_closest];
                }
            }

            objectivePosition = targetMackerel.transform.position;
            timeSinceDecision = 0;

            // Rotate fish to face their new goal (models are rotated 90 degrees)
            Vector3 directionOfTravel = objectivePosition - transform.position;
            if (directionOfTravel.magnitude > 0)
            {
                transform.rotation = Quaternion.LookRotation(directionOfTravel) * Quaternion.Euler(0, 90, 0);
            }
        }
        else
        {
            timeSinceDecision += Time.deltaTime;
        }
    }
}
