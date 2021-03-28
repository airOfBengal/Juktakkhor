using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] int timeToPlay = 10;

    SceneLoader sceneLoader;

    int currentCountDownValue;
    TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        // Find game object to fix "Object reference not set to an instance of an object"
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        textMeshProUGUI = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
        StartCoroutine(StartCountDown());
    }


    IEnumerator StartCountDown()
    {
        currentCountDownValue = timeToPlay;
        while(currentCountDownValue > 0)
        {
            textMeshProUGUI.text = 
                currentCountDownValue.ToString();
            yield return new WaitForSeconds(1f);
            currentCountDownValue--;
        }

        sceneLoader.LoadNewScene();
    }
}
