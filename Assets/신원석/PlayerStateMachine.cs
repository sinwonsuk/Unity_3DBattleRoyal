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

        // �� ���� ��ü ���� �� ���
        states[PlayerState.Idle] = new IdleState(PlayerState.Idle,animator);
        states[PlayerState.Move] = new MoveState(PlayerState.Move, animator,transform);

        // �ʱ� ���� ����
        currentState = states[PlayerState.Idle];
    }




}
