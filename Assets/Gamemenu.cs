using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Fungsi tombol Start
    public void StartGame()
    {
        SceneManager.LoadScene("awalscene"); 
    }

    // Fungsi tombol Quit
    public void QuitGame()
    {
        Debug.Log("Quit Game!"); 
        Application.Quit();      
    }
}
