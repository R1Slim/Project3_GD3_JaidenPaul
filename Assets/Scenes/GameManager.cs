using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn 100 enemmies
        //when spawned disable the gameobject
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0), Quaternion.identity);
        }
    }
}
//make SpawnEnemy find first disabled enemy reset its value to the prefab than enable it and move it to a posistion  