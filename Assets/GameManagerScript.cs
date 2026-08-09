using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public GameObject gameOverUI;
    [SerializeField] public GameObject VictoryOverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {

        gameOverUI.SetActive(true);
    }
    public void RestartGame()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Victory()
    { 
        VictoryOverScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        //sample//ssdasd
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
