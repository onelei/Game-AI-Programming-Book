/**
 * 测试Success的返回结果;
 */
using System;
using lemon_bt_CShape;
class TestNodeSuccess : Bt_Action
{
    public override Bt_Result doAction()
    {
        Bt_Result _result = Bt_Result.SUCCESSFUL;
        string msg = "test node TestNodeSuccess";
        Bt_Debug.Debug(_result, msg);
        return _result;
    }

}

