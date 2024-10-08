using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject collectable;

    public float spawnInterval = 10f;
    public float minX = -2f;
    public float maxX = 2f;
    public float spawnY = 6f;
    public float fallSpeed = -1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyPrefab.transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);

            Vector2 spawnPosition = new Vector2(randomX, spawnY);

            GameObject objectToSpawn = Random.value > 0.5f ? enemyPrefab : collectable;

            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            spawnedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fallSpeed);


            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
