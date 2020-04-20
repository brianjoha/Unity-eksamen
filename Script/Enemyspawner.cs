using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public List<GameObject> spawnPoints = new List<GameObject>();
    public Transform spawnPoint;
    public GameObject target;
    private List<GameObject> enemies = new List<GameObject>();

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveNumber = 1;

    private void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    void SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }

        waveNumber++;

    }

    void SpawnEnemy()
    {

        foreach (GameObject spawnPoint in spawnPoints)
        {
            GameObject zombie = enemies[0];
            zombie.GetComponent<Chase>().target = target;


        }
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
