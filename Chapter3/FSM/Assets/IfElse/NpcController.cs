using UnityEngine;

public class NpcController : MonoBehaviour {

    [SerializeField]Animator m_Animator;

    bool bForwarding = false;
    bool bCrouching = false;

	// Update is called once per frame
    void Update()
    {
        // 按下右箭头;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bForwarding = true;

            // 如果此时处在下蹲动作；
            if (bCrouching)
            {
                //停止下蹲动作；
                bCrouching = false;
                doCrouch(false);
            }
            //执行向右走动作;
            doForward();
        }
        // 按下向下箭头;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bCrouching = true;

            // 如果此时处在前进过程中；
            if (bForwarding)
            {
                // 停止前进；
                bForwarding = false;
                stopForward();
            }
            //执行下蹲动作;
            doCrouch(true);
        }
        // 按下向上箭头;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //执行向上跳动作;
            doJump();
        }
	}

    void stopForward()
    {
        m_Animator.SetFloat("Forward", 0f, 0f, 0f);
    }
    void doForward()
    {
        m_Animator.SetBool("OnGround", true);
        m_Animator.SetFloat("Forward", 5f, 5f, 2f);
    }

    void doTurn()
    {
        m_Animator.SetBool("OnGround", true);
        m_Animator.SetFloat("Turn", 5f, 5f, Time.deltaTime);
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
        m_Animator.SetBool("OnGround", true);
        doForward();
    }
}
