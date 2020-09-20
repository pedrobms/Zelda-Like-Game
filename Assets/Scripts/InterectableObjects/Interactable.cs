using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour{

  public bool isPlayerInRange;
  public GameObject dialogBox;
  public Text dialogText;
  public string dialog;

  private PlayerStateManager stateManager;

  public virtual void Update(){
    if(Input.GetButtonDown("Interact") && isPlayerInRange && dialogBox != null){
      stateManager.SetCurrentState(PlayerState.interact);
      if(dialogBox.activeInHierarchy){
        stateManager.SetCurrentState(PlayerState.idle);
        dialogBox.SetActive(false);
      }else{
        dialogBox.SetActive(true);
        dialogText.text = dialog;
      }
    }
  }

  public virtual void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player") && !other.isTrigger){      
      stateManager = other.GetComponent<PlayerStateManager>();
      isPlayerInRange = true;
    }
  }

  public virtual void OnTriggerExit2D(Collider2D other){
    if(other.CompareTag("Player") && !other.isTrigger){
      isPlayerInRange = false;
    }
  }

}
