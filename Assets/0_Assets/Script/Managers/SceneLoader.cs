using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scene
{
    MainMenuScene,
    GameScene,
    NoobyScene
}

// public class SceneLoader : Singleton<SceneLoader>
// {
//     public void RestartScene()
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

//     public void LoadScene(Scene scene)
//     {
//         SceneManager.LoadScene(scene.ToString());
//     }

//     public void LoadMainMenuScene()
//     {
//         LoadScene(Scene.MainMenuScene);
//     }


//     public void QuitApplication()
//     {
//         GameManager.Instance.OnApplicationQuit();
//     }
// }


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