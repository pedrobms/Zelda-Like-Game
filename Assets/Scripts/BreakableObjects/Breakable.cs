using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour{

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
      yield return new WaitForSeconds(.5f);
      this.gameObject.SetActive(false);
    }
}
