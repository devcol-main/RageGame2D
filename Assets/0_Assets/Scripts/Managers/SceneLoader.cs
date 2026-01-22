using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scene
{
    MenuScene,
    GameScene,
    NoobyScene
}
public class SceneLoader : Singleton<SceneLoader>
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenuScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    
}