using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnPeriod = 0.1f; // seconds
    private Vector3 spawnPoint;

    public GameObject mackerelPrefab;
    public GameObject tunaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(0, 5, -25);
        Vector3 spawnOffset = Vector3.back * 0.1f;
        for(int i=0; i<GameManager.instance.mackerelPopulation; i++)
        {
            SpawnMackerel(spawnPoint + (i * spawnOffset));
        }

        InvokeRepeating("BreedFishes", spawnPeriod, spawnPeriod);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMackerel(Vector3 inSpawnPoint)
    {
        Instantiate(mackerelPrefab, inSpawnPoint, mackerelPrefab.transform.rotation);
    }

    private void SpawnMackerel()
    {
        SpawnMackerel(spawnPoint);
    }

    private void SpawnTuna()
    {
        Instantiate(tunaPrefab, spawnPoint, mackerelPrefab.transform.rotation);
    }

    private void BreedFishes()
    {
        if (NewFishShowsUp(Mackerel.probabilityOfBreeding, GameManager.instance.mackerelPopulation, Mackerel.probabilityOfDrifter))
        {
            SpawnMackerel();
        }

        if (NewFishShowsUp(Tuna.probabilityOfBreeding, GameManager.instance.tunaPopulation, Tuna.probabilityOfDrifter))
        {
            SpawnTuna();
        }
    }

    private bool NewFishShowsUp(float probabilityOfBreeding, int population, float probabilityOfDrifter)
    {
        float randUnit = UnityEngine.Random.Range(0f, 1f);
        //             1 - probability of no fish breeding (by the way one alone can't breed) AND no drifter showing up 
        if (randUnit < 1 - Math.Pow(1-probabilityOfBreeding, Math.Max(0, population-1)) * (1-probabilityOfDrifter))
        {
            return true;
        }

        return false;
    }

}
