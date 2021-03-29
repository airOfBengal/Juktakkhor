using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CDTimer : MonoBehaviour
{
    [SerializeField] int timeToPlay = 10;
    [SerializeField] float loadWaitingTime = 1f;
    [SerializeField] Animator timerAnimator;

    SceneLoader sceneLoader;
    GameManager gameManager;
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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
     
        StartCoroutine(StartCountDown());
    }


    IEnumerator StartCountDown()
    {
        currentCountDownValue = timeToPlay;
        while(currentCountDownValue >= 0 && !GameManager.answered)
        {
            timerText.text = currentCountDownValue.ToString();
            timerAnimator.SetTrigger("TimerTrigger");
            yield return new WaitForSeconds(1f);
            currentCountDownValue--;
            timerAnimator.ResetTrigger("TimerTrigger");
        }

        if(currentCountDownValue <= 0 && !GameManager.answered)
        {
            gameManager.OnWrongAnswer();           
        }
        timerAnimator.enabled = false;
        StartCoroutine(WaitBeforeLoad());        
    }

    IEnumerator WaitBeforeLoad()
    {
        
        yield return new WaitForSeconds(loadWaitingTime);
        GameManager.answered = false;
        sceneLoader.LoadNewScene();
    }
}
