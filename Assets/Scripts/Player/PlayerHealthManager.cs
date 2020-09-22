using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour{

    public FloatValue maxHealth;
    public SignalSender uiSignal;
    private float currentHealth;
    private bool isDead = false;
    private PlayerStateManager stateManager;

    void Start(){
        currentHealth = maxHealth.runtimeValue;
        stateManager = GetComponent<PlayerStateManager>();
    }

    public float GetMaxHealth(){
      return maxHealth.runtimeValue;
    }

    public float GetCurrentHealth(){
      return currentHealth;
    }

    public void IncreaseHealth(float amountToIncrease){
      currentHealth += amountToIncrease;
      if(currentHealth >= maxHealth.runtimeValue){
        currentHealth = maxHealth.runtimeValue;
      }
      uiSignal.Raise();
    }

    public void DecreaseHealth(float amountToDecrease){
      currentHealth -= amountToDecrease;
      if(currentHealth < 0){
        currentHealth = 0;
        isDead = true;
      }
      uiSignal.Raise();
    }

    public bool playerIsDead(){
      return isDead;
    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.CompareTag("Enemy") && stateManager.GetCurrentState() != PlayerState.attack){
        DecreaseHealth(other.GetComponent<EnemyAttack>().attackDamage);
      }
    }
}
