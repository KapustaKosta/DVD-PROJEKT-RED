using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneControl : MonoBehaviour
{
    [SerializeField] private int seconds;
    [SerializeField] private string nextSceneName;
    private FadeInOutScene fios;

    private void Awake()
    {
        fios = GetComponent<FadeInOutScene>();
    }

    void Start()
    {
        StartCoroutine(WaitAndGoNext());
    }

    private IEnumerator WaitAndGoNext()
    {
        yield return new WaitForSeconds(seconds);
        fios.isFadeOut = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
