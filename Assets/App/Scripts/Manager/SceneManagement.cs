using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float levelDuration;

    [Header("References")]
    [SerializeField] RSE_OpenScene rSE_OpenScene;
    [SerializeField] RSE_QuitGame rSE_QuitGame;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]
    private CountdownTimer levelTimer;

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

    private void Awake()
    {
        levelTimer = new CountdownTimer(levelDuration);
        levelTimer.OnTimerStop = () => OpenScene("MainMenu");
    }

    private void Start()
    {
        levelTimer.Start();
    }

    private void Update()
    {
        levelTimer.Tick(Time.deltaTime);
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