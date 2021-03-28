using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] int timeToPlay = 10;

    SceneLoader sceneLoader;

    int currentCountDownValue;
    TextMeshProUGUI timerText;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Find game object to fix "Object reference not set to an instance of an object"
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        scoreText.text = Scorer.score.ToString();
        StartCoroutine(StartCountDown());
    }


    IEnumerator StartCountDown()
    {
        currentCountDownValue = timeToPlay;
        while(currentCountDownValue >= 0 && !GameManager.answered)
        {
            timerText.text = currentCountDownValue.ToString();

            yield return new WaitForSeconds(1f);
            currentCountDownValue--;
        }

        // update score
        if(currentCountDownValue >= 0)
        {
            Scorer.score += long.Parse(timerText.text);
        }
        

        GameManager.answered = false;
        sceneLoader.LoadNewScene();
    }
}
