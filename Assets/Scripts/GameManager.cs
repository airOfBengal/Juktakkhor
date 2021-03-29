using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour, DropHandler.ILetterDropListener
{
    [SerializeField] TextMeshProUGUI compoundLetterText;
    [SerializeField] GameObject compoundLetterHolder;
    [SerializeField] GameObject constituentItemHolder;
   // [SerializeField] Juktakkhor juktakkhor;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip correctSfx;
    [SerializeField] AudioClip incorrectSfx;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;

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
            Scorer.score += long.Parse(timerText.text);
            scoreText.text = Scorer.score.ToString();
        }        
    }

    public void OnLetterDrop()
    {
        CheckAnswer();
    }

    public void OnWrongAnswer()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(incorrectSfx);
    }
}
