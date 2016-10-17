using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    private GameState gameState;
    private int currentLevel;
    void Start()
    {
        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
        currentLevel = gameState.getCleard();
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
            SceneManager.LoadScene(currentLevel);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth * 2), (2 * Screen.height / 3 + 50) - (buttonHeight / 2), buttonWidth, buttonHeight), "Controlls"))
        {
            SceneManager.LoadScene("Controlls");
        }

        if (GUI.Button(new Rect(Screen.width / 2 + buttonWidth, (2 * Screen.height / 3) - (buttonHeight), buttonWidth, buttonHeight), "Quit"))
        {
            Application.Quit();
        }
      ;
    }
}
