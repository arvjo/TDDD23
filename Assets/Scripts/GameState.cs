using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    private static GameState gameStateInstance;
    private TallentTree tallentTree;
    private int currentScene;
    private int previousScene;
    private bool [] cleardLevels;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this.gameObject);
        tallentTree = GameObject.FindWithTag("TallentTree").GetComponent<TallentTree>();

        cleardLevels = new bool[2];

        if (gameStateInstance == null)
        {
            for (int i = 0; i < 2; ++i)
            {
                cleardLevels[i] = false;
                Debug.Log(" hej" + cleardLevels[i]);
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
        if (gameStateInstance.currentScene != 3)
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
        cleardLevels[currentScene-1] = true;  
        for(int i = 0; i < cleardLevels.Length; ++i)
        {
            if (cleardLevels[i]== true)
            {
                tallentTree.addTPoints();
            }
        }
    }
   
}
