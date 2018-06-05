/********************************************************************************
** auth： Onelei
** date： 2017/7/4 15:04:23
** desc： 状态基类;
** Ver.:  V1.0.0
*********************************************************************************/

using UnityEngine;

namespace FSM2
{
    public class FSM2Base : StateMachine<FSM2Base.NPCState>
    {
        public Animator m_Animator;

        public FSM2Base(Animator animator)
        {
            m_Animator = animator;
        }
        /// <summary>
        /// 状态；
        /// </summary>
        public enum NPCState
        {
            Stand,//站立;
            Crouch,//下蹲;
            Forward,//向前;
            Jump,//跳跃
        }

        /// <summary>
        /// 设置状态；
        /// </summary>
        /// <param name="_state"></param>
        public void SetState(NPCState _state)
        {
            mCurState = _state;
        }

        #region 动作 

        public void doIdle()
        {
            m_Animator.SetBool("OnGround", true);
            m_Animator.SetFloat("Forward", 0f, 0f, 0f);
        }

        public void doForward()
        {
            m_Animator.SetBool("OnGround", true);
            m_Animator.SetFloat("Forward", 2f, 5f, 2f);
        }

        public void doForwardSpeed()
        {
            m_Animator.SetBool("OnGround", true);
            m_Animator.SetFloat("Forward", 5f, 5f, 2f);
        }

        #endregion
    }
}
