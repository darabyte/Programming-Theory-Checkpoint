using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Fish
{

    // Characteristics of a shark
    private static float sharkSpeed = 2f;
    private static float sharkTimeBetweenDecisions = 10f;
    private static float timeBetweenDecisionsWhenHunting = 0.1f;
    public static float probabilityOfBreeding = 0.000f;
    public static float probabilityOfDrifter = 0.0015f;
    public static float sharkTimeToStarvation = 20f; // seconds

    private GameObject targetTuna = null;
    // Start is called before the first frame update
    void Start()
    {
        speed = sharkSpeed;
        timeBetweenDecisions = sharkTimeBetweenDecisions;
        timeToStarvation = sharkTimeToStarvation;
    }

    // Sharks eat everything (but only tuna or other sharks count as a meal)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tuna"))
        {
            Destroy(other.gameObject);
            timeSinceLastMeal = 0;
        }else if (other.gameObject.CompareTag("Mackerel"))
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("Shark"))
        {
            // The shark that ate last will be stronger, and eat the weaker shark
            // (Nature is brutal, man)
            if (other.gameObject.GetComponent<Shark>().timeSinceLastMeal > timeSinceLastMeal)
            {
                Destroy(other.gameObject);
                timeSinceLastMeal = 0;
            }
        }
    }

    // Sharks swim towards the closest tuna
    protected override void MakeDecision()
    {
        if (timeSinceDecision > timeBetweenDecisionsWhenHunting || targetTuna == null)
        {

            if (targetTuna == null)
            {

                GameObject[] tunas = GameObject.FindGameObjectsWithTag("Tuna");

                if (tunas.Length == 0)
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
                    for (int i = 1; i < tunas.Length; i++)
                    {
                        distance = (transform.position - tunas[i].transform.position).magnitude;
                        if (distance < closest_distance)
                        {
                            closest_distance = distance;
                            i_closest = i;
                        }
                    }
                    targetTuna = tunas[i_closest];
                }
            }

            objectivePosition = targetTuna.transform.position;
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