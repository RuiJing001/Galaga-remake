using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreText;  // Reference to the first UI Text component to display the score.
    public Text scoreText2; // Reference to the second UI Text component to display the score.
    public Text scoreText3;
    public int score = 0;   // The player's score.
    public GameObject Level1Show;
    public GameObject Bosslevel;
    public int SpownLimit;
    private bool isbosschallange=false;
    private void Start()
    {
        // Initialize the score text.
        UpdateScoreText();
        Bosslevel.SetActive(false);
        Level1Show.SetActive(true); // Deactivate the GameObject
        // Start a coroutine to deactivate Level1Show after 2 seconds.
        StartCoroutine(DeactivateLevel1Show());
    }

    // Call this function to increase the player's score.
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Call this function to update the score displayed on the UI Text components.
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score.ToString();
        }

        if (scoreText2 != null)
        {
            scoreText2.text = " " + score.ToString();
        }
        if (scoreText3 != null)
        {
            scoreText3.text = " " + score.ToString();
        }
    }
    private void Update()
    {
        if (score >= SpownLimit&&!isbosschallange)
        {
            
            Bosslevel.SetActive(true);
            StartCoroutine(DeactivateLevel1Show());
        }
    }


    // Coroutine to deactivate Level1Show after 2 seconds.
    private IEnumerator DeactivateLevel1Show()
    {
        yield return new WaitForSeconds(1f); // Wait for 2 seconds
        Level1Show.SetActive(false); // Deactivate the GameObject
        Bosslevel.SetActive(false);
        isbosschallange = true;
    }



}
