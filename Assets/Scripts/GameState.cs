using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    private static GameState gameStateInstance;
    private int currentScene;
    private int previousScene;
    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this.gameObject);
       
        if (gameStateInstance == null)
        {    
            gameStateInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        gameStateInstance.currentScene = SceneManager.GetActiveScene().buildIndex;
        if (gameStateInstance.currentScene != 3)
        {
            gameStateInstance.previousScene = gameStateInstance.currentScene;
        }
    }

    public int getPrevScene()
    {
        return gameStateInstance.previousScene;
    }
}
