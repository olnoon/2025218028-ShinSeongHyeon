using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocateMaterix
{
    public List<Transform> locates;
}

public class GameManager : MonoBehaviour
{
    public List<LocateMaterix> locateMaterixes;
    [SerializeField] GameObject RedMa;
    [SerializeField] GameObject RedSang;
    [SerializeField] GameObject BlueMa;
    [SerializeField] GameObject BlueSang;
    [SerializeField] GameObject BlueSangSetter;
    [SerializeField] GameObject RedSangSetter;
    [SerializeField] bool isRedSet;
    public GameObject selectedMal;

    void Start()
    {
        SetRedTable();
    }

    void SetRedTable()
    {
        isRedSet = true;
        RedSangSetter.SetActive(true);
    }
    void SetBlueTable()
    {
        isRedSet = false;
        RedSangSetter.SetActive(false);
        BlueSangSetter.SetActive(true);
    }
    public void SetRightSang()
    {
        if(isRedSet)
        {
            Instantiate(RedSang, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            Instantiate(RedMa, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            Instantiate(RedSang, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            Instantiate(RedMa, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            Instantiate(BlueMa, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            Instantiate(BlueSang, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            Instantiate(BlueMa, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            Instantiate(BlueSang, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            BlueSangSetter.SetActive(false);
        }
    }
    public void SetLeftSang()
    {
        if(isRedSet)
        {
            Instantiate(RedMa, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            Instantiate(RedSang, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            Instantiate(RedMa, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            Instantiate(RedSang, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            Instantiate(BlueSang, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            Instantiate(BlueMa, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            Instantiate(BlueSang, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            Instantiate(BlueMa, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            BlueSangSetter.SetActive(false);
        }
    }
    public void SetInnerSang()
    {
        if(isRedSet)
        {
            Instantiate(RedMa, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            Instantiate(RedSang, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            Instantiate(RedSang, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            Instantiate(RedMa, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            Instantiate(BlueMa, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            Instantiate(BlueSang, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            Instantiate(BlueSang, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            Instantiate(BlueMa, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            BlueSangSetter.SetActive(false);
        }
    }
    public void SetOutterSang()
    {
        if(isRedSet)
        {
            Instantiate(RedSang, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            Instantiate(RedMa, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            Instantiate(RedMa, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            Instantiate(RedSang, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            Instantiate(BlueSang, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            Instantiate(BlueMa, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            Instantiate(BlueMa, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            Instantiate(BlueSang, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            BlueSangSetter.SetActive(false);
        }
    }
}
