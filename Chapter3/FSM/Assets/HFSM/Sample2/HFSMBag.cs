namespace HFSM2
{
    public class HFSMBag
    {
        private static HFSMBag _instance;
        private static int Salt = 0;

        /// <summary>
        /// 有没有盐；
        /// </summary>
        /// <returns></returns>
        public static bool EnoughSalt()
        {
            return Salt > 0;
        }

        /// <summary>
        /// 设置盐的数量；
        /// </summary>
        /// <param name="salt"></param>
        public static void SetSalt(int salt)
        {
            Salt = salt;
        }
    }
}