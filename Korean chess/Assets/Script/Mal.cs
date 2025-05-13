using UnityEngine;
using System.Collections.Generic;

public enum malKinds
{
    JolByeong,
    Char,
    Poe
}

public class Mal : MonoBehaviour
{
    [SerializeField] GameManager GM;
    [SerializeField] bool isSelected = false;
    public Vector2Int currectCoordinate;
    [SerializeField] GameObject displayMal;
    public List<GameObject> showerMals;
    [SerializeField] malKinds malKind;
    public string malTeam;
    public bool isDestroyed = false;
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
            case malKinds.JolByeong:
                CreateJolDisplays();
            break;
            case malKinds.Char:
                CreateCharDisplays();
            break;
            case malKinds.Poe:
                CreatePoeDisplays();
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
        for(int i = currectCoordinate.y+1; i < GM.locateMaterixes.Count; i++)
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
    
    public void DestroyCharByCatched(GameObject first)
    {
        if(first.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x && first.GetComponent<MalDisplay>().moveToCoordinate.y <= currectCoordinate.y)
        {
            GameObject end = null;
            foreach(GameObject each in showerMals)
            {
                if(each.GetComponent<MalDisplay>().moveToCoordinate.y == 0 && each.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x)
                {
                    end = each;
                    break;
                }
            }
            for(int i = showerMals.IndexOf(first); i <= showerMals.IndexOf(end); i++)
            {
                Destroy(showerMals[i]);
            }
        }
        else if(first.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x && first.GetComponent<MalDisplay>().moveToCoordinate.y >= currectCoordinate.y)
        {
            for(int i = showerMals.IndexOf(first); i < showerMals.IndexOf(first) + GM.locateMaterixes.Count - first.GetComponent<MalDisplay>().moveToCoordinate.y; i++)
            {
                Destroy(showerMals[i]);
            }
        }
        else if(first.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y && first.GetComponent<MalDisplay>().moveToCoordinate.x <= currectCoordinate.x)
        {
            GameObject end = null;
            foreach(GameObject each in showerMals)
            {
                if(each.GetComponent<MalDisplay>().moveToCoordinate.x == 0 && each.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y)
                {
                    end = each;
                    break;
                }
            }
            for(int i = showerMals.IndexOf(first); i <= showerMals.IndexOf(end); i++)
            {
                Destroy(showerMals[i]);
            }
        }
        else if(first.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y && first.GetComponent<MalDisplay>().moveToCoordinate.x >= currectCoordinate.x)
        {
            for(int i = showerMals.IndexOf(first); i < showerMals.IndexOf(first) + GM.locateMaterixes[currectCoordinate.y].locates.Count - first.GetComponent<MalDisplay>().moveToCoordinate.x; i++)
            {
                Destroy(showerMals[i]);
            }
        }
        showerMals.RemoveAll(item => item == null); 
    }
    
    void CreatePoeDisplays()
    {
        Color color = new Color(0, 0, 0, 0.5f);
        for(int i = currectCoordinate.x+1; i < GM.locateMaterixes[currectCoordinate.y].locates.Count; i++)
        {
            Vector2 displayMalPos = GM.locateMaterixes[currectCoordinate.y].locates[i].position;
            Vector2Int moveToCoordinate = new Vector2Int(i, currectCoordinate.y);
            
            GameObject showerMal = Instantiate(displayMal, displayMalPos, Quaternion.identity);

            CreateEachDisplay(showerMal, color, moveToCoordinate);
        }
        for(int i = currectCoordinate.y+1; i < GM.locateMaterixes.Count; i++)
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
        Invoke("DetectDestroyPoeDisplay", 0.1f);
    }
    
