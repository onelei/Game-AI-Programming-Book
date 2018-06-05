/*
 * Parallel Node
 * 并发执行它的所有Child Node.
 * 而向Parent Node返回的值和Parallel Node所采取的具体策略相关;
 * Parallel Selector Node:一False则返回False,全True才返回True.
 */

using System.Collections.Generic;
namespace lemon_bt_CShape
{
    public class Bt_ParallelSelector : Bt_Parallel
    {
        private List<Bt_Node> m_pWaitNodes;
        private bool m_pIsFail;
        public Bt_ParallelSelector()
        {
            m_pWaitNodes = new List<Bt_Node>();
            m_pIsFail = false;
        }

        public override Bt_Result doAction()
        {
            if (this.children == null || this.children.Count == 0)
            {
                return Bt_Result.SUCCESSFUL;
            }

            Bt_Result _result = Bt_Result.NONE;
            List<Bt_Node> _waitNodes = new List<Bt_Node>();
            List<Bt_Node> _mainNodes = new List<Bt_Node>();
            _mainNodes = this.m_pWaitNodes.Count > 0 ? this.m_pWaitNodes : this.children;
            for (int i = 0, length = _mainNodes.Count; i < length; ++i)
            {
                _result = _mainNodes[i].doAction();
                switch (_result)
                {
                    case Bt_Result.SUCCESSFUL:
                        break;
                    case Bt_Result.RUNING:
                        _waitNodes.Add(_mainNodes[i]);
                        break;
                    default:
                        m_pIsFail = true;
                        break;
                }
            }

            // 存在等待节点就返回等待;
            if (_waitNodes.Count > 0)
            {
                this.m_pWaitNodes = _waitNodes;
                return Bt_Result.RUNING;
            }

            // 检查返回结果;
            _result = checkResult();
            reset();
            return _result;
        }

        private Bt_Result checkResult()
        {
            return m_pIsFail ? Bt_Result.FAIL : Bt_Result.SUCCESSFUL;
        }

        private void reset()
        {
            this.m_pWaitNodes.Clear();
            this.m_pIsFail = false;
        }
    }
}


