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
    public class HFSMShop : HFSMBase
    {
        public HFSMShop(Animator animator,Text text)
            : base(animator, text)
        {

        }

        private float shopTime = 0;
         
        /// <summary>
        /// 进入状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(Place _state)
        {
            shopTime = 0;

            Debug.LogWarning("进入超市");
            SetText("进入超市");
        }

        /// <summary>
        /// 退出状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnExitState(Place _state)
        {
            shopTime = 0;
;
            Debug.LogWarning("离开超市");
            SetText("离开超市");
            doShop();
        }

        /// <summary>
        /// 更新状态;
        /// </summary>
        public override void OnUpdateState()
        {
            shopTime += Time.deltaTime;
             if (shopTime > 3)
            {
                doPay();
            } else if (shopTime > 2)
            {
                doSelectFood();
            }
            
        }

        private void doSelectFood()
        {
            Debug.Log("买什么呢,这个不错,那个也不错~~~");
            SetText("买什么呢,这个不错,那个也不错~~~");

        }

        private void doPay()
        {
            Debug.Log("买买买,钱包快没钱啦~~~");
            SetText("买买买,钱包快没钱啦~~~");
        }
         
    }
}
