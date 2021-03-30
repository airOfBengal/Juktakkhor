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
        compoundLetters.Add("³", "KZ");
        compoundLetters.Add("³«", "KZi");        
        compoundLetters.Add("´", "Kg");
        compoundLetters.Add("µ", "Ki");        
        compoundLetters.Add("¶", "Kl");        
        compoundLetters.Add("¶è", "KlY");        
        compoundLetters.Add("²", "Klg");        
        compoundLetters.Add("·", "Km");
        compoundLetters.Add("»", "Ma");
        compoundLetters.Add("M¥", "Mg");
        compoundLetters.Add("¼", "OK");
        compoundLetters.Add("•¶", "OKl");
        compoundLetters.Add("½", "OM");
        compoundLetters.Add("¾¡", "RRe");
        compoundLetters.Add("Á", "RT");
        compoundLetters.Add("Â", "TP");
        compoundLetters.Add("Ã", "TQ");
        compoundLetters.Add("Æ", "UU");
        compoundLetters.Add("U¥", "Ug");
        compoundLetters.Add("Uª", "Ui");
        compoundLetters.Add("È", "YU");
        compoundLetters.Add("É", "YV");
        compoundLetters.Add("Ê", "YW");
        compoundLetters.Add("Y¥", "Yg");
        compoundLetters.Add("Ë", "ZZ");
        compoundLetters.Add("Ì", "Z_");
        compoundLetters.Add("Í", "Zg");
        compoundLetters.Add("Î", "Zi");
        compoundLetters.Add("Ù", "`g");
        compoundLetters.Add("a¥", "ag");
        compoundLetters.Add("›U", "bU");
        compoundLetters.Add("Ú", "bV");
        compoundLetters.Add("b¥", "bg");
        compoundLetters.Add("å", "fi");
        compoundLetters.Add("æ", "gb");
        compoundLetters.Add("¤c", "gc");
        compoundLetters.Add("j¥", "jg");
        compoundLetters.Add("k¥", "kg");
        compoundLetters.Add("®‹", "lK");
        compoundLetters.Add("ó", "lU");
        compoundLetters.Add("ô", "lV");
        compoundLetters.Add("ò", "lY");
        compoundLetters.Add("®c", "lc");
        compoundLetters.Add("®§", "lg");
        compoundLetters.Add("÷", "mU");
        compoundLetters.Add("¯’", "m_");
        compoundLetters.Add("ý", "nb");
        compoundLetters.Add("þ", "ng");
    }
}
