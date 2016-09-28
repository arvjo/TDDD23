using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    private GameState gameState;
    private int prevScene;
    void Start()
    {
        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
        prevScene = gameState.getPrevScene();
    }

    void OnGUI()
    {
        const int buttonWidth = 200;
        const int buttonHeight = 100;
        if(GUI.Button(new Rect( Screen.width/2 -(buttonWidth/2), (2*Screen.height/4)- (buttonHeight/2), buttonWidth, buttonHeight), "Start!"))
        {
            SceneManager.LoadScene("scene1");
        }


        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3 +50) - (buttonHeight / 2), buttonWidth, buttonHeight), "Tallents"))
        {
            SceneManager.LoadScene("Tallents");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth*2), (2 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight), "Continue"))
        {
            SceneManager.LoadScene(prevScene);
        }
    }
}
