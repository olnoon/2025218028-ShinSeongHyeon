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
        if (isRedSet)
        {
            GameObject obj1 = Instantiate(RedSang, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 9);

            GameObject obj2 = Instantiate(RedMa, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 9);

            GameObject obj3 = Instantiate(RedSang, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 9);

            GameObject obj4 = Instantiate(RedMa, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 9);

            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            GameObject obj1 = Instantiate(BlueMa, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 0);

            GameObject obj2 = Instantiate(BlueSang, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 0);

            GameObject obj3 = Instantiate(BlueMa, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 0);

            GameObject obj4 = Instantiate(BlueSang, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 0);

            BlueSangSetter.SetActive(false);
        }
    }

    public void SetLeftSang()
    {
        if (isRedSet)
        {
            GameObject obj1 = Instantiate(RedMa, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 9);

            GameObject obj2 = Instantiate(RedSang, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 9);

            GameObject obj3 = Instantiate(RedMa, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 9);

            GameObject obj4 = Instantiate(RedSang, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 9);

            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            GameObject obj1 = Instantiate(BlueSang, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 0);

            GameObject obj2 = Instantiate(BlueMa, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 0);

            GameObject obj3 = Instantiate(BlueSang, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 0);

            GameObject obj4 = Instantiate(BlueMa, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 0);

            BlueSangSetter.SetActive(false);
        }
    }

    public void SetInnerSang()
    {
        if (isRedSet)
        {
            GameObject obj1 = Instantiate(RedMa, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 9);

            GameObject obj2 = Instantiate(RedSang, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 9);

            GameObject obj3 = Instantiate(RedSang, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 9);

            GameObject obj4 = Instantiate(RedMa, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 9);

            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            GameObject obj1 = Instantiate(BlueMa, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 0);

            GameObject obj2 = Instantiate(BlueSang, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 0);

            GameObject obj3 = Instantiate(BlueSang, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 0);

            GameObject obj4 = Instantiate(BlueMa, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 0);

            BlueSangSetter.SetActive(false);
        }
    }

    public void SetOutterSang()
    {
        if (isRedSet)
        {
            GameObject obj1 = Instantiate(RedSang, locateMaterixes[9].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 9);

            GameObject obj2 = Instantiate(RedMa, locateMaterixes[9].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 9);

            GameObject obj3 = Instantiate(RedMa, locateMaterixes[9].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 9);

            GameObject obj4 = Instantiate(RedSang, locateMaterixes[9].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 9);

            isRedSet = false;
            SetBlueTable();
        }
        else
        {
            GameObject obj1 = Instantiate(BlueSang, locateMaterixes[0].locates[1].transform.position, Quaternion.identity);
            obj1.GetComponent<Mal>().currectCoordinate = new Vector2Int(1, 0);

            GameObject obj2 = Instantiate(BlueMa, locateMaterixes[0].locates[2].transform.position, Quaternion.identity);
            obj2.GetComponent<Mal>().currectCoordinate = new Vector2Int(2, 0);

            GameObject obj3 = Instantiate(BlueMa, locateMaterixes[0].locates[6].transform.position, Quaternion.identity);
            obj3.GetComponent<Mal>().currectCoordinate = new Vector2Int(6, 0);

            GameObject obj4 = Instantiate(BlueSang, locateMaterixes[0].locates[7].transform.position, Quaternion.identity);
            obj4.GetComponent<Mal>().currectCoordinate = new Vector2Int(7, 0);

            BlueSangSetter.SetActive(false);
        }
    }
}
