/********************************************************************************
** auth： Onelei
** date： 2017/12/18 15:12:07
** desc： 状态基类;
** Ver.:  V1.0.0
*********************************************************************************/

using UnityEngine.UI;
using UnityEngine;

namespace HFSM2
{
    public class HFSMBase : StateMachine<HFSMBase.Place>
    {
        public HFSMSample2 controller;
        public Animator m_Animator;
        public Text m_Text;

        public HFSMBase(HFSMSample2 controller, Animator animator, Text text)
        {
            this.controller = controller;
            m_Animator = animator;
            m_Text = text;
        }
        /// <summary>
        /// 状态；
        /// </summary>
        public enum Place
        {
            Home,//家；
            Shop,//超市;
            Company,//公司;   
        }

        /// <summary>
        /// 设置状态；
        /// </summary>
        /// <param name="_state"></param>
        public void SetState(Place _state)
        {
            mCurState = _state;
        }

        public void SetText(string text)
        {
            m_Text.text = text;
        }

        #region 动作 

        public void doHome()
        {
            m_Animator.SetBool("OnGround", true);
            m_Animator.SetFloat("Forward", 0f, 0f, 0f);
        }

        public void doShop()
        {
            m_Animator.SetBool("OnGround", true);
            m_Animator.SetFloat("Forward", 2f, 5f, 2f);
        }

        public void doCompany()
        {
            m_Animator.SetBool("OnGround", true);
            m_Animator.SetFloat("Forward", 5f, 5f, 2f);
        }

        #endregion
    }
}
