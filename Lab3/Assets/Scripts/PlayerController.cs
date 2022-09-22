using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rb;
   [SerializeField] private float jumpForce = 8f;
   private float _moveInput;
   private bool _isGrounded;
   [SerializeField] private Collider2D playerCollider;
   private float moveSpeed = 5f;
   [SerializeField] private GemColors color;
   [SerializeField] private SpriteRenderer render;
   [SerializeField] private PlayerAnimatorController animatorController;

   [Header("Ground Check")] 
   [SerializeField] private LayerMask groundLayer;
   [SerializeField] private float groundCheckDistance = 0.01f;

   private bool coJump;
   private void Update()
   {
      CheckGround();
      SetAnimatorParameter();
   }
   

   #region Actions

   private void OnJump(InputValue value)
   {
      if (!value.isPressed) return;
      TryJump();
   }
   
   private void FixedUpdate()
   {
      rb.velocity = new Vector2(_moveInput * moveSpeed, rb.velocity.y);
   }
   
   private void OnMove(InputValue value)
   {
      _moveInput = value.Get<float>();
      FlipPlayerSprite();
   }

   private void Jump(float force)
   {
      rb.velocity = new Vector2(rb.velocity.x, 0f);
      rb.AddForce(force * transform.up, ForceMode2D.Impulse);
   }

   private void TryJump()
   {
      if (!_isGrounded) 
      {
         if (coJump)
         {
            Jump(jumpForce);
            Debug.Log("Coyote");
         }
      }
      else
      {
         Jump(jumpForce);
      }
   }
   private void FlipPlayerSprite()
   {
      if (_moveInput < 0)
      {
         transform.localScale = new Vector3(-1, 1, 1);
      }
      else if (_moveInput > 0)
      {
         transform.localScale = Vector3.one;
      }
   }

   private void CheckGround()
   {
      var playerBounds = playerCollider.bounds;
      RaycastHit2D raycastHit = Physics2D.BoxCast(playerBounds.center, playerBounds.size, 0f, Vector2.down,
         groundCheckDistance, groundLayer);
      _isGrounded = raycastHit.collider != null;

      if (raycastHit.collider != null)
      {
         _isGrounded = true;
      }
      else
      {
         _isGrounded = false;
         StartCoroutine(CoyoteJump());
      }
      
   }

   private void SetAnimatorParameter()
   {
      animatorController.SetAnimatorParameter(rb.velocity, _isGrounded);
   }
   
   #endregion

   private IEnumerator CoyoteJump()
   {
      coJump = true;
      yield return new WaitForSeconds(0.15f);
      coJump = false;
   }
}
