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
    public class HFSMShop : HFSMBase
    {
        public HFSMShop(HFSMSample2 controller, Animator animator, Text text)
            : base(controller, animator, text)
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
                //买好东西了，开始付钱；
                doPay();
                HFSMBag.SetSalt(5);
                controller.QuitState();
            }
            else if (shopTime > 2)
            {
                //开始买东西；
                doBuySalt();
            }
            
        }

        private void doBuySalt()
        {
            Debug.Log("买点盐");
            SetText("买点盐");
        }

        private void doPay()
        {
            Debug.Log("付完钱了");
            SetText("付完钱了");
        }
         
    }
}
