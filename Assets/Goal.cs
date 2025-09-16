using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal = false;  

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (isLeftGoal)
                GameManager.Instance.ScorePlayer2();
            else
                GameManager.Instance.ScorePlayer1();
        }
    }
}
