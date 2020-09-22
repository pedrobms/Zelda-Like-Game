using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUIManager : MonoBehaviour{

      public Image[] hearts;
      public Sprite fullHeart;
      public Sprite threeQuartersHeart;
      public Sprite halfHeart;
      public Sprite oneQuarterHeart;
      public Sprite emptyHeart;
      private PlayerHealthManager healthManager;
      private int maxHearts;

      void Start(){
        healthManager = GameObject.FindWithTag("Player").GetComponent<PlayerHealthManager>();
        maxHearts = Mathf.FloorToInt(healthManager.GetMaxHealth()/4);
        InitHearts();
      }

      void OnEnable(){
      }

      public void InitHearts(){
        for(int i=0; i<maxHearts; i++){
          hearts[i].gameObject.SetActive(true);
          hearts[i].sprite = fullHeart;
        }
      }

      public void UpdateHearts(){
        InitHearts();
        float tempHealth = healthManager.GetCurrentHealth() / 4;
        for(int i=0; i<maxHearts; i++){
          if(i <= tempHealth - 1){
            hearts[i].sprite = fullHeart;
          }else if(i >= tempHealth){
            hearts[i].sprite = emptyHeart;
          }else if(i < tempHealth - 0.5){
            hearts[i].sprite = threeQuartersHeart;
          }else if(i > tempHealth - 0.5){
            hearts[i].sprite = oneQuarterHeart;
          }else{
            hearts[i].sprite = halfHeart;
          }
        }
      }
}
