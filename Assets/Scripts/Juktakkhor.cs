using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juktakkhor : MonoBehaviour
{
    Dictionary<string, string> compoundLetters = new Dictionary<string, string>();
    System.Random _random = new System.Random();
    static int currentLetterIndex = 0;
    string[] shuffledCompoundLetters;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        FillCompoundLettersMap();

        shuffledCompoundLetters = new string[compoundLetters.Keys.Count];
        int i = 0;
        foreach(string s in compoundLetters.Keys)
        {
            shuffledCompoundLetters[i++] = s;
        }

        //Shuffle(shuffledCompoundLetters);
    }


    void Shuffle(string[] letters)
    {
        int l = letters.Length;
        for(int i=l-1; i>0;i--)
        {
            int j = _random.Next(0, i);
            string s = letters[j];
            letters[j] = letters[i];
            letters[i] = s;
        }
    }

    public string NextCompoundLetter()
    {
        if(currentLetterIndex == compoundLetters.Count)
        {
            currentLetterIndex = 0;
        }
        return shuffledCompoundLetters[currentLetterIndex++];
    }

    public string GetAnswer(string letter)
    {
        return compoundLetters[letter];
    }

    void FillCompoundLettersMap()
    {
        compoundLetters.Add("°", "KK");
        compoundLetters.Add("±", "KU");
        compoundLetters.Add("³", "KZ");
        compoundLetters.Add("³«", "KZi");
        compoundLetters.Add("K¡", "Ke");
    }
}
