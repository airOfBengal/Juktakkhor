using System.Collections.Generic;
using UnityEngine;

public class Juktakkhor : MonoBehaviour
{
    private static Juktakkhor _instance;

    public static Juktakkhor Instance { get { return _instance; } }

    Dictionary<string, string> compoundLetters = new Dictionary<string, string>();
    System.Random _random = new System.Random();
    static int currentLetterIndex = 0;
    string[] shuffledCompoundLetters;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
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

        Shuffle(shuffledCompoundLetters);
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
        compoundLetters.Add("�", "KZ");
        compoundLetters.Add("��", "KZi");        
        compoundLetters.Add("�", "Kg");
        compoundLetters.Add("�", "Ki");        
        compoundLetters.Add("�", "Kl");        
        compoundLetters.Add("��", "KlY");        
        compoundLetters.Add("�", "Klg");        
        compoundLetters.Add("�", "Km");
        compoundLetters.Add("�", "Ma");
        compoundLetters.Add("M�", "Mg");
        compoundLetters.Add("�", "OK");
        compoundLetters.Add("��", "OKl");
        compoundLetters.Add("�", "OM");
        compoundLetters.Add("��", "RRe");
        compoundLetters.Add("�", "RT");
        compoundLetters.Add("�", "TP");
        compoundLetters.Add("�", "TQ");
        compoundLetters.Add("�", "UU");
        compoundLetters.Add("U�", "Ug");
        compoundLetters.Add("U�", "Ui");
        compoundLetters.Add("�", "YU");
        compoundLetters.Add("�", "YV");
        compoundLetters.Add("�", "YW");
        compoundLetters.Add("Y�", "Yg");
        compoundLetters.Add("�", "ZZ");
        compoundLetters.Add("�", "Z_");
        compoundLetters.Add("�", "Zg");
        compoundLetters.Add("�", "Zi");
        compoundLetters.Add("�", "`g");
        compoundLetters.Add("a�", "ag");
        compoundLetters.Add("�U", "bU");
        compoundLetters.Add("�", "bV");
        compoundLetters.Add("b�", "bg");
        compoundLetters.Add("�", "fi");
        compoundLetters.Add("�", "gb");
        compoundLetters.Add("�c", "gc");
        compoundLetters.Add("j�", "jg");
        compoundLetters.Add("k�", "kg");
        compoundLetters.Add("��", "lK");
        compoundLetters.Add("�", "lU");
        compoundLetters.Add("�", "lV");
        compoundLetters.Add("�", "lY");
        compoundLetters.Add("�c", "lc");
        compoundLetters.Add("��", "lg");
        compoundLetters.Add("�", "mU");
        compoundLetters.Add("��", "m_");
        compoundLetters.Add("�", "nb");
        compoundLetters.Add("�", "ng");
    }
}
