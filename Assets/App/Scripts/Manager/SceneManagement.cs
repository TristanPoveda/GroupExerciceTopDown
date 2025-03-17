using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] RSE_OpenScene rSE_OpenScene;
    [SerializeField] RSE_QuitGame rSE_QuitGame;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    private void OnEnable()
    {
        rSE_OpenScene.action += OpenScene;
        rSE_QuitGame.action += QuitGame;
    }
    private void OnDisable()
    {
        rSE_OpenScene.action -= OpenScene;
        rSE_QuitGame.action -= QuitGame;
    }
    private void OpenScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}