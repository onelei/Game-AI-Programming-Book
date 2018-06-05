/********************************************************************************
** auth： Onelei
** date： 2017/7/4 15:00:12
** desc： 状态管理器;
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;
using System.Collections.Generic; 

namespace HFSM
{
    public class SampleHFSMManager : StateMachine<HFSM_State>
    {
        /// <summary>
        /// 状态A;
        /// </summary>
        public SMBaseA mSmA;
        /// <summary>
        /// 状态B;
        /// </summary>
        public SMBaseB mSmB;
        /// <summary>
        /// 状态列表;
        /// </summary>
        private Dictionary<HFSM_State, SMBase> SMList = new Dictionary<HFSM_State, SMBase>();
        /// <summary>
        /// 注册状态;
        /// </summary>
        /// <param name="_state"></param>
        /// <param name="_base"></param>
        public void Register(HFSM_State _state, SMBase _base)
        {
            if (SMList.ContainsKey(_state))
            {
                Debug.LogError("已经注册过状态了： " + _state);
                return;
            }
            SMList.Add(_state,_base);
        }
        /// <summary>
        /// 执行状态;
        /// </summary>
        /// <param name="_state"></param>
        public void OnExecute(HFSM_State _state)
        {
            if(!SMList.ContainsKey(_state))
            {
                Debug.LogError("无法执行当前状态，该状态没有注册： "+_state);
                return;
            }
            SMList[_state].SetState(_state);
            SMList.Remove(_state);
        }
        /// <summary>
        /// 初始化;
        /// </summary>
        protected override void OnStart()
        {
            base.OnStart();
            Register(HFSM_State.A, mSmA);
            Register(HFSM_State.B, mSmB);
            mCurState = HFSM_State.A;
        }
        /// <summary>
        /// 进去状态;
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(HFSM_State _state)
        {
            base.OnEnterState(_state);
        }
        /// <summary>
        /// 退出状态;
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnExitState(HFSM_State _state)
        {
            base.OnExitState(_state);
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
                    OnExecute(HFSM_State.A);
                    mCurState = HFSM_State.B;
                    break;
                case HFSM_State.B:
                    OnExecute(HFSM_State.B);
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
