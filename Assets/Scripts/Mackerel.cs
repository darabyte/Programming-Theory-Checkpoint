using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Mackerel : Fish 
{
    private void Start()
    {
        // Characteristics of a mackerel
        speed = 3;
        timeBetweenDecisions = 100;
    }

}