using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRender : MonoBehaviour
{
    public GameObject pipePrefab; 
    public int pipePoolSize = 5;
    public float spawnRate = 3f;
    public float pipeMin = -1.5f;
    public float pipeMax = 3.5f;

    private GameObject[] pipes;
    private int currentColumn = 0;

    private Vector2 objectPoolPosition = new Vector2 (-15,-25);
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;

        pipes = new GameObject[pipePoolSize];

        for(int i = 0; i < pipePoolSize; i++)
        {
            pipes[i] = (GameObject)Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
        { 
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(pipeMin, pipeMax);
            pipes[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn ++;

            if (currentColumn >= pipePoolSize) 
            {
                currentColumn = 0;
            }
        }
        
    }
}
