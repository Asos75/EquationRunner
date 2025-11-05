using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("PowerUps")]
    public PowerUp[] powerUps;

    [Header("Spawn Settings")]
    public Transform spawnPoint;    
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 15f;

    public float xOffsetRange = 5f;   
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            int index = Random.Range(0, powerUps.Length);
            PowerUp chosenPowerUp = powerUps[index];

            float randomX = Random.Range(-xOffsetRange, xOffsetRange);
            Vector3 spawnPos = spawnPoint.position + new Vector3(randomX, 0, 0);

PowerUp spawned = Instantiate(chosenPowerUp, spawnPos, chosenPowerUp.transform.rotation);

    Debug.Log("Rotation X: " + spawned.transform.rotation.eulerAngles.x);        }
    }
}
