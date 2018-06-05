/********************************************************************************
** auth： Onelei
** date： 2017/7/4 14:41:23
** desc： 描述
** Ver.:  V1.0.0
*********************************************************************************/
using System;
using UnityEngine;

public class SampleStateA : StateMachine<UBState>
{ 
    public void  SetState(UBState state)
    {
        //设置开始状态；
        mCurState = state;
        Debug.Log("SampleStateA 设置当前状态 " + state);
    }
    /// <summary>
    /// 开始；
    /// </summary>
    protected override void OnStart()
    {
        base.OnStart(); 
    }
    /// <summary>
    /// 进入状态;
    /// </summary>
    /// <param name="_state"></param>
    protected override void OnEnterState(UBState _state)
    {
        base.OnEnterState(_state);
        Debug.Log("SampleStateA 进入状态 " + mCurState);
    }
    /// <summary>
    /// 退出状态;
    /// </summary>
    /// <param name="_state"></param>
    protected override void OnExitState(UBState _state)
    {
        base.OnExitState(_state);
        Debug.Log("SampleStateA 退出状态 " + mCurState);
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


}

