using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour, DropHandler.ILetterDropListener
{
    [SerializeField] TextMeshProUGUI compoundLetterText;
    [SerializeField] GameObject compoundLetterHolder;
    [SerializeField] GameObject constituentItemHolder;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip correctSfx;
    [SerializeField] AudioClip incorrectSfx;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Animator scorerAnimator;
    [SerializeField] GameObject scorerAnimObject;
    [SerializeField] TextMeshProUGUI scorerAnimText;
    [SerializeField] AudioClip dropSfx;

    string answer;

    public static volatile bool answered = false;

    // Start is called before the first frame update
    void Start()
    {
        string compoundLetter = Juktakkhor.Instance.NextCompoundLetter();
        compoundLetterText.text = compoundLetter;
        answer = Juktakkhor.Instance.GetAnswer(compoundLetter);

        for(int i=0;i<answer.Length;i++)
        {
            GameObject constituentLetter = Instantiate(constituentItemHolder) as GameObject;
            constituentLetter.transform.SetParent(compoundLetterHolder.transform);
            constituentLetter.transform.localScale = new Vector2(1, 1);
            DropHandler dropHandler = constituentLetter.transform.GetChild(0).GetComponent<DropHandler>();
            dropHandler.AddLetterDropListener(this);
        }

        scoreText.text = Scorer.score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneLoader.LoadMenu();
        }
    }

    void CheckAnswer()
    {
        string givenAns = "";
        for(int i=0;i<answer.Length;i++)
        {
            GameObject letterObj = compoundLetterHolder.transform.GetChild(i + 2).GetChild(0).gameObject;
            givenAns += letterObj.GetComponent<TextMeshProUGUI>().text;
        }

        if(givenAns == answer)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(correctSfx);

            Debug.Log("Correct!!!");
            answered = true;

            
            //scorerAnimator.
            
            StartCoroutine(WaitForScoreAnimation());
        }        
    }

    public void OnLetterDrop()
    {
        StartCoroutine(WaitForLetterDrop());
    }

    public void OnWrongAnswer()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(incorrectSfx);
    }

    IEnumerator WaitForScoreAnimation()
    {
        string score = timerText.text;
        scorerAnimObject.SetActive(true);
        scorerAnimText.text = "+" + score;
        scorerAnimator.SetTrigger("ScoreTrigger");

        yield return new WaitForSeconds(0.25f);

        scorerAnimObject.SetActive(false);
        Scorer.score += long.Parse(score);
        scoreText.text = Scorer.score.ToString();
        //scorerAnimator.ResetTrigger("ScoreTrigger");
    }

    IEnumerator WaitForLetterDrop()
    {
        audioSource.PlayOneShot(dropSfx);
        yield return new WaitForSeconds(0.4f);
        CheckAnswer();
    }
}
