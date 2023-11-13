namespace BiliNetWork
{
    /// <summary>
    /// Av和BV转换器
    /// </summary>
    public interface IAvToBvConverter
    {
        /// <summary>
        /// Bv->Av
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        long Dec(string x);

        /// <summary>
        /// Av->Bv
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        string Enc(long x);
    }
}
