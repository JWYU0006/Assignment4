using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get { return GetInstance(); }
    }

    private static T GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindFirstObjectByType<T>();
            if (_instance == null)
            {
                /*GameObject singletonObject = */
                new GameObject(typeof(T).ToString(), typeof(T));
                //_instance = singletonObject.AddComponent<T>();
                //DontDestroyOnLoad(singletonObject);
            }
            else if (_instance.gameObject.scene.name != "DontDestroyOnLoad")
            {
                DontDestroyOnLoad(_instance.gameObject);
            }
        }
        return _instance;
    }

    public void Awake()
    {
        GetInstance();

        if (_instance != this && _instance != null)
        {
            Debug.LogWarning($"Another instance of singleton {typeof(T)} exists. Destroying this instance.");
            Destroy(this);
        }
    }
}
