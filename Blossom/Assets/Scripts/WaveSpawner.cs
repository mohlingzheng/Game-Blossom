using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform target;
    public GameObject[] enemyPrefabs;
    public float interval = 2f;
    public float spawnRadius;

    void Start()
    {
        StartCoroutine(spawnEnemy(interval, enemyPrefabs[0]));
        StartCoroutine(spawnEnemy(interval * 2, enemyPrefabs[1]));
    }
    IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector3 spawnPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 randomPos;
        randomPos.x = Random.Range(-1, 1);
        if (randomPos.x < 0)
            randomPos.x -= spawnRadius;
        else
            randomPos.x += spawnRadius;
        randomPos.z = Random.Range(-1, 1);
        if (randomPos.z < 0)
            randomPos.z -= spawnRadius * 2;
        else
            randomPos.z += spawnRadius * 2;
        randomPos.y = 0;
        spawnPos += randomPos;
        //spawnPos += Random.insideUnitSphere.normalized * spawnRadius;
        spawnPos.y = 0;
        GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
