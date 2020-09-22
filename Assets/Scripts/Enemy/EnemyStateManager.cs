using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
  idle,
  walk,
  attack,
  stagger
}

public class EnemyStateManager : MonoBehaviour{

  private EnemyState currentState;

  public void SetCurrentState(EnemyState newState){
    this.currentState = newState;
  }

  public EnemyState GetCurrentState(){
    return this.currentState;
  }

  public void ChangeState(EnemyState newState){
    if(currentState != newState){
      currentState = newState;
    }
  }

}
