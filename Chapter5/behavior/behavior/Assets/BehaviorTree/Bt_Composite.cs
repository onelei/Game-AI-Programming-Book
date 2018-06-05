/*
 * Composite Node，其实它按复合性质还可以细分为3种：
 * =>Selector Node:一真则真,全假则假;
 * =>Sequence Node:一假则假,全真则真;
 * =>Parallel Node:并发执行;
 */

using System.Collections.Generic;
namespace lemon_bt_CShape
{
    public class Bt_Composite : Bt_Node
    {
        protected List<Bt_Node> children;
        public Bt_Composite()
        {
            children = new List<Bt_Node>();
        }

        public void addChild(Bt_Node node)
        {
            this.children.Add(node);
        }
    }
}


