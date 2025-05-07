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
        if(kind == "RightSangSet")
        {
            GM.SetRightSang();
        }
        else if(kind == "LeftSangSet")
        {
            GM.SetLeftSang();
        }
        else if(kind == "InnerSangSet")
        {
            GM.SetInnerSang();
        }
        else if(kind == "OutterSangSet")
        {
            GM.SetOutterSang();
        }
    }
}
