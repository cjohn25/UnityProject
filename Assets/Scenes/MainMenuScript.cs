using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    public void PlayNow()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
