using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI compoundLetterText;
    [SerializeField] GameObject compoundLetterHolder;
    [SerializeField] GameObject constituentItemHolder;
    [SerializeField] Juktakkhor juktakkhor;

    // Start is called before the first frame update
    void Start()
    {
        string compoundLetter = juktakkhor.NextCompoundLetter();
        compoundLetterText.text = compoundLetter;
        string answer = juktakkhor.GetAnswer(compoundLetter);

        for(int i=0;i<answer.Length;i++)
        {
            GameObject constituentLetter = Instantiate(constituentItemHolder) as GameObject;
            constituentLetter.transform.SetParent(compoundLetterHolder.transform);
            //constituentLetter.GetComponent<TextMeshProUGUI>().text = "" + answer[i];
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
