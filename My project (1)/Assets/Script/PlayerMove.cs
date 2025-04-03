using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //뜯어온 코드에서 수정을 가했습니다.
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    // private Animator anim;
    float moveX = 0f;
    float moveY  = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            MoveHorizontally();
            MoveVertical();

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                moveX = 0f;
                moveY  = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY  * moveSpeed);
    }

    void MoveHorizontally()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // anim.SetInteger("State", 1);
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // anim.SetInteger("State", 1);
            moveX = 1f;
        }
    }
    
    void MoveVertical()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            moveY  = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY  = -1f;
        }
    }
}
