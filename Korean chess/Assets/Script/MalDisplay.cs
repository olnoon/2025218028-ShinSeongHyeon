using UnityEngine;

public class MalDisplay : MonoBehaviour
{
    public GameObject originalObj;
    public Vector2Int moveToCoordinate;
    public string team;
    public malKinds malKind;

    void Awake()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    void OnMouseDown()
    {
        originalObj.transform.position = transform.position;
        originalObj.GetComponent<Mal>().UnSelectMal();
        originalObj.GetComponent<Mal>().currectCoordinate = moveToCoordinate;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Mal>() != null && collision.gameObject != originalObj)
        {
            if(collision.GetComponent<Mal>().malTeam == team)
            {
                switch(malKind)
                {
                    case malKinds.Char:
                        originalObj.GetComponent<Mal>().DestroyCharByCatched(gameObject);
                    break;
                    case malKinds.Poe:
                        Debug.Log(collision.gameObject.name);
                        originalObj.GetComponent<Mal>().DestroyPoeByCatched(gameObject);
                    break;
                    default:
                        originalObj.GetComponent<Mal>().showerMals.Remove(gameObject);
                        Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
