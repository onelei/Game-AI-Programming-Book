using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM2
{
    public class FSM2Sample : MonoBehaviour
    {
        [SerializeField] private Animator mAnimator;
        private FSM2Base.NPCState currentState;
        private FSM2Base.NPCState beforeState;

        private Dictionary<FSM2Base.NPCState, FSM2Base> FSMStateDic = new Dictionary<FSM2Base.NPCState, FSM2Base>();
        // Use this for initialization
        void Start()
        {  
            FSMStateDic.Clear();
            FSMStateDic.Add(FSM2Base.NPCState.Stand, new FSM2Stand(mAnimator));
            FSMStateDic.Add(FSM2Base.NPCState.Forward, new FSM2Forward(mAnimator));

            // 设置当前状态为站立；
            ChangeState(FSM2Base.NPCState.Stand);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("切换到前进状态");
                ChangeState(FSM2Base.NPCState.Forward);
            }
             
            foreach (var fsmState in FSMStateDic)
            {
                fsmState.Value.OnUpdateState();
            } 
        }
         
        /// <summary>
        /// 切换状态；
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(FSM2Base.NPCState state)
        {
            beforeState = this.currentState;
            this.currentState = state;

            if (FSMStateDic.ContainsKey(state))
            {
                FSMStateDic[state].mCurState = state;
            }
        }
    }

}

