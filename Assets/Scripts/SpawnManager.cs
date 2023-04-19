using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public int enemyesToSpawn;
    //public Transform[] spawnPositions = new Transform[3];
    public Transform[] spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyesToSpawn == 0)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy()
    {
        //Spawn de enemigos de forma aleatoria
        /*Transform selectedSpawn = spawnPositions[Random.Range(0, spawnPositions.Length)];

        Instantiate (enemyPrefabs, selectedSpawn.position, selectedSpawn.rotation);*/

        //Spawn en cada punto
       /*foreach (Transform spawn in spawnPositions)
        {
            Instantiate (enemyPrefabs, spawn.position, spawn.rotation);
        }*/

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Instantiate(enemyPrefabs, spawnPositions[i]. position, spawnPositions[i].rotation);
        }

        enemyesToSpawn--;
    }
}
