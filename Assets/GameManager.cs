using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;
    public int maxScore = 5;

    public Text scoreText1;
    public Text scoreText2;

    [Header("Win/Lose UI")]
    public GameObject winLosePanel;
    public Text resultText;

    public BallControler ball;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
        if (winLosePanel != null) winLosePanel.SetActive(false);
    }

    public void ScorePlayer1()
    {
        scorePlayer1++;
        UpdateScoreUI();
        CheckWin();
        if (scorePlayer1 < maxScore) ball.LaunchBall();
    }

    public void ScorePlayer2()
    {
        scorePlayer2++;
        UpdateScoreUI();
        CheckWin();
        if (scorePlayer2 < maxScore) ball.LaunchBall();
    }

    void UpdateScoreUI()
    {
        if (scoreText1 != null) scoreText1.text = scorePlayer1.ToString();
        if (scoreText2 != null) scoreText2.text = scorePlayer2.ToString();
    }

    void CheckWin()
    {
        if (scorePlayer1 >= maxScore)
        {
            Win("PLAYER 1 WINS!");
        }
        else if (scorePlayer2 >= maxScore)
        {
            Win("PLAYER 2 WINS!");
        }
    }

    void Win(string msg)
    {
        ball.StopBall();
        if (winLosePanel != null) winLosePanel.SetActive(true);
        if (resultText != null) resultText.text = msg;
    }

    public void ResetGame()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateScoreUI();
        if (winLosePanel != null) winLosePanel.SetActive(false);
        ball.LaunchBall();
    }

    // 🔹 Fungsi untuk tombol Kembali
    public void BackToMenu()
    {
        SceneManager.LoadScene("samplescene");  // ganti "MainMenu" sesuai nama scene menu kamu
    }
}
