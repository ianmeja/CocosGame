using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;
using UnityEngine.SceneManagement;

public class LoadScreenManager : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private Text _progressText;

    private void Start() 
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)Levels.Level_1);
        float progress = 0;

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            progress = operation.progress;

            _progressBar.fillAmount = progress;
            _progressText.text = $"{progress * 100} %";

            if(operation.progress >= .90f)
            {
                _progressText.text = "Press spaceBar to continue...";

                if(Input.GetKeyDown(KeyCode.Space)){
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
    
}
