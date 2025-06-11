using System.Net.NetworkInformation;

public class NPCStateMachine
{
    public NpcState CurrentState { get; private set; }
    private NPCController npc;

    public void Intialize(NPCController controller) //초기화
    {
        npc = controller;
    }
    public void ChangeState(NpcState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }  
}