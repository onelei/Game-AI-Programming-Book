/**
 * 测试Running的返回结果;
 */
using System;
using lemon_bt_CShape;
class TestNodeRuning : Bt_Action
{
    public override Bt_Result doAction()
    {
        Bt_Result _result = Bt_Result.RUNING;
        string msg = "test node TestNodeRuning";
        Bt_Debug.Debug(_result, msg);
        return _result;
    }

}

