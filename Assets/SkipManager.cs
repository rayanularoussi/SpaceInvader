using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SkipManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public void StartCountdown()
    {
        StartCoroutine(CountdownToMenu());
    }

    IEnumerator CountdownToMenu()
    {
        for (int i = 5; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        SceneManager.LoadScene("Menu");
    }
}
