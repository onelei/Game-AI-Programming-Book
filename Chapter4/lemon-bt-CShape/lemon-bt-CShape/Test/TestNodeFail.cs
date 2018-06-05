/**
 * 测试Fail的返回结果;
 */
using System;
using lemon_bt_CShape;
class TestNodeFail : Bt_Action
{
    public override Bt_Result doAction()
    {
        Bt_Result _result = Bt_Result.FAIL;
        string msg = "test node TestNodeFail";
        Bt_Debug.Debug(_result, msg);
        return _result;
    }

}

