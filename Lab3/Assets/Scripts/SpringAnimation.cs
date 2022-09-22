using UnityEngine;

public class SpringAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private float bounce = 15f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            animator.SetBool("SuperJump", true);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            animator.SetBool("SuperJump", false);
        }
        if (col.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = bounce;
                rb.velocity = velocity;
            }
        }
    }
}
