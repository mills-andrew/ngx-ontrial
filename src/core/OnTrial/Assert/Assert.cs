using OnTrial.IOC;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace OnTrial
{
    public class Assert
    {
        private static IAssert _validate => Framework.Provider?.GetService<IAssert>();

        #region Are(Not)Equal Validation(s)

        public static void AreEqual(object pExpected, object pActual) => _validate?.AreEqual(pExpected, pActual);

        public static void AreEqual(object pExpected, object pActual, string pMessage) => _validate?.AreEqual(pExpected, pActual, pMessage);

        public static void AreEqual(double pExpected, double pActual, double pDelta) => _validate?.AreEqual(pExpected, pActual, pDelta);
        public static void AreEqual(double pExpected, double pActual, double pDelta, string pMessage) => _validate?.AreEqual(pExpected, pActual, pDelta, pMessage);

        public static void AreEqual<T>(T pExpected, T pActual) => _validate?.AreEqual(pExpected, pActual);
        public static void AreEqual<T>(T pExpected, T pActual, string pMessage) => _validate?.AreEqual(pExpected, pActual, pMessage);

        public static void AreNotEqual(object pExpected, object pActual) => _validate?.AreNotEqual(pExpected, pActual);
        public static void AreNotEqual(object pExpected, object pActual, string pMessage) => _validate?.AreNotEqual(pExpected, pActual, pMessage);

        public static void AreNotEqual<T>(T pExpected, T pActual) => _validate?.AreNotEqual(pExpected, pActual);
        public static void AreNotEqual<T>(T pExpected, T pActual, string pMessage) => _validate?.AreNotEqual(pExpected, pActual, pMessage);

        #endregion

        #region IsFalse Validation(s)

        public static void IsFalse(bool pCondition) => _validate?.IsFalse(pCondition);
        public static void IsFalse(bool pCondition, string pMessage) => _validate?.IsFalse(pCondition, pMessage);
        public static void IsFalse(bool pCondition, string pMessage, params object[] pParameters) => _validate?.IsFalse(pCondition, pMessage, pParameters);

        #endregion

        #region IsTrue Validation(s)

        public static void IsTrue(bool pCondition) => _validate.IsTrue(pCondition);
        public static void IsTrue(bool pCondition, string pMessage) => _validate?.IsTrue(pCondition, pMessage);
        public static void IsTrue(bool pCondition, string pMessage, params object[] pParameters) => _validate?.IsTrue(pCondition, pMessage, pParameters);

        #endregion

        #region Is(Not)Null Validation(s)

        public static void IsNull(object pValue) => _validate?.IsNull(pValue);
        public static void IsNull(object pValue, string pMessage) => _validate?.IsNull(pValue, pMessage);

        public static void IsNotNull(object pValue) => _validate?.IsNotNull(pValue);
        public static void IsNotNull(object pValue, string pMessage) => _validate?.IsNotNull(pValue, pMessage);

        #endregion

        #region IsInstanceOfType Validation(s)

        public static void IsInstanceOfType(object pValue, Type pExpectedType) => _validate?.IsInstanceOfType(pValue, pExpectedType);
        public static void IsInstanceOfType(object pValue, Type pExpectedType, string pMessage) => _validate?.IsInstanceOfType(pValue, pExpectedType, pMessage);

        #endregion

        #region Fail/Warning Method(s)

        public static void Fail(string pMessage) => _validate?.Fail(pMessage);
        public static void Fail(string pMessage, params object[] pParameters) => _validate?.Fail(pMessage, pParameters);
        public static void Inconclusive(string pMessage) => _validate?.Inconclusive(pMessage);

        #endregion
    }
}