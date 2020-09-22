using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour{

  private PlayerHealthManager healthManager;
  private Slider healthSlider;
  private Text healthCounter;

  void Start(){
    healthManager = GameObject.FindWithTag("Player").GetComponent<PlayerHealthManager>();
    healthSlider = GetComponent<Slider>();
    healthCounter = GetComponentInChildren<Text>();
    healthCounter.text = healthManager.GetMaxHealth() + "/" + healthManager.GetMaxHealth();
    healthSlider.maxValue = healthManager.GetMaxHealth();
    healthSlider.value = healthManager.GetMaxHealth();
  }

  public void UpdateHealth(){
    healthCounter.text = healthManager.GetCurrentHealth() + "/" + healthManager.GetMaxHealth();
    healthSlider.value = healthManager.GetCurrentHealth();
  }

}
