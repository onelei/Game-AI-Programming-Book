/********************************************************************************
** auth： Onelei
** date： 2017/12/18 15:12:07
** desc： 状态A;
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;
using UnityEngine.UI;
namespace HFSM
{
    public class HFSMHome : HFSMBase
    {
        public HFSMHome(Animator animator,Text text)
            : base(animator, text)
        {

        }

        private float homeTime = 0;

        /// <summary>
        /// 进入状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(Place _state)
        {
            homeTime = 0;
            Debug.LogWarning("进入家");
            doHome();
            SetText("进入家");

        }

        /// <summary>
        /// 退出状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnExitState(Place _state)
        {
            homeTime = 0;
            Debug.LogWarning("离开家");
            SetText("离开家");
        }

        /// <summary>
        /// 更新状态;
        /// </summary>
        public override void OnUpdateState()
        {
            homeTime += Time.deltaTime;
            
            if (homeTime > 5)
            {
                doSleep();
            }else if(homeTime >3)
            {
                doWatchTV();
            }
            else if (homeTime > 2)
            {
                doReadBook();
            }
        }

        private void doWatchTV()
        {
            Debug.Log("看电视啦~~~");
            SetText("看电视啦~~~");

        }

        private void doReadBook()
        {
            Debug.Log("多看书多看报~~~");
            SetText("多看书多看报~~~");
        }

        private void doSleep()
        {
            Debug.Log("还是睡觉舒服~~~");
            SetText("还是睡觉舒服~~~");
        }
    }
}
