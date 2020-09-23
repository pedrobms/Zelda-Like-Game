using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallonType{
  question,
  exclamation,
  points
}

public class ContextBallon : MonoBehaviour{
  public GameObject questionBallon;
  public GameObject exclamationBallon;
  public GameObject pointsBallon;
  private BallonType currentBallonType;
  private bool isEnable = false;

  public void ChangeBallon(){
    isEnable = !isEnable;
    if(isEnable){
      if(currentBallonType == BallonType.question){
        questionBallon.SetActive(true);
      }else if(currentBallonType == BallonType.exclamation){
        exclamationBallon.SetActive(true);
      }else if(currentBallonType == BallonType.points){
        pointsBallon.SetActive(true);
      }
    }else{
      questionBallon.SetActive(false);
      exclamationBallon.SetActive(false);
      pointsBallon.SetActive(false);
    }
  }

  public BallonType GetCurrentBallonType(){
    return currentBallonType;
  }

  public void SetCurrentBallonType(BallonType newType){
    currentBallonType = newType;
  }
}
