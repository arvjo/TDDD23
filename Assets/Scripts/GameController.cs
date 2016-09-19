using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public Vector3 spawnValues;
    public int enemyCount;
    private bool gameOver;
    // Use this for initialization
    void Start()
    {
        gameOver = false;
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
    
        for (int i = 0; i < enemyCount; ++i)
        {
         
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(spawnValues.y, -spawnValues.y), spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemy, spawnPosition, spawnRotation);
            Debug.Log(gameOver);
            if (gameOver)
            {
                Debug.Log("BAJS111111111111111111111");
                break;
            }
            yield return new WaitForSeconds(3f);
               
         
            //yield return new WaitForSeconds(20f);
        }
        
    }

    public void GameOver()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        gameOver = true;
        Debug.Log(gameOver);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
