using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

  static float ATTACK_DURATION = .3f;

  public float attackDamage = 1;
  private Animator anim;
  private PlayerMovement player;
  private PlayerStateManager stateManager;

  void Start(){
    anim = GetComponent<Animator>();
    player = GetComponent<PlayerMovement>();
    stateManager = GetComponent<PlayerStateManager>();
  }

  void Update(){
    if(Input.GetButtonDown("Attack") && stateManager.GetCurrentState() != PlayerState.attack){
      anim.SetBool("isAttacking", true);
      StartCoroutine(AttackCo());
    }
  }

  private IEnumerator AttackCo(){
    stateManager.SetCurrentState(PlayerState.attack);
    yield return null;
    anim.SetBool("isAttacking", false);
    yield return new WaitForSeconds(ATTACK_DURATION);
    stateManager.SetCurrentState(PlayerState.idle);
  }
}
