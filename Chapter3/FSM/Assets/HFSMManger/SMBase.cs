/********************************************************************************
** auth： Onelei
** date： 2017/7/4 15:04:23
** desc： 状态基类;
** Ver.:  V1.0.0
*********************************************************************************/
namespace HFSM
{
    public class SMBase : StateMachine<HFSM_State> 
    {
        /// <summary>
        /// 设置状态；
        /// </summary>
        /// <param name="_state"></param>
        public void SetState(HFSM_State _state)
        {
            mCurState = _state;
        }
    }
}
