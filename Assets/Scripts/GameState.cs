using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    private static GameState gameStateInstance;
    private TallentTree tallentTree;
    private int currentScene;
    private int previousScene;
    private bool [] cleardLevels;
    private int currentLevel;
    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this.gameObject);
        tallentTree = GameObject.FindWithTag("TallentTree").GetComponent<TallentTree>();

        cleardLevels = new bool[4];

        if (gameStateInstance == null)
        {
            for (int i = 0; i < 2; ++i)
            {
                cleardLevels[i] = false;
            }
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
        if (gameStateInstance.currentScene > 0 && gameStateInstance.currentScene < 5 )
        {
            
            gameStateInstance.previousScene = gameStateInstance.currentScene;
          
        }
    }

    public int getPrevScene()
    {
        return gameStateInstance.previousScene;
    }

    public void setCleard()
    {
        if (cleardLevels[currentScene - 1] == false) { 
            cleardLevels[currentScene - 1] = true;
            tallentTree.addTPoints();         
        }
    }
    public int getCleard()
    {
       
        for(int i = 0; i < cleardLevels.Length; ++i)
        {
            currentLevel = i+1;
            if (cleardLevels[i] == false)
                break;
        }
        return currentLevel;
    }
   
}
