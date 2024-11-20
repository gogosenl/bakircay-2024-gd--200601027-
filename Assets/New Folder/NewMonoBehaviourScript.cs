using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Spawn edilecek objeler
    public int objectCount = 10; // Toplam obje sayýsý
    public Vector3 spawnAreaSize = new Vector3(10, 1, 10); // Spawn alanýnýn boyutlarý

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                spawnAreaSize.y,
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[randomIndex], randomPosition, Quaternion.identity);
        }
    }
}
