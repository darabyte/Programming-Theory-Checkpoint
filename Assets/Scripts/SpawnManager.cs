using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnFrequency = 1f;
    private Vector3 spawnPoint;

    public GameObject mackerelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(0, 5, -35);
        Vector3 spawnOffset = Vector3.back * 0.1f;
        for(int i=0; i<GameManager.instance.mackerelPopulation; i++)
        {
            SpawnMackerel(spawnPoint + (i * spawnOffset));
        }
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
}
