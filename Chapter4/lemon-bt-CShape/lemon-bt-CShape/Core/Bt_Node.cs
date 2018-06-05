﻿/*
 * Parent Node
 * 任何Node被执行后，必须向其Parent Node报告执行结果：成功 / 失败;
 * 这简单的成功 / 失败汇报原则被很巧妙地用于控制整棵树的决策方向;
 * =>Composite Node
 * =>Decorator Node
 * =>Condition Node
 * =>Action Node
 */

namespace lemon_bt_CShape
{
    public abstract class Bt_Node
    {
        /// <summary>
        /// do action;
        /// </summary>
        public virtual Bt_Result doAction()
        {
            return Bt_Result.NONE;
        }
    }
}


