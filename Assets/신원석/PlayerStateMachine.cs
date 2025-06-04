using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerStateMachine : StageManager<PlayerStateMachine.PlayerState>
{
    public enum PlayerState
    {
        Idle,
        Move,
        Jump,
    }

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // 각 상태 객체 생성 및 등록
        states[PlayerState.Idle] = new IdleState(PlayerState.Idle,animator);
        states[PlayerState.Move] = new MoveState(PlayerState.Move, animator,transform);

        // 초기 상태 설정
        currentState = states[PlayerState.Idle];
    }




}
