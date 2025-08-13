using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static string CatName;
    public static string DogName;
    public static GameController Instance;
    private bool hasInitialized = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Crucially, unsubscribe when the object is disabled or destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Main") { return; }
        // Only execute if not already initialized
        if (!hasInitialized)
        {
            Debug.Log("Scene '" + scene.name + "' is fully loaded. Executing initialization method.");
            SetNames();
            hasInitialized = true;   // Set the flag to true to prevent future calls
        }
    }
    private void SetNames() //ASTRACTION
    {
        GameObject.Find("CatParent").GetComponentInChildren<TMP_Text>().text = CatName;
        GameObject.Find("DogParent").GetComponentInChildren<TMP_Text>().text = DogName;

        GameObject.Find("CatParent").GetComponentInChildren<Cat>().petName = CatName;
        GameObject.Find("DogParent").GetComponentInChildren<Dog>().petName = DogName;
    }

}
