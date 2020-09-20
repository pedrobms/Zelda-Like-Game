using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour{

  public GameObject virtualCamera;

  public virtual void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player") && !other.isTrigger){
      virtualCamera.SetActive(true);
    }
  }

  public virtual void OnTriggerExit2D(Collider2D other){
    if(other.CompareTag("Player") && !other.isTrigger){
      virtualCamera.SetActive(false);
    }
  }

  public void ChangeActivation(Component component, bool activation){
    component.gameObject.SetActive(activation);
  }

}
