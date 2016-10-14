using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    private GameState gameState;
    public GameObject enemy;
    public GameObject player;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public Vector3 spawnValues;
    public int enemyCount;
    private int enemyLives;
    public bool gameOver = false;
    private int currentScene;
    private bool showButton = false;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        spawnPlayer();
        if (currentScene < 4)
        {
            enemyLives = enemyCount * currentScene;
        }else
        {         
            enemyLives = enemyCount * currentScene + enemyCount;
            Debug.Log(enemyLives);
        }
        StartCoroutine(spawnEnemies(enemyCount,currentScene));
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
            if (currentScene >= 2)
            {
               // for (int x = 0; x < 1; ++x)
                //{
                    Vector3 spawnPosition2 = new Vector3(spawnValues.x - 90, Random.Range(spawnValues.y, -spawnValues.y), spawnValues.z);
                    Instantiate(enemy3, spawnPosition2, spawnRotation);
                   
                //}
                
               
            }
          
           
            yield return new WaitForSeconds(1f);
            if (currentScene >= 3)
            {
               
                    Vector3 spawnPosition3 = new Vector3(Random.Range(spawnValues.x, -spawnValues.x), spawnValues.y, spawnValues.z);
                    Instantiate(enemy4, spawnPosition3, spawnRotation);               
            }

            if (currentScene == 4)
            {
                for (int x = 0; x < 2; ++x)
                {
                    Vector3 spawnPosition4 = new Vector3(Random.Range(spawnValues.x, -spawnValues.x), spawnValues.y - 35, spawnValues.z);
                    Instantiate(enemy2, spawnPosition4, spawnRotation);
                }
            }

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
            
            gameState.setCleard();
            showButton = true;
            Time.timeScale = 0;
            

        }
    }
    void OnGUI()
    {
        const int buttonWidth = 200;
        const int buttonHeight = 100;
        if (showButton == true)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight), "Next Level"))
            {      
                ++currentScene;
                SceneManager.LoadScene(currentScene);
            }
        }
    }

}
