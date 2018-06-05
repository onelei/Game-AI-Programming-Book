/********************************************************************************
** auth： Onelei
** date： 2017/7/4 14:31:00
** desc： 分层状态机
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;

namespace Assets
{
    public enum HFSM_State
    {
        NONE,
        A,
        B, 
        Exit,
    }
     
    public class SampleHFSM : StateMachine<HFSM_State>
    {
        public SampleStateA mSampleA;
        public SampleStateB mSampleB;

        protected override void OnStart()
        {
            base.OnStart();
            mCurState = HFSM_State.A;
        }

        protected override void OnEnterState(HFSM_State _state)
        {
            base.OnEnterState(_state);
        }

        protected override void OnExitState(HFSM_State _state)
        {
            base.OnExitState(_state);
        }

        public override void OnUpdateState()
        {
            base.OnUpdateState();
            switch(mCurState)
            {
                case HFSM_State.NONE:
                    break;
                case HFSM_State.A:
                    mSampleA.SetState(UBState.INIT);
                    mCurState = HFSM_State.B;
                    break;
                case HFSM_State.B:
                    mSampleB.SetState(UBState.INIT);
                    mCurState = HFSM_State.Exit;
                    break;
                case HFSM_State.Exit:
                    break;
                default:
                    break;
            }
        }
    }
}
