using UnityEngine;

public class MalDisplay : MonoBehaviour
{
    public GameObject originalObj;
    public Vector2Int moveToCoordinate;
    void OnMouseDown()
    {
        originalObj.transform.position = transform.position;
        originalObj.GetComponent<Mal>().UnSelectMal();
        originalObj.GetComponent<Mal>().currectCoordinate = moveToCoordinate;
    }
}
