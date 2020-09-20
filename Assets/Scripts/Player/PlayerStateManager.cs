using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
  walk,
  attack,
  interact,
  stagger,
  idle
}

public class PlayerStateManager : MonoBehaviour{

  private PlayerState currentState;

  public void SetCurrentState(PlayerState newState){
    this.currentState = newState;
  }

  public PlayerState GetCurrentState(){
    return this.currentState;
  }

  public void ChangeState(PlayerState newState){
    if(currentState != newState){
      currentState = newState;
    }
  }
}
