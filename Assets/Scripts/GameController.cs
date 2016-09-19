using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public Vector3 spawnValues;
    public int enemyCount;
    // Use this for initialization
    void Start()
    {
        spawnPlayer();
        StartCoroutine(spawnEnemies(enemyCount));
       
    }

    void spawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(1,1,1);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(player, spawnPosition, spawnRotation);
    }

    IEnumerator spawnEnemies(int enemyCount)
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            for (int i = 0; i < enemyCount; ++i)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(spawnValues.y, -spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(3f);
            }
            yield return new WaitForSeconds(20f);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
