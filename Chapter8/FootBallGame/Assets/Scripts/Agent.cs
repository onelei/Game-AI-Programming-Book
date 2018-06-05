/*
 * Agent脚本;
 */
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace FootBallGame
{ 
	public class Agent : MonoBehaviour
	{
        /// <summary>
        /// NavMesh组件;
        /// </summary>
		[SerializeField] NavMeshAgent navMeshagent;
        /// <summary>
        /// 球;
        /// </summary>
		[SerializeField] Transform Ball;
        /// <summary>
        /// 球员编号Text;
        /// </summary>
		[SerializeField] TextMesh Text_Num;
        /// <summary>
        /// 球员编号;
        /// </summary>
		[SerializeField] int num;
        /// <summary>
        /// 球员的阵营;True表示是左方,False表示是右方;
        /// </summary>
		[SerializeField] bool bLeft;
        /// <summary>
        /// 获取阵营;
        /// </summary>
        /// <returns></returns>
		public bool GetTeamDirection ()
		{
			return this.bLeft;
		}
        /// <summary>
        /// 设置目的地;
        /// </summary>
        /// <param name="target"></param>
		public void SetDestination (Vector3 target)
		{
			navMeshagent.enabled = true;
			navMeshagent.SetDestination (target);
		}
        /// <summary>
        /// 获取球的位置;
        /// </summary>
        /// <returns></returns>
		public Vector3 GetBallLocation ()
		{
			return Ball.position;
		}
        /// <summary>
        /// 获取球的Transform;
        /// </summary>
        /// <returns></returns>
		public GameObject GetBall ()
		{
			return Ball.gameObject;
		}
        /// <summary>
        /// 获取自身的NavMesh组件;
        /// </summary>
        /// <returns></returns>
		public NavMeshAgent GetNavAgent ()
		{
			return this.navMeshagent;
		}
        /// <summary>
        /// 获取身上的编号;
        /// </summary>
        /// <returns></returns>
		public int GetNumber ()
		{
			return this.num;
		}
          
 
	}
}