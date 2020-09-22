using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour{

    public string initialScene;
    public GameObject titleMenu;
    public GameObject pressEnterText;
    public Animator fadeEffectAnim;

    void Update(){
      if(Input.GetKeyDown("return")){
        pressEnterText.SetActive(false);
        titleMenu.SetActive(true);
      }
    }

    public void NewGame(){
      titleMenu.SetActive(false);
      StartCoroutine(StartCo());
    }

    public void ExitGame(){
      Application.Quit();
    }

    IEnumerator StartCo(){
      yield return null;
      fadeEffectAnim.SetBool("fadeToBlack", true);
      yield return new WaitForSeconds(2f);
      SceneManager.LoadScene(initialScene);
    }

}
