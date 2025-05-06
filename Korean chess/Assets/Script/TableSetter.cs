using UnityEngine;

public class TableSetter : MonoBehaviour
{
    [SerializeField] string kind;
    [SerializeField] GameManager GM;

    void OnMouseDown()
    {
        Judge();
    }

    void Judge()
    {
        if(kind == "오른상 차림")
        {
            GM.SetRightSang();
        }
        else if(kind == "왼상 차림")
        {
            GM.SetLeftSang();
        }
        else if(kind == "안상 차림")
        {
            GM.SetInnerSang();
        }
        else if(kind == "바깥상 차림")
        {
            GM.SetOutterSang();
        }
    }
}
