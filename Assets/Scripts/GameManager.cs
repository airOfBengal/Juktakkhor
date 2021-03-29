using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour, DropHandler.ILetterDropListener
{
    [SerializeField] TextMeshProUGUI compoundLetterText;
    [SerializeField] GameObject compoundLetterHolder;
    [SerializeField] GameObject constituentItemHolder;
    [SerializeField] Juktakkhor juktakkhor;
    [SerializeField] TextMeshProUGUI scoreText;

    string answer;

    public static bool answered = false;

    // Start is called before the first frame update
    void Start()
    {
        string compoundLetter = juktakkhor.NextCompoundLetter();
        compoundLetterText.text = compoundLetter;
        answer = juktakkhor.GetAnswer(compoundLetter);

        for(int i=0;i<answer.Length;i++)
        {
            GameObject constituentLetter = Instantiate(constituentItemHolder) as GameObject;
            constituentLetter.transform.SetParent(compoundLetterHolder.transform);
            constituentLetter.transform.localScale = new Vector2(1, 1);
            DropHandler dropHandler = constituentLetter.transform.GetChild(0).GetComponent<DropHandler>();
            dropHandler.AddLetterDropListener(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Debug.Log("Correct!!!");
            answered = true;
        }

        
    }

    public void OnLetterDrop()
    {
        CheckAnswer();
    }
}
