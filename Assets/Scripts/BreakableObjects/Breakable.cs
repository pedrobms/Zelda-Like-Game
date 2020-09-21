using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour{

    static float DESTROY_DURATION = .5f;

    private Animator anim;

    void Start(){
      anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.CompareTag("PlayerHitBox")){
        Smash();
      }
    }

    public void Smash(){
      anim.SetBool("isBroken", true);
      StartCoroutine(BreakCo());
    }

    IEnumerator BreakCo(){
      yield return new WaitForSeconds(DESTROY_DURATION);
      this.gameObject.SetActive(false);
    }
}
