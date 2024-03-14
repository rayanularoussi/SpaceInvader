using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int hiScore = 0;
    public int enemyKilledValue = 0;
    public TMP_Text scoreText;
    public TMP_Text hiScoreText;
    public string hiScoreFileName;
    public int enemyRemaining = 55;

    void Start()
    {
        LoadHiScore();
    }

    void Update()
    {
        if(enemyRemaining == 0)
        {
            SceneManager.LoadScene("Credits");
        }
        if (enemyKilledValue != 0)
        {
            score += enemyKilledValue;
            ScoreUpdate();
            enemyKilledValue = 0;

            if (score > hiScore)
            {
                hiScore = score;
                SaveHiScore();
            }
        }
    }

    void ScoreUpdate()
    {
        string pointString = "SCORE\n" + score.ToString("0000");
        scoreText.text = pointString;
    }

    void LoadHiScore()
    {
        TextAsset hiScoreTextAsset = Resources.Load<TextAsset>(hiScoreFileName);
        if (hiScoreTextAsset != null)
        {
            hiScore = int.Parse(hiScoreTextAsset.text);
            HiScoreUpdate();
        }
        else
        {
            Debug.LogWarning("Hi-score file not found in Resources.");
        }
    }

    void SaveHiScore()
    {
        string filePath = Path.Combine(Application.dataPath, "Resources", hiScoreFileName + ".txt");
        File.WriteAllText(filePath, hiScore.ToString());
        HiScoreUpdate();
    }

    void HiScoreUpdate()
    {
        string pointString = "HI-SCORE\n" + hiScore.ToString("0000");
        hiScoreText.text = pointString;
    }
}
