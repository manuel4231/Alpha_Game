using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreenControl : MonoBehaviour {

    public GameObject LoadScreenControlObj;
    public Slider slider;

    AsyncOperation async;//para el progreso

    public void LoadScreenEx(int LVL)
    {
        StartCoroutine(LoadingScreen(LVL));
    }

    IEnumerator LoadingScreen(int lvl)
    {
        LoadScreenControlObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            slider.value = async.progress;

            if(async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;//Para el error de LoadingScreen
        }

    }
}
