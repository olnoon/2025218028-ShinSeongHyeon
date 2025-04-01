using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float roundTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Flip());
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }
    IEnumerator Flip()
    {
        while(true)
        {
            yield return new WaitForSeconds(roundTime);
            transform.localScale= new Vector2(-transform.localScale.x, transform.localScale.y);
            moveSpeed *= -1; 
        }
    }
}
