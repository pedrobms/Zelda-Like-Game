using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerKnockback : MonoBehaviour{

  public float thrust;
  public float knockTime;

  private Rigidbody2D rb;
  private PlayerStateManager stateManager;

  void Start(){
    rb = GetComponent<Rigidbody2D>();
    stateManager = GetComponent<PlayerStateManager>();
  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.CompareTag("Enemy") && (stateManager.GetCurrentState() == PlayerState.idle || stateManager.GetCurrentState() == PlayerState.walk)){
      //Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
      Vector3 difference = transform.position - other.transform.position;
      Debug.Log("raw" + difference);
      difference = difference.normalized * thrust;
      Debug.Log("normalized: " + difference);
      //rb.AddForce(difference, ForceMode2D.Impulse);
      rb.DOMove(transform.position + difference, knockTime);
      stateManager.SetCurrentState(PlayerState.stagger);
      StartCoroutine(KnockCo());
    }
  }

  IEnumerator KnockCo(){
    yield return new WaitForSeconds(knockTime);
    rb.velocity = Vector2.zero;
    stateManager.SetCurrentState(PlayerState.idle);
    rb.velocity = Vector2.zero;
  }

}
