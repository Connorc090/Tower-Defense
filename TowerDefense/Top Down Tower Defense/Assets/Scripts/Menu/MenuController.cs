using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    [HideInInspector]
    public int charControlVal;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    void Awake () {
        
    }


    public void Changescene (string scenename) {
        SceneManager.LoadScene(scenename);
    }

    public void LoadGame (int val) {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(LoadAsynchronously());

        charControlVal = val;
    }


    IEnumerator LoadAsynchronously () {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");

        loadingScreen.SetActive(true);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
