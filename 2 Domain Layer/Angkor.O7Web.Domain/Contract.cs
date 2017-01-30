// Create by Felix A. Bueno

using System;

namespace Angkor.O7Web.Domain
{
    public abstract class Contract
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage) && ErrorCode != 0;
    }

    public class ResponseContract<T1> : Contract
    {
        public Tuple<T1> Response { get; private set; }
        public void SetResponse(T1 value)
        {
            Response = new Tuple<T1>(value);
        }        
    }

    public class ResponseContract<T1, T2> : Contract
    {
        public Tuple<T1, T2> Response { get; set; }

        public void SetResponse(T1 value1, T2 value2)
        {
            Response = new Tuple<T1, T2>(value1, value2);
        }
    }

    public class ResponseContract<T1, T2, T3> : Contract
    {
        public Tuple<T1, T2, T3> Response { get; set; }

        public void SetResponse(T1 value1, T2 value2, T3 value3)
        {
            Response = new Tuple<T1, T2, T3>(value1, value2, value3);
        }
    }

    public class ResponseContract<T1, T2, T3, T4> : Contract
    {
        public Tuple<T1, T2, T3, T4> Response { get; set; }
        public void SetResponse(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Response = new Tuple<T1, T2, T3, T4>(value1, value2, value3, value4);
        }
    }
}