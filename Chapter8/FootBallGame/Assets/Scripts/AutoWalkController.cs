/*
 * 自动寻路;
 * 
 */

using UnityEngine;
public class AutoWalkController : MonoBehaviour {
    /// <summary>
    /// 相机;
    /// </summary>
	[SerializeField] Camera m_Camera;
    /// <summary>
    /// Agent智能体;
    /// </summary>
	[SerializeField] UnityEngine.AI.NavMeshAgent agent;
    /// <summary>
    /// 射线;
    /// </summary>
	private RaycastHit hit = new RaycastHit();
 
	// Update is called once per frame
	void Update () {
        // 鼠标左键按下;
		if(Input.GetMouseButtonDown(0)){
			Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray,out hit,100);
			if(null != hit.transform)
			{
                //打印射线位置;
				print(hit.point);
                //设置Agent的目的地;
				agent.SetDestination (hit.point);
			}
		}
	}
}
