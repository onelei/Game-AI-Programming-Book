/********************************************************************************
** auth： Onelei
** date： 2017/7/4 13:58:20
** desc： 状态机模板
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;

public class StateMachine<T> :UIBase
{
	/// <summary>
	/// 当前的状态时间;
	/// </summary>
    protected float stateStartTime;
	public float mStateTime
	{
		get{return Time.time - stateStartTime;}
	}

    /// <summary>
    /// 上一个状态;
    /// </summary>
	public T mPreState;
    /// <summary>
    /// 当前状态;
    /// </summary>
    private T _curState;
	public T mCurState
	{
		get
		{
			return _curState;
		}
		set
		{
            Debug.LogWarning("pre    "+mPreState);
            OnExitState(mPreState);
			mPreState = _curState;
			_curState = value;
			stateStartTime = Time.time;
            Debug.LogWarning("cur    " + _curState);
            OnEnterState(_curState);
		}
	}
    /// <summary>
    /// 进入状态;
    /// </summary>
    /// <param name="_state"></param>
	protected virtual void OnEnterState(T _state)
	{
		
	}
    /// <summary>
    /// 退出状态;
    /// </summary>
    /// <param name="_state"></param>
    protected virtual void OnExitState(T _state)
	{

	}
    /// <summary>
    /// 开始函数;
    /// </summary>
    protected override void OnStart()
    {

    } 
    /// <summary>
    /// 更新状态;
    /// </summary>
	public override void OnUpdateState()
	{

	}
     
}
/// <summary>
/// 状态枚举;
/// </summary>
public enum UBState
{
	NONE,
	INIT,
	Enter,
	Exit
}
/// <summary>
/// 界面基类;
/// </summary>
public abstract class UIBase : MonoBehaviour 
{
     
    void Start()
    {
        OnStart();
    }

    void Update()
    {
        OnUpdateState();
    }

    protected virtual void OnStart()
    {

    }
    public virtual void OnUpdateState()
    {

    }

}
