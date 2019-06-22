using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string DefaultSceneName = "";
    
    // Start is called before the first frame update
    
    void Start()
    {
        string SceneName;

        if (URLParameters.GetSearchParameters().TryGetValue("scene", out SceneName) == false)
            SceneName = DefaultSceneName;

        if(SceneName != "" )
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }
}
