using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject entryScene;
    [SerializeField] private GameObject exitScene;
    [Header("Transition Time")]
    [SerializeField] private float transitionTime;
    [SerializeField] private string sceneName;
    [Header("Game Quit (For Menu)")]
    [SerializeField] private float quitTime = 1.500f;
    public bool Restart;
    private void OnEnable()
    {
       // if (LoginAccount.SceneTransition != null)
            LoginAccount.SceneTransition += ExitScene;
    }
    private void Awake()
    {
        if(!Restart)
        {
            var newTr = Instantiate(entryScene, transform.position, Quaternion.identity);
            newTr.transform.SetParent(gameObject.transform);
        }
    }
    private IEnumerator Transition()
    {
        var newTr = Instantiate(exitScene, transform.position, Quaternion.identity);
        newTr.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
    public void ExitScene()
    {
        StartCoroutine(Transition());
    }
    private IEnumerator Quit()
    {
        var newTr = Instantiate(exitScene, transform.position, Quaternion.identity);
        newTr.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(quitTime);
        Application.Quit();
    }
    //Quit game
    public void QuitGame()
    {
        StartCoroutine(Quit());
    }
}
