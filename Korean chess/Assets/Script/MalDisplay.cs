using UnityEngine;

public class MalDisplay : MonoBehaviour
{
    public GameObject originalObj;
    public Vector2Int moveToCoordinate;
    public string team;
    public malKinds malKind;

    void Awake()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    void OnMouseDown()
    {
        originalObj.transform.position = transform.position;
        originalObj.GetComponent<Mal>().UnSelectMal();
        originalObj.GetComponent<Mal>().currectCoordinate = moveToCoordinate;
        // if(FindFirstObjectByType<GameManager>().redTurn == "Red")
        // {
        //     FindFirstObjectByType<GameManager>().redTurn = "Blue";
        // }
        // else if(FindFirstObjectByType<GameManager>().redTurn == "Blue")
        // {
        //     FindFirstObjectByType<GameManager>().redTurn = "Red";
        // }
    }

    public void CreateMaDiagonal()
    {
        GameManager GM = FindFirstObjectByType<GameManager>();
        Color color = new Color(0, 0, 0, 0.5f);
        if(originalObj.GetComponent<Mal>().currectCoordinate.x >= moveToCoordinate.x && moveToCoordinate.x-1 >= 0 && originalObj.GetComponent<Mal>().currectCoordinate.y == moveToCoordinate.y)
        {
            
            if(moveToCoordinate.y-1 >= 0)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
            if(moveToCoordinate.y+1 <= GM.locateMaterixes.Count)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y+1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y+1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
        }
        else if(originalObj.GetComponent<Mal>().currectCoordinate.x <= moveToCoordinate.x && moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y].locates.Count && originalObj.GetComponent<Mal>().currectCoordinate.y == moveToCoordinate.y)
        {
            if(moveToCoordinate.y - 1 >= 0 && moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y - 1].locates.Count) 
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x + 1, moveToCoordinate.y - 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y - 1].locates[moveToCoordinate.x + 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
            if(moveToCoordinate.y + 1 < GM.locateMaterixes.Count && moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y + 1].locates.Count)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x + 1, moveToCoordinate.y + 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y + 1].locates[moveToCoordinate.x + 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
        }
        else if(originalObj.GetComponent<Mal>().currectCoordinate.y >= moveToCoordinate.y && moveToCoordinate.y-1 >= 0 && originalObj.GetComponent<Mal>().currectCoordinate.x == moveToCoordinate.x)
        {
            
            if(moveToCoordinate.x-1 >= 0)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
            if(moveToCoordinate.x+1 <= GM.locateMaterixes[moveToCoordinate.y].locates.Count)
            {
                //TODO 여기 고치기
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x+1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x+1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
        }
        else if(originalObj.GetComponent<Mal>().currectCoordinate.y <= moveToCoordinate.y && moveToCoordinate.y + 1 < GM.locateMaterixes.Count && originalObj.GetComponent<Mal>().currectCoordinate.x == moveToCoordinate.x) 
        {
            if (moveToCoordinate.x - 1 >= 0 && moveToCoordinate.x - 1 < GM.locateMaterixes[moveToCoordinate.y + 1].locates.Count) {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x - 1, moveToCoordinate.y + 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y + 1].locates[moveToCoordinate.x - 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
            if (moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y + 1].locates.Count) {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x + 1, moveToCoordinate.y + 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y + 1].locates[moveToCoordinate.x + 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
        }

        Destroy(gameObject);
        originalObj.GetComponent<Mal>().showerMals.Remove(gameObject);
    }

    public void CreateSangDiagonal()
    {
        GameManager GM = FindFirstObjectByType<GameManager>();
        Color color = new Color(0, 0, 0, 0.5f);
        if(originalObj.GetComponent<Mal>().currectCoordinate.x >= moveToCoordinate.x && moveToCoordinate.x-1 >= 0 && originalObj.GetComponent<Mal>().currectCoordinate.y == moveToCoordinate.y)
        {
            if(moveToCoordinate.y-1 >= 0)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
            if(moveToCoordinate.y+1 <= GM.locateMaterixes.Count)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y+1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y+1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
        }
        else if(originalObj.GetComponent<Mal>().currectCoordinate.x <= moveToCoordinate.x && moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y].locates.Count && originalObj.GetComponent<Mal>().currectCoordinate.y == moveToCoordinate.y)
        {
            if(moveToCoordinate.y - 1 >= 0 && moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y - 1].locates.Count) 
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x + 1, moveToCoordinate.y - 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y - 1].locates[moveToCoordinate.x + 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
            if(moveToCoordinate.y + 1 < GM.locateMaterixes.Count && moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y + 1].locates.Count)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x + 1, moveToCoordinate.y + 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y + 1].locates[moveToCoordinate.x + 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
        }
        else if(originalObj.GetComponent<Mal>().currectCoordinate.y >= moveToCoordinate.y && moveToCoordinate.y-1 >= 0 && originalObj.GetComponent<Mal>().currectCoordinate.x == moveToCoordinate.x)
        {
            if(moveToCoordinate.x-1 >= 0)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
            if(moveToCoordinate.x+1 <= GM.locateMaterixes[moveToCoordinate.y].locates.Count)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x+1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x+1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
        }
        else if(originalObj.GetComponent<Mal>().currectCoordinate.y <= moveToCoordinate.y && moveToCoordinate.y + 1 < GM.locateMaterixes.Count && originalObj.GetComponent<Mal>().currectCoordinate.x == moveToCoordinate.x) 
        {
            if (moveToCoordinate.x - 1 >= 0 && moveToCoordinate.x - 1 < GM.locateMaterixes[moveToCoordinate.y + 1].locates.Count) {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x - 1, moveToCoordinate.y + 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y + 1].locates[moveToCoordinate.x - 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
            if (moveToCoordinate.x + 1 < GM.locateMaterixes[moveToCoordinate.y + 1].locates.Count) {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x + 1, moveToCoordinate.y + 1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y + 1].locates[moveToCoordinate.x + 1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
                next.GetComponent<MalDisplay>().AgainSangDiagonal();
            }
        }

        Destroy(gameObject);
        originalObj.GetComponent<Mal>().showerMals.Remove(gameObject);
    }
    public void AgainSangDiagonal() 
    {
        GameManager GM = FindFirstObjectByType<GameManager>();
        Color color = new Color(0, 0, 0, 0.5f);
        if(originalObj.GetComponent<Mal>().currectCoordinate.y <= moveToCoordinate.y && moveToCoordinate.y+1 < GM.locateMaterixes.Count)
        {
            if(originalObj.GetComponent<Mal>().currectCoordinate.x <= moveToCoordinate.x && moveToCoordinate.x+1 < GM.locateMaterixes[moveToCoordinate.y].locates.Count)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x+1, moveToCoordinate.y+1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y+1].locates[moveToCoordinate.x+1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
            else if(originalObj.GetComponent<Mal>().currectCoordinate.x >= moveToCoordinate.x && moveToCoordinate.x-1 > 0)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y+1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y+1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
        }
        else if(originalObj.GetComponent<Mal>().currectCoordinate.y >= moveToCoordinate.y && moveToCoordinate.y-1 > 0)
        {
            if(originalObj.GetComponent<Mal>().currectCoordinate.x <= moveToCoordinate.x && moveToCoordinate.x+1 < GM.locateMaterixes[moveToCoordinate.y].locates.Count)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x+1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x+1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
            else if(originalObj.GetComponent<Mal>().currectCoordinate.x >= moveToCoordinate.x && moveToCoordinate.x-1 > 0)
            {
                Vector2Int nextPos = new Vector2Int(moveToCoordinate.x-1, moveToCoordinate.y-1);
                GameObject next = Instantiate(gameObject, GM.locateMaterixes[moveToCoordinate.y-1].locates[moveToCoordinate.x-1].position, Quaternion.identity);
                originalObj.GetComponent<Mal>().CreateEachDisplay(next, color, nextPos);
            }
        }
        Destroy(gameObject);
        originalObj.GetComponent<Mal>().showerMals.Remove(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Mal>() != null && collision.gameObject != originalObj)
        {
            if(collision.GetComponent<Mal>().malTeam == team)
            {
                switch(malKind)
                {
                    case malKinds.Char:
                        originalObj.GetComponent<Mal>().DestroyCharByCatched(gameObject);
                    break;
                    case malKinds.Poe:
                        // if(collision.GetComponent<Mal>().malKind == malKinds.Poe)
                        // {
                        //     originalObj.GetComponent<Mal>().PoeCathcedByPoe(gameObject);
                        // }
                        originalObj.GetComponent<Mal>().DestroyPoeByCatched(gameObject);
                        // originalObj.GetComponent<Mal>().PoeCatedAgain(gameObject);
                        //TODO 한번 넘으면 그 다음에 겹치는 거 있을 땐 못 넘게 하기
                        //TODO 포가 포 못 먹게 하기
                    break;
                    default:
                        originalObj.GetComponent<Mal>().showerMals.Remove(gameObject);
                        Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
