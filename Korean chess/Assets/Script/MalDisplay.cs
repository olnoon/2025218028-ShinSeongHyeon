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
                        originalObj.GetComponent<Mal>().DestroyPoeByCatched(gameObject);
                        //TODO 한번 넘으면 그 다음에 겹치는 거 있을 땐 못 넘게 하기
                        //TODO 포가 겹치면 못 넘게 하기
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
