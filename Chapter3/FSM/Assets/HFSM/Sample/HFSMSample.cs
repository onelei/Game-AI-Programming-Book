using System.Collections;
using System.Collections.Generic;
using HFSM;
using UnityEngine;
using UnityEngine.UI;

public class HFSMSample : MonoBehaviour {
    [SerializeField] 
    private Animator mAnimator;
    [SerializeField]
    private Text Text_Talk;
    [SerializeField]
    private Button Button_Home;
    [SerializeField]
    private Button Button_Shop;
    [SerializeField]
    private Button Button_Company;

    private HFSMBase.Place currentState;
    private HFSMBase.Place beforeState;

    private Dictionary<HFSMBase.Place, HFSMBase> HFSMStateDic = new Dictionary<HFSMBase.Place, HFSMBase>();

    private bool bStart = false;

    void Awake()
    {
        Button_Home.onClick.AddListener(()=>
        {
            ChangeState(HFSMBase.Place.Home);
        });
        Button_Shop.onClick.AddListener(() =>
        {
            ChangeState(HFSMBase.Place.Shop);
        });
        Button_Company.onClick.AddListener(() =>
        {
            ChangeState(HFSMBase.Place.Company);
        });
    }

	// Use this for initialization
	void Start () {
	    HFSMStateDic.Clear();
        HFSMStateDic.Add(HFSMBase.Place.Home, new HFSMHome(mAnimator,Text_Talk));
        HFSMStateDic.Add(HFSMBase.Place.Shop, new HFSMShop(mAnimator, Text_Talk));
        HFSMStateDic.Add(HFSMBase.Place.Company, new HFSMCompany(mAnimator, Text_Talk));

	    // 设置当前在家里；
        ChangeState(HFSMBase.Place.Home);

	    bStart = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (bStart)
	    {
            // 更新当前状态的场景内部逻辑;
	        HFSMStateDic[currentState].OnUpdateState();
	    }
	}

    /// <summary>
    /// 切换状态；
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(HFSMBase.Place place)
    {
        beforeState = this.currentState;
        this.currentState = place;

        if (HFSMStateDic.ContainsKey(place))
        {
            HFSMStateDic[place].mCurState = place;
        }
    }
}
