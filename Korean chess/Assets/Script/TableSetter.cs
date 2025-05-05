using UnityEngine;

public class TableSetter : MonoBehaviour
{
    [SerializeField] string kind;
    [SerializeField] TableSetting tableSetting;

    void OnMouseDown()
    {
        Judge();
    }

    void Judge()
    {
        if(kind == "오른상 차림")
        {
            tableSetting.SetRightSang();
        }
        else if(kind == "왼상 차림")
        {
            tableSetting.SetLeftSang();
        }
        else if(kind == "안상 차림")
        {
            tableSetting.SetInnerSang();
        }
        else if(kind == "바깥상 차림")
        {
            tableSetting.SetOutterSang();
        }
    }
}
