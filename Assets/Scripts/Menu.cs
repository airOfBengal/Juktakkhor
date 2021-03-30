using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickSfx;
    [SerializeField] TextMeshProUGUI maxScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("max_score"))
        {
            PlayerPrefs.SetString("max_score", Scorer.score.ToString());
        }

        long maxScore = long.Parse(PlayerPrefs.GetString("max_score"));
        if(Scorer.score > maxScore)
        {
            Debug.Log("new max score: "+ Scorer.score);
            PlayerPrefs.SetString("max_score", Scorer.score.ToString());
            maxScore = Scorer.score;
        }

        maxScoreText.text = "m�e�v�P ���vit " + maxScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClick()
    {
        audioSource.PlayOneShot(clickSfx);
        sceneLoader.LoadNewScene();
    }

    public void OnQuitClick()
    {
        audioSource.PlayOneShot(clickSfx);

#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#else
    Application.Quit();
#endif
    }
}
