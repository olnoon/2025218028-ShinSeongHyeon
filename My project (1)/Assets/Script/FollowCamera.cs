using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject mainCharacter;
    [SerializeField] bool isAnchored;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        foreach(PlayerStat each in FindObjectsByType<PlayerStat>(FindObjectsSortMode.None))
        {
            if(each.isMain)
            {
                mainCharacter = each.gameObject;
                break;
            }
        }
    }

    void Update()
    {
        if(mainCharacter != null && isAnchored)
        {
            Vector3 GoingPos = new Vector3(mainCharacter.transform.position.x, mainCharacter.transform.position.y, -20);
            transform.localPosition = GoingPos;
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "BattleScene")
        {
            transform.position = new Vector3(0, 0, -10);
            isAnchored = false;
        }
        else
        {
            isAnchored = true;
        }
    }
}
