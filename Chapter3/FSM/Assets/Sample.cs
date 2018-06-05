/********************************************************************************
** auth： Onelei
** date： 2017/7/4 13:58:25
** desc： 示例
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;

public class Sample : StateMachine<UBState>
{ 
    /// <summary>
    /// 开始；
    /// </summary>
    protected override void OnStart()
    {
        base.OnStart();
        //设置开始状态；
        mCurState = UBState.INIT;
        Debug.Log("Sample 设置当前状态 " + mCurState);
    }
    /// <summary>
    /// 进入状态;
    /// </summary>
    /// <param name="_state"></param>
    protected override void OnEnterState(UBState _state)
    {
        base.OnEnterState(_state);
        Debug.Log("Sample 进入状态 " + mCurState);
    }
    /// <summary>
    /// 退出状态;
    /// </summary>
    /// <param name="_state"></param>
    protected override void OnExitState(UBState _state)
    {
        base.OnExitState(_state);
        Debug.Log("Sample 退出状态 " + mCurState);
    }
    /// <summary>
    /// 更新状态;
    /// </summary>
    public override void OnUpdateState()
    {
        base.OnUpdateState();

        switch(mCurState)
        {
            case UBState.NONE:
                break;
            case UBState.INIT:
                mCurState = UBState.Enter;
                break;
            case UBState.Enter:
                mCurState = UBState.Exit;
                break;
            case UBState.Exit:
                break;
            default:
                break;
        }
    }

    public void SetState(UBState _state)
    {
        mCurState = _state;
    }

}
