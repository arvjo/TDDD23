using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {
    private GameState gameState;
    private int previousScene;
    void Awake()
    {
        gameState = GameObject.FindWithTag("GameState").GetComponent<GameState>();
        previousScene = gameState.getPrevScene();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void MenuButton(string menu)
    {
        SceneManager.LoadScene(menu);
    }

    public void QuitButton()
    {
        Application.Quit();
    }


}