    void DetectDestroyPoeDisplay()
    {
        GameObject left = null;
        GameObject right = null;
        GameObject front = null;
        GameObject back = null;

        bool isleftDestroy = true;
        bool isrightDestroy = true;
        bool isfrontDestroy = true;
        bool isbackDestroy = true;
        
        foreach(GameObject showerMal in showerMals)
        {
            if(showerMal == null)
            {
                continue;
            }
            if(showerMal.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y && showerMal.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x - 1)
            {
                isleftDestroy = false;
                left = showerMal;
                continue;
            }
            else if(showerMal.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y && showerMal.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x + 1)
            {
                isrightDestroy = false;
                right = showerMal;
                continue;
            }
            else if(showerMal.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x && showerMal.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y - 1)
            {
                isbackDestroy = false;
                back = showerMal;
                continue;
            }
            else if(showerMal.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x && showerMal.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y + 1)
            {
                isfrontDestroy = false;
                front = showerMal;
                continue;
            }
        }
        
        if(!isfrontDestroy)
        {
            Debug.Log("1111");
            GameObject end = null;
            foreach(GameObject each in showerMals)
            {
                if(each == null)
                {
                    continue;
                }
                if(each.GetComponent<MalDisplay>().moveToCoordinate.y == 0 && each.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x)
                {
                    end = each;
                    break;
                }
            }
            for(int i = showerMals.IndexOf(front); i <= showerMals.IndexOf(end); i++)
            {
                Destroy(showerMals[i]);
            }
        }
        if(!isbackDestroy)
        {
            for(int i = showerMals.IndexOf(back); i < showerMals.IndexOf(back) + GM.locateMaterixes.Count - back.GetComponent<MalDisplay>().moveToCoordinate.y; i++)
            {
                Destroy(showerMals[i]);
            }
        }
        if(!isrightDestroy)
        {
            Debug.Log("3333");
            GameObject end = null;
            foreach(GameObject each in showerMals)
            {
                if(each == null)
                {
                    continue;
                }
                if(each.GetComponent<MalDisplay>().moveToCoordinate.x == 0 && each.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y)
                {
                    end = each;
                    break;
                }
            }
            for(int i = showerMals.IndexOf(right); i <= showerMals.IndexOf(end); i++)
            {
                Destroy(showerMals[i]);
            }
        }
        if(!isleftDestroy)
        {
            Debug.Log("4444");
            for(int i = showerMals.IndexOf(left); i < showerMals.IndexOf(left) + GM.locateMaterixes[currectCoordinate.y].locates.Count - left.GetComponent<MalDisplay>().moveToCoordinate.x; i++)
            {
                Destroy(showerMals[i]);
            }
        }
    }
    public void DestroyPoeByCatched(GameObject end)
    {
        isDestroyed = true;
        if(end.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x && end.GetComponent<MalDisplay>().moveToCoordinate.y >= currectCoordinate.y && showerMals.IndexOf(end) < GM.locateMaterixes.Count)
        {
            GameObject start = null;
            foreach(GameObject each in showerMals)
            {
                if(each.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y + 1 && each.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x)
                {
                    start = each;
                    break;
                }
            }
            for(int i = showerMals.IndexOf(start); i < showerMals.IndexOf(end)+1; i++)
            {
                Destroy(showerMals[i]);
            }
        }
        else if(end.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y && end.GetComponent<MalDisplay>().moveToCoordinate.x >= currectCoordinate.x && showerMals.IndexOf(end) < GM.locateMaterixes[currectCoordinate.x].locates.Count)
        {
            GameObject start = null;
            foreach(GameObject each in showerMals)
            {
                if(each.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x + 1 && each.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y)
                {
                    start = each;
                    break;
                }
            }
            for(int i = showerMals.IndexOf(start); i < showerMals.IndexOf(end) + 1; i++)
            {
                Destroy(showerMals[i]);
            }
        }
        else if(end.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x && end.GetComponent<MalDisplay>().moveToCoordinate.y <= currectCoordinate.y && showerMals.IndexOf(end) > 0)
        {
            GameObject start = null;
            foreach(GameObject each in showerMals)
            {
                if(each.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y - 1 && each.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x)
                {
                    start = each;
                    break;
                }
            }
            for(int i =  showerMals.IndexOf(start); i < showerMals.IndexOf(end) + 1; i++)
            {
                Destroy(showerMals[i]);
            }
        }
        else if(end.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y && end.GetComponent<MalDisplay>().moveToCoordinate.x <= currectCoordinate.x && showerMals.IndexOf(end) > 0)
        {
            GameObject start = null;
            foreach(GameObject each in showerMals)
            {
                if(each.GetComponent<MalDisplay>().moveToCoordinate.x == currectCoordinate.x - 1 && each.GetComponent<MalDisplay>().moveToCoordinate.y == currectCoordinate.y)
                {
                    start = each;
                    break;
                }
            }
            for(int i =  showerMals.IndexOf(start); i < showerMals.IndexOf(end) + 1; i++)
            {
                Destroy(showerMals[i]);
            }
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
