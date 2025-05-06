using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mal : MonoBehaviour
{
    [SerializeField] GameManager GM;
    [SerializeField] bool isSelected = false;
    public Vector2Int currectCoordinate;
    [SerializeField] GameObject displayMal;
    [SerializeField] List<GameObject> showerMals;
    [SerializeField] string malKind;
    [SerializeField] string malTeam;
    void Start()
    {
        displayMal = gameObject;
    }

    void OnMouseDown()
    {
        if(isSelected)
        {
            UnSelectMal();
        }
        else
        {
            SelectMal();
        }
    }
    
    void SelectMal()
    {
        if(GM.selectedMal!=null)
        {
            GM.selectedMal.GetComponent<Mal>().UnSelectMal();
        }
        GM.selectedMal = gameObject;
        isSelected = true;
        if(malKind == "쫄병")
        {
            CreateJolDisplay();
        }
    }

    public void UnSelectMal()
    {
        isSelected = false;
        foreach(GameObject showerMal in showerMals)
        {
            Destroy(showerMal);
        }
        showerMals.Clear();
    }

    void CreateJolDisplay()
    {
        Color color = new Color(0, 0, 0, 0.5f);
        if(currectCoordinate.x > 0)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y].locates[currectCoordinate.x-1].position;
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);
            showerMal.GetComponent<SpriteRenderer>().color = color;
            Destroy(showerMal.GetComponent<Mal>());
            showerMal.AddComponent<MalDisplay>();
            showerMal.GetComponent<MalDisplay>().originalObj = gameObject;
            showerMal.GetComponent<MalDisplay>().moveToCoordinate = new Vector2Int(currectCoordinate.x-1, currectCoordinate.y);
            showerMals.Add(showerMal);
        }
        if(currectCoordinate.x < GM.locateMaterixes[currectCoordinate.y].locates.Count-1)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y].locates[currectCoordinate.x+1].position;
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);
            showerMal.GetComponent<SpriteRenderer>().color = color;
            Destroy(showerMal.GetComponent<Mal>());
            showerMal.AddComponent<MalDisplay>();
            showerMal.GetComponent<MalDisplay>().originalObj = gameObject;
            showerMal.GetComponent<MalDisplay>().moveToCoordinate = new Vector2Int(currectCoordinate.x+1, currectCoordinate.y);
            showerMals.Add(showerMal);
        }
        if(currectCoordinate.y < GM.locateMaterixes.Count-1)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y+1].locates[currectCoordinate.x].position;
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);
            showerMal.GetComponent<SpriteRenderer>().color = color;
            Destroy(showerMal.GetComponent<Mal>());
            showerMal.AddComponent<MalDisplay>();
            showerMal.GetComponent<MalDisplay>().originalObj = gameObject;
            showerMal.GetComponent<MalDisplay>().moveToCoordinate = new Vector2Int(currectCoordinate.x, currectCoordinate.y+1);
            showerMals.Add(showerMal);
        }
    }
    
}
