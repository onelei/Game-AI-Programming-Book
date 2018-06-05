/*
 * Decorator node.
 */

using System.Collections.Generic;
namespace lemon_bt_CShape
{
    public class Bt_Decorator : Bt_Node
    {
        private Bt_Node child;
        public Bt_Decorator()
        {
            child = null;
        }

        protected void setChild(Bt_Node node)
        {
            this.child = node;
        }
    }

}

