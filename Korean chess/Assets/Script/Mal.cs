using UnityEngine;
using System.Collections.Generic;

public class Mal : MonoBehaviour
{
    [SerializeField] GameManager GM;
    [SerializeField] bool isSelected = false;
    public Vector2Int currectCoordinate;
    [SerializeField] GameObject displayMal;
    public List<GameObject> showerMals;
    [SerializeField] string malKind;
    public string malTeam;
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
        switch(malKind)
        {
            case "JolByeong":
                CreateJolDisplays();
            break;
            case "Char":
                CreateCharDisplays();
            break;
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

    void CreateJolDisplays()
    {
        Color color = new Color(0, 0, 0, 0.5f);
        if(currectCoordinate.x > 0)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y].locates[currectCoordinate.x-1].position;
            Vector2Int moveToCoordinate = new Vector2Int(currectCoordinate.x-1, currectCoordinate.y);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
        if(currectCoordinate.x < GM.locateMaterixes[currectCoordinate.y].locates.Count-1)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y].locates[currectCoordinate.x+1].position;
            Vector2Int moveToCoordinate = new Vector2Int(currectCoordinate.x+1, currectCoordinate.y);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
        if(currectCoordinate.y < GM.locateMaterixes.Count-1)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y+1].locates[currectCoordinate.x].position;
            Vector2Int moveToCoordinate = new Vector2Int(currectCoordinate.x, currectCoordinate.y+1);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
    }
    
    void CreateCharDisplays()
    {
        Color color = new Color(0, 0, 0, 0.5f);
        for(int i = currectCoordinate.x+1; i < GM.locateMaterixes[currectCoordinate.y].locates.Count; i++)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y].locates[i].position;
            Vector2Int moveToCoordinate = new Vector2Int(i, currectCoordinate.y);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
        for(int i = currectCoordinate.y; i < GM.locateMaterixes.Count; i++)
        {
            Vector2 displayMalPos = GM.locateMaterixes[i].locates[currectCoordinate.x].position;
            Vector2Int moveToCoordinate = new Vector2Int(currectCoordinate.x, i);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
        for(int i = currectCoordinate.x - 1; i >= 0; i--)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y].locates[i].position;
            Vector2Int moveToCoordinate = new Vector2Int(i, currectCoordinate.y);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
        for(int i = currectCoordinate.y - 1; i >= 0; i--)
        {
            Vector2 displayMalPos = GM.locateMaterixes[i].locates[currectCoordinate.x].position;
            Vector2Int moveToCoordinate = new Vector2Int(currectCoordinate.x, i);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
    }
    void CreateEachDisplay(GameObject showerMal, Color color, Vector2Int moveToCoordinate)
    {
        showerMal.GetComponent<SpriteRenderer>().color = color;
        Destroy(showerMal.GetComponent<Mal>());
        showerMal.AddComponent<MalDisplay>();
        showerMal.GetComponent<MalDisplay>().originalObj = gameObject;
        showerMal.GetComponent<MalDisplay>().moveToCoordinate = moveToCoordinate;
        showerMal.GetComponent<MalDisplay>().team = malTeam;
        showerMal.GetComponent<MalDisplay>().malKind = malKind;
        showerMals.Add(showerMal);
    }
}
