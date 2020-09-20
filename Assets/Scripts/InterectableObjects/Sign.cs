using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable{

  public override void OnTriggerEnter2D(Collider2D other){
    base.OnTriggerEnter2D(other);
    if(other.CompareTag("Player") && !other.isTrigger){
      dialogText.alignment = TextAnchor.MiddleCenter;
    }
  }

  public override void OnTriggerExit2D(Collider2D other){
    base.OnTriggerExit2D(other);
    if(other.CompareTag("Player") && !other.isTrigger){
      dialogText.alignment = TextAnchor.UpperLeft;
    }
  }

}
