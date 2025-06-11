using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Core Systems")]
    public NPCStateMachine stateMachine;                //���� ��ȯ ����

    [Header("Sub Handlers")]
    public NPCMovementHandler movementHandler;          //�̵� ����(�ټ���, ����, ����, ���� ã��)
    public NPCAnimationHandler animationHandler;        // ���º� �ִϸ��̼� ����
    public NPCUIHandler uiHandler;                      //(NPC ���� UI ó�� (�ֹ�, ǥ��))

    [Header("Data")]
    public NPCSeatManager seatManager;
    public NPCData npcData;

    private void Awake()
    {
        stateMachine = new NPCStateMachine();
        stateMachine.Intialize(this);
        seatManager = FindObjectOfType<NPCSeatManager>();

    }

    private void Start()
    {
        stateMachine.ChangeState(new MoveToSeatState(this));
    }

    private void Update()
    {
        // ���� ������Ʈ ó��
        stateMachine?.CurrentState?.Update();
    }

    public void ChangeState(NpcState newState)
    {
        stateMachine.ChangeState(newState);
    }

}
