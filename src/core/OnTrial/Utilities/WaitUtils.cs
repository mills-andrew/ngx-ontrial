using System;
using System.Threading;

namespace OnTrial.Utilities
{
    public static class WaitUtils
    {
        public static T Wait<T>(Func<T> pCondition, TimeSpan? pTimeout = null, TimeSpan? pSleepInterval = null)
        {
            T result = default(T);
            DateTime startTime = DateTime.Now;
            TimeSpan timeout = pTimeout ?? TimeSpan.FromSeconds(1);
            TimeSpan sleepInterval = pSleepInterval ?? TimeSpan.FromMilliseconds(100);

            while ((DateTime.Now - startTime).TotalSeconds < timeout.TotalSeconds)
            {
                try
                {
                    result = pCondition();
                    if (typeof(T) == typeof(bool))
                    {
                        if ((bool)(object)result)
                            return result;
                    }
                    else if (result != null)
                    {
                        return result;
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Operation timed out");
                }

                Thread.Sleep(sleepInterval);
            }

            return default(T);
        }
    }
}
