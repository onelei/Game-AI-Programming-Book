/********************************************************************************
** auth： Onelei
** date： 2017/12/18 15:12:07
** desc： 状态A;
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace HFSM2
{
    public class HFSMCompany : HFSMBase
    {
        public HFSMCompany(HFSMSample2 controller, Animator animator, Text text)
            : base(controller, animator, text)
        {

        }

        private float workTime = 0;

        /// <summary>
        /// 进入状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(Place _state)
        {
            workTime = 0;
            Debug.LogWarning("进入公司");
            SetText("进入公司");
            doCompany();
        }

        /// <summary>
        /// 退出状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnExitState(Place _state)
        {
            workTime = 0;
            Debug.LogWarning("离开公司");
            SetText("离开公司");

        }

        /// <summary>
        /// 更新状态;
        /// </summary>
        public override void OnUpdateState()
        {
            workTime += Time.deltaTime;
            if (workTime > 3)
            {
                doWork();
            }else if (workTime > 2)
            {
                doSignIn();
            }
             
        }

        private void doSignIn()
        {
            Debug.Log("打卡上班了~~~");
            SetText("打卡上班了~~~");

        }

        private void doWork()
        {
            Debug.Log("工作!!!");
            SetText("工作!!!");

        } 
    }
}
