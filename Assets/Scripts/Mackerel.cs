using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Mackerel : Fish 
{
    // Characteristics of a mackerel
    private static float mackerelSpeed = 3;
    private static float mackerelTimeBetweenDecisions = 100;
    public static float probabilityOfBreeding = 0.1f; // Expected new fish per spawn period per fish
    public static float probabilityOfDrifter = 0f;
    private static float mackerelTimeToStarvation = 10_000;

    private void Start()
    {
        speed = mackerelSpeed;
        timeBetweenDecisions = mackerelTimeBetweenDecisions;
        timeToStarvation = mackerelTimeToStarvation;
    }

}