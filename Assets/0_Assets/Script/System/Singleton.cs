using UnityEngine;


// Don't destroy on load only works on game objects at the root level
// so, if it was parented its' child of something, kick it back up to the root level
public class Singleton<T> : MonoBehaviour where T : Component
{
    private bool AutoUnparentOnAwake = true;
    protected static T instance;

    public static bool HasInstance => instance != null;
    public static T TryGetInstance() => HasInstance ? instance : null;
    
    public static T Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindAnyObjectByType<T>();
                if (null == instance)
                {
                    var go = new GameObject(typeof(T).Name + " Auto Generated");
                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        InitializeSingleton();
    }

    protected virtual void InitializeSingleton()
    {
        if (!Application.isPlaying) 
            return;

        if (AutoUnparentOnAwake)
        {
            transform.SetParent(null);
        }

        if (null == instance)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }        
        else
        {
            Destroy(gameObject);
        }

        
    }   

}
