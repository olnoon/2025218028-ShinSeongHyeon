using UnityEngine;

public class TableSetting : MonoBehaviour
{
    [SerializeField] GameObject RedMa;
    [SerializeField] GameObject RedSang;
    [SerializeField] GameObject BlueMa;
    [SerializeField] GameObject BlueSang;
    [SerializeField] GameManager GM;
    [SerializeField] bool isRedSet;

    void Start()
    {
        SetRedTable();
    }

    void SetRedTable()
    {
        isRedSet = true;
    }
    void SetBlueTable()
    {
        isRedSet = false;
    }
    void SelectTableSet()
    {
        //TODO RED팀 상차림 UI켜주기
    }
    public void SetRightSang()
    {
        if(isRedSet)
        {
            Instantiate(RedMa, GM.locateMaterixes[9].locates[1]);
            Instantiate(RedSang, GM.locateMaterixes[9].locates[2]);
            Instantiate(RedMa, GM.locateMaterixes[9].locates[6]);
            Instantiate(RedSang, GM.locateMaterixes[9].locates[7]);
            isRedSet = false;
            //TODO RED팀 상차림 UI꺼주기
            //TODO Blue팀 상차림 UI켜주기
        }
        else
        {
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[1]);
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[2]);
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[6]);
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[7]);
            //TODO Blue팀 상차림 UI 꺼주기
        }
    }
    public void SetLeftSang()
    {
        if(isRedSet)
        {
            Instantiate(RedSang, GM.locateMaterixes[9].locates[1]);
            Instantiate(RedMa, GM.locateMaterixes[9].locates[2]);
            Instantiate(RedSang, GM.locateMaterixes[9].locates[6]);
            Instantiate(RedMa, GM.locateMaterixes[9].locates[7]);
            isRedSet = false;
            //TODO RED팀 상차림 UI꺼주기
            //TODO Blue팀 상차림 UI켜주기
        }
        else
        {
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[1]);
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[2]);
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[6]);
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[7]);
            //TODO Blue팀 상차림 UI 꺼주기
        }
    }
    public void SetInnerSang()
    {
        if(isRedSet)
        {
            Instantiate(RedMa, GM.locateMaterixes[9].locates[1]);
            Instantiate(RedSang, GM.locateMaterixes[9].locates[2]);
            Instantiate(RedSang, GM.locateMaterixes[9].locates[6]);
            Instantiate(RedMa, GM.locateMaterixes[9].locates[7]);
            isRedSet = false;
            //TODO RED팀 상차림 UI꺼주기
            //TODO Blue팀 상차림 UI켜주기
        }
        else
        {
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[1]);
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[2]);
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[6]);
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[7]);
            //TODO Blue팀 상차림 UI 꺼주기
        }
    }
    public void SetOutterSang()
    {
        if(isRedSet)
        {
            Instantiate(RedSang, GM.locateMaterixes[9].locates[1]);
            Instantiate(RedMa, GM.locateMaterixes[9].locates[2]);
            Instantiate(RedMa, GM.locateMaterixes[9].locates[6]);
            Instantiate(RedSang, GM.locateMaterixes[9].locates[7]);
            isRedSet = false;
            //TODO RED팀 상차림 UI꺼주기
            //TODO Blue팀 상차림 UI켜주기
        }
        else
        {
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[1]);
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[2]);
            Instantiate(BlueMa, GM.locateMaterixes[9].locates[6]);
            Instantiate(BlueSang, GM.locateMaterixes[9].locates[7]);
            //TODO Blue팀 상차림 UI 꺼주기
        }
    }
}
