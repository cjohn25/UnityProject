using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{ 
    void Start()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    } 
    public void PlayNow()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
