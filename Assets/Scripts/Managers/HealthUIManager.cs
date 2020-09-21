using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour{

  public PlayerHealthManager healthManager;
  public Slider healthSlider;
  public Text healthCounter;

  void Start(){
    healthCounter.text = healthManager.GetMaxHealth() + "/" + healthManager.GetMaxHealth();
    healthSlider.maxValue = healthManager.GetMaxHealth();
    healthSlider.value = healthManager.GetMaxHealth();
  }

}
