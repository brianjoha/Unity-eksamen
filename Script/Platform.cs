using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform turret;
    public Transform spawnPoint;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (playerDistance <= 10f)
        {
            if (Input.GetKeyDown("f"))
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        Instantiate(turret, spawnPoint.position, spawnPoint.rotation);
    }
}
