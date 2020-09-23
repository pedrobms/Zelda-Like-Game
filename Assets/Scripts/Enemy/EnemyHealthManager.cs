using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour{

    public float maxHealth;
    private float currentHealth;
    private bool isDead;
    private EnemyStateManager stateManager;
    private bool takingDamage = false;

    void Start(){
      currentHealth = maxHealth;
      stateManager = GetComponent<EnemyStateManager>();
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
      if(currentHealth <= 0){
        currentHealth = 0;
        isDead = true;
        this.gameObject.SetActive(false);
      }
    }

    public bool enemyIsDead(){
      return isDead;
    }

    void OnTriggerEnter2D(Collider2D other){
      Debug.Log("hit");
      if(other.CompareTag("PlayerHitBox") && !takingDamage){
        takingDamage = true;
        DecreaseHealth(other.GetComponentInParent<PlayerAttack>().attackDamage);
      }
    }

    void OnTriggerExit2D(Collider2D other){
      if(other.CompareTag("PlayerHitBox") && takingDamage){
        takingDamage = false;
      }
    }
}
