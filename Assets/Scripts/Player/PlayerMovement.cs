using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
  [Header("Player Stats")]
  public float speed;

  private Animator thisAnimator;
  private Rigidbody2D thisRigidbody;
  //Váriavel para armazenar próxima posição do Player
  private Vector3 change;
  private PlayerStateManager playerStateManager;


  void Start(){
    playerStateManager = GetComponent<PlayerStateManager>();
    thisAnimator = GetComponent<Animator>();
    thisAnimator.SetFloat("moveX", 0);
    thisAnimator.SetFloat("moveY", -1);
    thisRigidbody = GetComponent<Rigidbody2D>();
    playerStateManager.SetCurrentState(PlayerState.idle);
  }

  void Update(){
    //Reseta váriavel change
    change = Vector3.zero;
    //Preenche váriavel "change" com valores para o próximo movimento de acordo com "input" do teclado
    change.x = Input.GetAxisRaw("Horizontal");
    change.y = Input.GetAxisRaw("Vertical");
    if(playerStateManager.GetCurrentState() == PlayerState.idle || playerStateManager.GetCurrentState() == PlayerState.walk){
      UpdateAnimationAndMove();
    }
  }

  void MovePlayer(){
    change.Normalize();
    thisRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
  }

  void UpdateAnimationAndMove(){
    if(change != Vector3.zero){
      playerStateManager.SetCurrentState(PlayerState.walk);
      MovePlayer();
      change.x = Mathf.Round(change.x);
      change.y = Mathf.Round(change.y);
      thisAnimator.SetFloat("moveX", change.x);
      thisAnimator.SetFloat("moveY", change.y);
      thisAnimator.SetBool("isWalking", true);
    }else{
      thisAnimator.SetBool("isWalking", false);
      playerStateManager.SetCurrentState(PlayerState.idle);
    }
  }
}
