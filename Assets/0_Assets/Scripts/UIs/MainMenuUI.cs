using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button noobPlayButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button quitButton;

    void Awake()
    {
        playButton.onClick.AddListener(() => { SceneLoader.LoadScene(Scene.GameScene); });

        //noobPlayButton.onClick.AddListener(() => { SceneLoader.LoadScene(Scene.GameScene); });

        settingButton.onClick.AddListener(() => OnSetting());

        quitButton.onClick.AddListener(() => { GameManager.Instance.OnApplicationQuit(); });

        // just to make sure
        Time.timeScale = 1f;
    }
    void Start()
    {
        playButton.Select();
    }

    public void OnSetting()
    {
        GameManager.Instance.PauseResumeGame();
        //GameManager.Instance.PauseGame();
    }
}
