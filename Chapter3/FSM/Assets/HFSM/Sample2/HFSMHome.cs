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
    public class HFSMHome : HFSMBase
    {
        public enum HomeState
        {
            None,
            ReadBook,
            Cook,
        }

        private HomeState homeState;

        public HFSMHome(HFSMSample2 controller, Animator animator, Text text)
            : base(controller, animator, text)
        {

        }

        private float homeTime = 0;
        /// <summary>
        /// 进入状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(Place _state)
        {
            if (homeState == HomeState.None)
            {
                homeTime = 0;
            }
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
            if (homeState == HomeState.None)
            {
                homeTime = 0;
            }
            Debug.LogWarning("离开家");
            SetText("离开家"); 
        }

        /// <summary>
        /// 更新状态;
        /// </summary>
        public override void OnUpdateState()
        {
            homeTime += Time.deltaTime;
            switch (homeState)
            {
                case HomeState.None:
                    {
                        homeState = HomeState.ReadBook;
                    }
                    break;
                case HomeState.ReadBook:
                    {
                        if (homeTime > 3)
                        {
                            //读完书了，开始烧饭；
                            homeTime = 0;
                            homeState = HomeState.Cook;
                        }else if (homeTime > 1)
                        {
                            //烧饭之前先读书；
                            doReadBook();
                        }
                    }
                    break;
                case HomeState.Cook:
                    //开始烧饭；
                    if (!doCook())
                    {
                        if (homeTime > 2)
                        {
                            //添加一个去超市的状态；
                            controller.AddStateStack(HFSMBase.Place.Shop);
                            return;
                        }
                        SetText("没有盐了");
                    }
                    else
                    {
                        //材料齐全，开始烧饭；
                        SetText("正在烧饭");
                    }
                    break;
            }
        }

        private bool doCook()
        {
            Debug.Log("开始烧饭");
            SetText("开始烧饭");
            return HFSMBag.EnoughSalt();
        }

        private void doReadBook()
        {
            Debug.Log("西红柿炒蛋秘籍");
            SetText("西红柿炒蛋秘籍");
        }
         
    }
}
