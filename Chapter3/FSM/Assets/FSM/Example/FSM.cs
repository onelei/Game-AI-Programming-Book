using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour {
    [SerializeField]
    Animator m_Animator;

    public enum NPCState
    {
        Stand,//站立;
        Crouch,//下蹲;
        Forward,//向前;
        Jump,//跳跃
    }

    public NPCState mState;

	// Use this for initialization
	void Start () {
        mState = NPCState.Stand;
        //站立；
        doIdle();
	}

    private int forwardCount = 0;
    private int FROWARD_COUNT_SPEED = 1;
	
	// Update is called once per frame
	void Update () {
		switch(mState)
        {
            case NPCState.Stand:
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    mState = NPCState.Jump;
                    //执行向上跳动作;
                    doJump();
                }else if(Input.GetKeyDown(KeyCode.DownArrow))
                { 
                    mState = NPCState.Crouch;
                    //执行下蹲动作;
                    doCrouch(true);
                }else if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    mState = NPCState.Forward;
                    //执行向右走动作;
                    doForward();
                }
                break;
            case NPCState.Crouch:
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    mState = NPCState.Stand;
                    //站立；
                    doIdle();
                }
                break;
            case NPCState.Forward:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ++forwardCount;
                    if (forwardCount > FROWARD_COUNT_SPEED)
                    {
                        // 加速；
                        doForwardSpeed();
                    }
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    forwardCount = 0;
                    mState = NPCState.Stand;
                    //站立；
                    doIdle();
                }
                break;
            case NPCState.Jump:
                if(Input.GetKeyDown(KeyCode.DownArrow))
                { 
                    mState = NPCState.Stand;
                    //站立；
                    doIdle();
                }
                break;
        }
	}
     
    void doForward()
    {
        m_Animator.SetBool("OnGround", true);
        m_Animator.SetFloat("Forward", 2f, 5f, 2f);
    }

    void doForwardSpeed()
    {
        m_Animator.SetBool("OnGround", true);
        m_Animator.SetFloat("Forward", 5f, 5f, 2f);
    }
     

    void doCrouch(bool bCrouch)
    {
        m_Animator.SetBool("OnGround", true);
        m_Animator.SetBool("Crouch", bCrouch);
    }

    void doJump()
    {
        m_Animator.SetBool("OnGround", false);
        m_Animator.SetFloat("Jump", 0.5f);
    }

    void doIdle()
    {
        doCrouch(false);
        m_Animator.SetBool("OnGround", true);
        m_Animator.SetFloat("Forward", 0f, 0f, 0f);
    }
}
