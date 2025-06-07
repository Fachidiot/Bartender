using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Core Systems")]
    public NPCStateMachine stateMachine;                //상태 전환 로직

    [Header("Sub Handlers")]
    public NPCMovementHandler movementHandler;          //이동 관련(줄서기, 퇴장, 입장, 의자 찾기)
    public NPCAnimationHandler animationHandler;        // 상태별 애니메이션 관리
    public NPCUIHandler uiHandler;                      //(NPC 위에 UI 처리 (주문, 표정))

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
        // 상태 업데이트 처리
        stateMachine?.CurrentState?.Update();
    }

    public void ChangeState(NpcState newState)
    {
        stateMachine.ChangeState(newState);
    }

}
