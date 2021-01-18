using System;
using System.Drawing;
using System.Linq;

namespace OnTrial.Utilities
{
    public static class RandomUtils
    {
        private const int _mBig = Int32.MaxValue;
        private const int _mSeed = 161803398;
        private const int _mz = 0;

        private static int inext, inextp;
        private static int[] _seedArray = new int[56];

        static RandomUtils()
        {
            int ii, mj, mk;
            var seed = Environment.TickCount;

            //Initialize our Seed array.
            //This algorithm comes from Numerical Recipes in C (2nd Ed.)
            int subtraction = (seed == Int32.MinValue) ? Int32.MaxValue : Math.Abs(seed);
            mj = _mSeed - subtraction;
            _seedArray[55] = mj;
            mk = 1;

            for (int i = 1; i < 55; i++)
            {
                //Apparently the range [1..55] is special (Knuth) and so we're wasting the 0'th position.
                ii = (21 * i) % 55;
                _seedArray[ii] = mk;
                mk = mj - mk;
                if (mk < 0) mk += _mBig;
                mj = _seedArray[ii];
            }

            for (int k = 1; k < 5; k++)
            {
                for (int i = 1; i < 56; i++)
                {
                    _seedArray[i] -= _seedArray[1 + (i + 30) % 55];
                    if (_seedArray[i] < 0) _seedArray[i] += _mBig;
                }
            }

            inext = 0;
            inextp = 21;
            seed = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int Sample()
        {
            int retVal;
            int locINext = inext;
            int locINextp = inextp;

            if (++locINext >= 56) locINext = 1;
            if (++locINextp >= 56) locINextp = 1;

            retVal = _seedArray[locINext] - _seedArray[locINextp];

            if (retVal == _mBig) retVal--;
            if (retVal < 0) retVal += _mBig;

            _seedArray[locINext] = retVal;

            inext = locINext;
            inextp = locINextp;

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool Bool() => Sample() % 2 == 0;

        public static int Int() => Sample();

        public static int Int(int pMaxValue)
        {
            if (pMaxValue <= 0)
                throw new ArgumentOutOfRangeException("maxValue", "maxValue cannot be less than or equal to 0.");
            return (int)(Sample() * (1.0 / _mBig) * pMaxValue);
        }

        public static int Int(int pMinValue, int pMaxValue)
        {
            if (pMinValue > pMaxValue)
                throw new ArgumentOutOfRangeException("minValue", "minValue cannot be greater than maxValue.");

            long? range = (long)pMaxValue - pMinValue;
            if (range <= (long)Int32.MaxValue)
                return ((int)(Sample() * (1.0 / _mBig) * range) + pMinValue);
            else
            {
                var result = Sample();
                var sample = RandomUtils.Bool() ? result : -result;
                double d = result;
                d += (Int32.MaxValue - 1);
                d /= 2 * (uint)Int32.MaxValue - 1;
                return (int)((long)(d * range) + pMinValue);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBuffer"></param>
        /// <param name="pMinValue"></param>
        /// <param name="pMaxValue"></param>
        /// <returns></returns>
        public static byte[] Bytes(int pSize)
        {
            if (pSize == 0)
                throw new ArgumentNullException("pSize", "Buffer Size cannot be 0");

            byte[] buffer = new byte[pSize];

            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)(Sample() % (Byte.MaxValue + 1));

            return buffer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSize"></param>
        /// <param name="pMinValue"></param>
        /// <param name="pMaxValue"></param>
        /// <returns></returns>
        public static byte[] Bytes(int pSize, int pMinValue, int pMaxValue)
        {
            if (pSize == 0)
                throw new ArgumentNullException("pSize", "Buffer Size cannot be 0");
            else if (pMinValue == 0 && pMaxValue == 0)
                throw new ArgumentOutOfRangeException("pSize", "Buffer Size min and max parameters cannot equal 0");
            else if (pMinValue > pMaxValue)
                throw new ArgumentOutOfRangeException("pMinValue", "pMinValue cannot be greater than pMaxValue.");

            byte[] buffer = new byte[pSize];

            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)RandomUtils.Int(pMinValue, pMaxValue);

            return buffer;
        }

        public static T Enum<T>(params T[] pExcludes) =>
            System.Enum.GetValues(typeof(T)).Cast<T>().Except(pExcludes).OrderBy(x => RandomUtils.Int()).FirstOrDefault();

        public static Color Color() =>
            System.Drawing.Color.FromArgb(RandomUtils.Int(255), RandomUtils.Int(255), RandomUtils.Int(255));

        public static DateTime Date(DateTime pStartDate, DateTime pEndDate) =>
            pStartDate.AddDays(RandomUtils.Int((pEndDate - pStartDate).Days));

        public static string Guid() =>
            System.Guid.NewGuid().ToString();

    }
}
