using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TallentTree : MonoBehaviour {

    private int bullets = 1;
    // Use this for initialization
    private static TallentTree tallentTreeInstance;
    private bool showButton = true;
    private int currentScene;

    void Awake () {
        DontDestroyOnLoad(this.gameObject);
        

        if (tallentTreeInstance == null)
        {
            tallentTreeInstance = this;
        }else
        {
            tallentTreeInstance.currentScene = SceneManager.GetActiveScene().buildIndex;
            tallentTreeInstance.showButton = true;
            Destroy(this.gameObject);
        }

    }
    void OnGUI()
    {
        const int buttonWidth = 200;
        const int buttonHeight = 100;
       
        if (showButton && currentScene == 4)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight), "2 bullets!"))
            {
                ++bullets;
                Debug.Log(bullets);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3 + 50) - (buttonHeight / 2), buttonWidth, buttonHeight), "Menu"))
            {
                SceneManager.LoadScene("menu");
                showButton = false;
            }
        }
    }
	
    public int getExtraBullets()
    {
        return bullets;
    }
	
}
