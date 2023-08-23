using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreUpdateSpeed;
    int currentScore;

    private void Start()
    {
        currentScore = 0;
        StartCoroutine(UpdateScoreText());
    }

    private IEnumerator UpdateScoreText()
    {
        int startScore = int.Parse(scoreText.text);
        int targetScore = currentScore;

        float elapsedTime = 0;

        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * (currentScore - startScore) / scoreUpdateSpeed;
            int newScore = Mathf.RoundToInt(Mathf.Lerp(startScore, targetScore, elapsedTime));
            scoreText.text = newScore.ToString();
            yield return null;
        }

        scoreText.text = currentScore.ToString(); // Ensure the final score is displayed accurately
    }

    public void IncreaseScore(int amount)
    {
        currentScore += amount;
        StartCoroutine(UpdateScoreText());
    }

    public int GetScore()
    {
        return currentScore;
    }
}
