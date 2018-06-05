/*
 * Parallel Node
 * 并发执行它的所有Child Node.
 * 而向Parent Node返回的值和Parallel Node所采取的具体策略相关;
 * Parallel Sequence Node:一True则返回True,全False才返回False.
 */

using System.Collections.Generic;
namespace lemon_bt_CShape
{
    public class Bt_ParallelSequence : Bt_Parallel
    {
        private List<Bt_Node> m_pWaitNodes;
        private bool m_pIsSuccess;
        public Bt_ParallelSequence()
        {
            m_pWaitNodes = new List<Bt_Node>();
            m_pIsSuccess = false;
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
                        this.m_pIsSuccess = true;
                        break;
                    case Bt_Result.RUNING:
                        _waitNodes.Add(_mainNodes[i]);
                        break;
                    default:
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
            return this.m_pIsSuccess ? Bt_Result.SUCCESSFUL : Bt_Result.FAIL;
        }

        private void reset()
        {
            this.m_pWaitNodes.Clear();
            this.m_pIsSuccess = false;
        }
    }

}
