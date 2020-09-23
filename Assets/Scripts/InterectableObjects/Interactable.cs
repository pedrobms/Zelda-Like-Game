using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour{

  public BallonType ballonType;
  public bool isPlayerInRange;
  public string dialog;
  public GameObject dialogBox;
  public SignalSender uiSignal;

  protected Text dialogText;
  private PlayerStateManager stateManager;
  private ContextBallon ballonManager;

  void Start(){
    stateManager = GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>();
    ballonManager = GameObject.FindWithTag("Player").GetComponent<ContextBallon>();
    dialogText = dialogBox.GetComponentInChildren<Text>();
  }

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
      ballonManager.SetCurrentBallonType(ballonType);
      uiSignal.Raise();
      isPlayerInRange = true;
    }
  }

  public virtual void OnTriggerExit2D(Collider2D other){
    if(other.CompareTag("Player") && !other.isTrigger){
      uiSignal.Raise();
      isPlayerInRange = false;
    }
  }

}
