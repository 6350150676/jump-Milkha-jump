using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public Vector3 spawnPos =new Vector3(25,2,0);
    public float startDelay = 2;
    public float frequency = 2;
    private PlayerController PlayerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnObstacle", startDelay, frequency);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (PlayerControllerScript.GameOver == false)
        {
            int randomIndex = Random.Range(0, ObstaclePrefabs.Length);
            Instantiate(ObstaclePrefabs[randomIndex], spawnPos, ObstaclePrefabs[randomIndex].transform.rotation);
        }
    }
}
