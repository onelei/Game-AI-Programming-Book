/********************************************************************************
** auth： Onelei
** date： 2017/7/4 15:12:07
** desc： 状态A;
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine; 

namespace HFSM
{
    public class SMBaseA : SMBase
    {
        /// <summary>
        /// 开始；
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            Debug.Log("SMBaseA 初始化");
        }
        /// <summary>
        /// 进入状态;
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(HFSM_State _state)
        {
            base.OnEnterState(_state);
            Debug.Log("SMBaseA 进入状态 " + mCurState);
        }
        /// <summary>
        /// 退出状态;
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnExitState(HFSM_State _state)
        {
            base.OnExitState(_state);
            Debug.Log("SMBaseA 退出状态 " + mCurState);
        }
        /// <summary>
        /// 更新状态;
        /// </summary>
        public override void OnUpdateState()
        {
            base.OnUpdateState();

            switch (mCurState)
            {
                case HFSM_State.NONE:
                    break;
                case HFSM_State.A:
                    mCurState = HFSM_State.Exit;
                    break;
                case HFSM_State.B:
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
