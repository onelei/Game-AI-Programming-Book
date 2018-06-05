/*
 * 足球;
 */
using UnityEngine;
using UnityEngine.AI;

namespace FootBallGame
{
	public class Ball : MonoBehaviour
	{
        /// <summary>
        /// 物理刚体;
        /// </summary>
		[SerializeField] Rigidbody body;
        /// <summary>
        /// 射线;
        /// </summary>
		private RaycastHit hit = new RaycastHit(); 
        /// <summary>
        /// 添加一个力;
        /// </summary>
        /// <param name="form"></param>
        /// <param name="to"></param>
		public void AddForce(Vector3 form,Vector3 to)
		{ 
			Vector3 force = (to-form).normalized*Define.FORCE;
			body.AddForce (new Vector3(force.x,0,force.y), ForceMode.Impulse); 
		}
        /// <summary>
        /// 添加一个大点的力;
        /// </summary>
        /// <param name="form"></param>
        /// <param name="to"></param>
		public void AddForceBig(Vector3 form,Vector3 to)
		{ 
			Vector3 force = (to-form).normalized*Define.BIG_FORCE;
			body.AddForce (new Vector3(force.x,0,force.y), ForceMode.Impulse); 
		}
        /// <summary>
        /// 开始比赛前;
        /// </summary>
		public void BeforeKickOff()
		{
			transform.position = new Vector3(0,10000,0);
			body.velocity = Vector3.zero;
		}
        /// <summary>
        /// 重置;
        /// </summary>
		public void ReStart()
		{
			transform.position = Vector3.zero;
			body.velocity = Vector3.zero;
		}
        /// <summary>
        /// 系统更新函数;
        /// </summary>
		void Update()
		{  
            // 设置球的位置为鼠标点下的位置;
			if(Input.GetMouseButtonDown(0)){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(ray,out hit,100);
				if(null != hit.transform)
				{ 
                    // 设置球的位置;
					transform.position = new Vector3(hit.point.x,0,hit.point.z);
					// 设置球的速度0;
                    body.velocity = Vector3.zero;
					body.Sleep ();
				}
			}
		}
	}
}

