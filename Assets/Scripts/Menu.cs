using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickSfx;

    // Start is called before the first frame update
    void Start()
    {
        
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
