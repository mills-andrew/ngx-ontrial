using System;

namespace OnTrial
{
    public interface IAssert
    {
        #region Are(Not)Equal Validation(s)

        void AreEqual(object pExpected, object pActual);
        void AreEqual(object pExpected, object pActual, string pMessage);

        void AreEqual(double pExpected, double pActual, double pDelta);
        void AreEqual(double pExpected, double pActual, double pDelta, string pMessage);
        
        void AreEqual<T>(T pExpected, T pActual);
        void AreEqual<T>(T pExpected, T pActual, string pMessage);

        void AreNotEqual(object pExpected, object pActual);
        void AreNotEqual(object pExpected, object pActual, string pMessage);
        
        void AreNotEqual<T>(T pExpected, T pActual);
        void AreNotEqual<T>(T pExpected, T pActual, string pMessage);

        #endregion

        #region IsFalse Validation(s)

        void IsFalse(bool pCondition);
        void IsFalse(bool pCondition, string pMessage);
        void IsFalse(bool pCondition, string pMessage, params object[] pParameters);

        #endregion

        #region IsTrue Validation(s)

        void IsTrue(bool pCondition);
        void IsTrue(bool pCondition, string pMessage);
        void IsTrue(bool pCondition, string pMessage, params object[] pParameters);

        #endregion

        #region Is(Not)Null Validation(s)

        void IsNull(object pValue);
        void IsNull(object pValue, string pMessage);

        void IsNotNull(object pValue);
        void IsNotNull(object pValue, string pMessage);

        #endregion

        #region Fail Validation(s)

        void Fail(string pMessage);
        void Fail(string pMessage, params object[] pParameters);

        #endregion

        #region IsInstanceOfType Validation(s)

        void IsInstanceOfType(object pValue, Type pExpectedType);
        void IsInstanceOfType(object pValue, Type pExpectedType, string pMessage);

        #endregion

        #region Other Methods

        void Inconclusive(string pMessage);

        #endregion
    }
}
