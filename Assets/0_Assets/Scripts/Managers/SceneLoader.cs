using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scene
{
    MainMenuScene,
    GameScene,
    NoobyScene
}
public static class SceneLoader
{
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static void LoadMainMenuScene()
    {
        LoadScene(Scene.MainMenuScene);
    }


    public static void QuitApplication()
    {
        GameManager.Instance.OnApplicationQuit();
    }

    
    
}