using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float roundTime;
    public bool isAnchored;
    public int acceleration = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Flip());
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed * acceleration, rb.linearVelocity.y);
        if(isAnchored)
        {
            acceleration = 0;
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

    IEnumerator Flip()
    {
        while(!isAnchored)
        {
            yield return new WaitForSeconds(roundTime);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            moveSpeed *= -1; 
        }
    }
}
