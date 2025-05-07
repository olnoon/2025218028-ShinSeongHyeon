using UnityEngine;

public class MalDisplay : MonoBehaviour
{
    public GameObject originalObj;
    public Vector2Int moveToCoordinate;
    public string team;
    public string malKind;

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
                originalObj.GetComponent<Mal>().showerMals.Remove(this.gameObject);
                Destroy(gameObject);
                //TODO originalObj에 신호 보내주는 구문 만들어주기
            }
        }
    }
}
