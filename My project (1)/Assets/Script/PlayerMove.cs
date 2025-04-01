using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //뜯어온 코드에서 수정을 가했습니다.
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    // private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            float horizontalMove = 0f;
            float verticalMove = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                // anim.SetInteger("State", 1);
                horizontalMove = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // anim.SetInteger("State", 1);
                horizontalMove = 1f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                verticalMove = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                verticalMove = -1f;
            }
            
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                horizontalMove = 0f;
                verticalMove = 0f;
            }

            rb.linearVelocity = new Vector2(horizontalMove * moveSpeed, verticalMove * moveSpeed);
        }
    }
}
