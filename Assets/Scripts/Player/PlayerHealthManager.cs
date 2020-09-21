using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour{

    public float maxHealth;
    private float currentHealth;
    private bool isDead = false;

    void Start(){
        currentHealth = maxHealth;
    }

    public float GetMaxHealth(){
      return maxHealth;
    }

    public float GetCurrentHealth(){
      return currentHealth;
    }

    public void IncreaseHealth(float amountToIncrease){
      currentHealth += amountToIncrease;
      if(currentHealth >= maxHealth){
        currentHealth = maxHealth;
      }
    }

    public void DecreaseHealth(float amountToDecrease){
      currentHealth -= amountToDecrease;
      if(currentHealth < 0){
        currentHealth = 0;
        isDead = true;
      }
    }

    public bool playerIsDead(){
      return isDead;
    }
}
