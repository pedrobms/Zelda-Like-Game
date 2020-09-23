using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyKnockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;

    private Rigidbody2D rb;
    private EnemyStateManager stateManager;

    void Start(){
      rb = GetComponent<Rigidbody2D>();
      stateManager = GetComponent<EnemyStateManager>();
    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.CompareTag("PlayerHitBox") || (other.CompareTag("Enemy") && other.GetComponent<EnemyStateManager>().GetCurrentState() != EnemyState.idle)){
        //Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
        Vector3 difference = transform.position - other.transform.position;
        Debug.Log("raw" + difference);
        difference = difference.normalized * thrust;
        Debug.Log("normalized: " + difference);
        //rb.AddForce(difference, ForceMode2D.Impulse);
        rb.DOMove(transform.position + difference, knockTime);
        StartCoroutine(KnockCo());
      }
    }

    IEnumerator KnockCo(){
      stateManager.SetCurrentState(EnemyState.stagger);
      yield return new WaitForSeconds(knockTime);
      rb.velocity = Vector2.zero;
      stateManager.SetCurrentState(EnemyState.idle);
      rb.velocity = Vector2.zero;
    }

}
