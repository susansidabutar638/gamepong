using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameOver : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public string awalscene = "awalscene"; 

    public void ShowWinner(string winnerName)
    {
        Time.timeScale = 0f; 
        resultPanel.SetActive(true);
        resultText.text = winnerName + " WIN!";
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(awalscene);
    }
}
