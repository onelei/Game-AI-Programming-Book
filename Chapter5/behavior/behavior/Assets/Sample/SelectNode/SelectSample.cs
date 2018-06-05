/********************************************************************************
** auth： Onelei
** date： 2017/12/17 17:54:22
** desc： 描述
** Ver.:  V1.0.0
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lemon_bt_CShape;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

namespace Assets.Sample.SelectNode
{
    public class SelectSample :MonoBehaviour
    {
        public Animator animator;

        public Button Button_Start;

        private Bt_ParallelSelector parallelSelector;
        void Awake()
        {
            Button_Start.onClick.AddListener(OnClickStart);
        }

        void Start()
        {
            parallelSelector = new Bt_ParallelSelector();
            parallelSelector.addChild(new Run(animator));
            parallelSelector.addChild(new Idle(animator));
        }

        void OnClickStart()
        {
            var result = parallelSelector.doAction();
            LogHelper.Instance.Log("执行结果：" + result);
        }
    }
}
