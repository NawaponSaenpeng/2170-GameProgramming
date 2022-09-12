using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rb;
   [SerializeField] private float jumpForce = 5f;
   private float moveInput;
   private float moveSpeed = 5f;
   [SerializeField] private GemColors color;
   [SerializeField] private SpriteRenderer render;

   private void OnJump(InputValue value)
   {
      if (value.isPressed)
      {
         rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
      }
   }

   private void OnMove(InputValue value)
   {
      moveInput = value.Get<float>();
      rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.TryGetComponent(out PlayerColorChange playerColorChange))
      {
         GemColors color = playerColorChange.color;

         switch (color)
         {
            case GemColors.Red:
               render.color = Color.red;
               break;
            case GemColors.Blue:
               render.color = Color.blue;
               break;
            case GemColors.Green:
               render.color = Color.green;
               break;

         }

         Destroy(playerColorChange.gameObject);
      }
   }
}
