using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private GameState gameState;
    public GameObject enemy;
    public GameObject player;
    public GameObject enemy2;
    public Vector3 spawnValues;
    public int enemyCount;
    private int enemyLives;
    public bool gameOver = false;
    private int currentScene;
    // Use this for initialization
    void Start()
    {
        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        spawnPlayer();
        enemyLives = enemyCount;
        StartCoroutine(spawnEnemies(enemyCount,currentScene-1));
    }

    void spawnPlayer()
    {
        
        Vector3 spawnPosition = new Vector3(1,1,1);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(player, spawnPosition, spawnRotation);
    }

    IEnumerator spawnEnemies(int enemyCount, int currentScene)
    {

        yield return new WaitForSeconds(2f);
    
        for (int i = 0; i < enemyCount; ++i)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(spawnValues.y, -spawnValues.y), spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemy, spawnPosition, spawnRotation);        
          
            yield return new WaitForSeconds(3f);
               
         
            //yield return new WaitForSeconds(20f);
        }
        
    }
    
    public void setECount()
    {
        --enemyLives;
    }

    public void GameOver()
    {
        gameOver = true;       
    }

	
	// Update is called once per frame
	void Update () {
        if (gameOver == true)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (enemyLives == 0)
        {
            ++currentScene;
            gameState.setCleard();
            SceneManager.LoadScene(currentScene);
        }
    }
}
