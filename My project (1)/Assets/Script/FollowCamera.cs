using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject mainCharacter;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        foreach(PlayerMove each in FindObjectsByType<PlayerMove>(FindObjectsSortMode.None))
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
        Vector2 GoingPos = new Vector2(mainCharacter.transform.position.x, mainCharacter.transform.position.y);
        transform.position = GoingPos;
    }
}
