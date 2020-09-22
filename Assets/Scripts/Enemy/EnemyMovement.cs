using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType {
  waitAproach,
  patrolPoints
}

public class EnemyMovement : MonoBehaviour{

    public MovementType movementType;
    public float speed;

    [Header("Chase player variables")]
    public float chaseRadius = 3;
    public float attackRadius = 1;

    private Vector2 homePosition;
    private EnemyStateManager stateManager;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform player;

    void Start(){
      stateManager = GetComponent<EnemyStateManager>();
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
      player = GameObject.FindWithTag("Player").transform;
      stateManager.SetCurrentState(EnemyState.idle);
    }

    void Awake(){
      homePosition = transform.position;
    }

    void OnEnable(){
      transform.position = homePosition;
    }

    void LateUpdate(){
      if(movementType == MovementType.waitAproach){
        CheckDistance();
      }
    }

    public virtual void CheckDistance(){
      if(Vector3.Distance(player.position, transform.position) <= chaseRadius
      && Vector3.Distance(player.position, transform.position) > attackRadius){
        if(stateManager.GetCurrentState() == EnemyState.walk || stateManager.GetCurrentState() == EnemyState.idle){
          Vector3 temp = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
          changeAnim(temp - transform.position);
          rb.MovePosition(temp);
          stateManager.SetCurrentState(EnemyState.walk);
          anim.SetBool("isWalking", true);
        }
      }else{
        if(Vector3.Distance(player.position, transform.position) > attackRadius){
          anim.SetBool("isWalking", false);
          stateManager.SetCurrentState(EnemyState.idle);
        }
      }
    }

    public void SetAnimFloat(Vector2 setVector){
      anim.SetFloat("moveX", setVector.x);
      anim.SetFloat("moveY", setVector.y);
    }

    public void changeAnim(Vector2 direction){
      direction.Normalize();
      if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
        if(direction.x > 0){
          SetAnimFloat(Vector2.right);
        }else if(direction.x < 0){
          SetAnimFloat(Vector2.left);
        }
      }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
        if(direction.y > 0){
          SetAnimFloat(Vector2.up);
        }else if(direction.y < 0){
          SetAnimFloat(Vector2.down);
        }
      }
    }

}
