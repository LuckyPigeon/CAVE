using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveEnemy : MonoBehaviour
{
	#region Private variable defination
    private CharacterController enemyController;
    private Animator animator;
	private Vector3 destination; // 目的地
    
    [SerializeField]
	private float walkSpeed = 1.0f; // 歩くスピード
	private Vector3 velocity; // 速度
	private Vector3 direction; // 移動方向
	private bool arrived; // 到着フラグ
	private SetPosition setPosition; // SetPositionスクリプト
    [SerializeField]
	private float waitTime = 5f; // 待ち時間
	private float elapsedTime; // 経過時間
	private EnemyState state; // 敵の状態
	private Transform playerTransform; // 追いかけるキャラクター
	[SerializeField]
	private float freezeTime = 0.3f; //攻撃した後のフリーズ時間
	#endregion

	#region Public variable defination
    public enum EnemyState
    {
        Walk,
        Wait,
        Chase,
        Attack,
        Freeze
    };
	public AudioSource attacksound;
	public AudioSource zombiescream;
	#endregion

    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState("wait");
    }

    void Update()
    {
        
		if (state == EnemyState.Walk || state == EnemyState.Chase) // 見回りまたはキャラクターを追いかける状態
        {
			if (state == EnemyState.Chase) // キャラクターを追いかける状態であればキャラクターの目的地を再設定
            {
                setPosition.SetDestination(playerTransform.position);
            }

            if (enemyController.isGrounded)
            {
                velocity = Vector3.zero;
                animator.SetFloat("Speed", 2.0f);
                direction = (setPosition.GetDestination() - transform.position).normalized;
                transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
                velocity = direction * walkSpeed;
            }

            if (state == EnemyState.Walk)
            {
				if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.7f) //目的地に到着したかどうかの判定
                {
                    SetState("wait");
                    animator.SetFloat("Speed", 0.0f);
                }
            }else if (state == EnemyState.Chase){
				if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 1f) // 攻撃する距離だったら攻撃
                {
                    SetState("attack");
                }
            }
		}else if (state == EnemyState.Wait){ // 到着していたら一定時間待つ
            elapsedTime += Time.deltaTime;

			if (elapsedTime > waitTime) // 待ち時間を越えたら次の目的地を設定
            {
                SetState("walk");
			}
		}else if (state == EnemyState.Freeze){ // 攻撃後のフリーズ状態
            elapsedTime += Time.deltaTime;

            if (elapsedTime > freezeTime)
            {
                SetState("walk");
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);
    }

	#region Set enemy state
	public void SetState(string mode, Transform obj = null) // 敵キャラクターの状態変更メソッド
    {
        if (mode == "walk")
        {
            arrived = false;
            elapsedTime = 0f;
            state = EnemyState.Walk;
            setPosition.CreateRandomPosition();
			attacksound.Pause ();
			zombiescream.Pause ();
        }
        else if (mode == "chase")
        {
            state = EnemyState.Chase;
			arrived = false; // 待機状態から追いかける場合もあるのでOff
			playerTransform = obj; // 追いかける対象をセット
			attacksound.Pause ();
			zombiescream.Pause ();
        }
        else if (mode == "wait")
        {
            elapsedTime = 0f;
            state = EnemyState.Wait;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
			attacksound.Pause ();
			zombiescream.Pause ();
        }
        else if (mode == "attack")
        {
            state = EnemyState.Attack;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", true);
			attacksound.Play ();
			zombiescream.Play ();
        }
        else if (mode == "freeze")
        {
            elapsedTime = 0f;
            velocity = Vector3.zero;
            state = EnemyState.Freeze;
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Attack", false);
			attacksound.Pause ();
			zombiescream.Pause ();
        }
    }
	#endregion

	#region Get enemy state
    public EnemyState GetState()
    {
        return state;
    }
	#endregion
}



