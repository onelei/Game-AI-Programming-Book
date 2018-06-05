/*
 * 守门员的巡逻策略;
 */
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace FootBallGame
{
    public class PatrolGoalKeeper : Action
    {
        /// <summary>
        /// 球员脚本;
        /// </summary>
        private Agent agent;
        /// <summary>
        /// 巡逻点集合;
        /// </summary>
        private List<Vector3> PatrolPositions = new List<Vector3>();
        /// <summary>
        /// 巡逻点;
        /// </summary>
        private Vector3 PatrolPos;
        /// <summary>
        /// 球员位置;
        /// </summary>
        private Vector3 agentPosition;
        /// <summary>
        /// 足球的Transform;
        /// </summary>
        private Transform ballTransform;
        /// <summary>
        /// 巡逻点的索引值;
        /// </summary>
        private int range;

        public override void OnStart()
        {
            //获取球员组件;
            agent = GetComponent<Agent>();
            //获取足球的Transform;
            ballTransform = agent.GetBall().transform;
            //获取自身的位置;
            Vector3 InitPos = agent.transform.position;
            //设置巡逻点集合 
            PatrolPositions.Add(new Vector3(InitPos.x, InitPos.y, InitPos.z + Define.Patrol_Circle));
            PatrolPositions.Add(new Vector3(InitPos.x, InitPos.y, InitPos.z - Define.Patrol_Circle));

            //选取离自己最近的一个位置作为巡逻点;
            float distance = Mathf.Infinity;
            float localDistance;
            for (int i = 0; i < PatrolPositions.Count; ++i)
            {
                if ((localDistance = Vector3.Magnitude(agent.transform.position - PatrolPositions[i])) < distance)
                {
                    distance = localDistance;
                    range = i;
                }
            }
            //设置巡逻点;
            PatrolPos = PatrolPositions[range];
            agent.SetDestination(PatrolPos);

        }

        public override TaskStatus OnUpdate()
        {
            //如果球员移动到了巡逻点,就设置下一个巡逻点;
            agentPosition = agent.transform.position;
            if (Mathf.Abs(agentPosition.x - PatrolPos.x) < 1 && Mathf.Abs(agentPosition.z - PatrolPos.z) < 1)
            {
                range = (range + 1) % PatrolPositions.Count;
                PatrolPos = PatrolPositions[range];
                Debug.Log("巡逻点:"+PatrolPos);
            }
            //设置球员移动到巡逻点;
            agent.SetDestination(PatrolPos);
            //设置球员朝向球的位置;
            agent.transform.LookAt(ballTransform);
            return TaskStatus.Running;
        }

    }
} 
