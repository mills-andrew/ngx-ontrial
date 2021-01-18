using System;
using MSAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace OnTrial.MSTest
{
    public class MSTestAssert : IAssert
    {
        public void AreEqual(object pExpected, object pActual) => MSAssert.AreEqual(pExpected, pActual);
        public void AreEqual(object pExpected, object pActual, string pMessage) => MSAssert.AreEqual(pExpected, pActual, pMessage);
        public void AreEqual(double pExpected, double pActual, double pDelta) => MSAssert.AreEqual(pExpected, pActual, pDelta);
        public void AreEqual(double pExpected, double pActual, double pDelta, string pMessage) => MSAssert.AreEqual(pExpected, pActual, pDelta, pMessage);
        public void AreEqual<T>(T pExpected, T pActual) => MSAssert.AreEqual(pExpected, pActual);
        public void AreEqual<T>(T pExpected, T pActual, string pMessage) => MSAssert.AreEqual(pExpected, pActual, pMessage);

        public void AreNotEqual(object pExpected, object pActual) => MSAssert.AreNotEqual(pExpected, pActual);
        public void AreNotEqual(object pExpected, object pActual, string pMessage) => MSAssert.AreNotEqual(pExpected, pActual, pMessage);
        public void AreNotEqual<T>(T pExpected, T pActual) => MSAssert.AreNotEqual(pExpected, pActual);
        public void AreNotEqual<T>(T pExpected, T pActual, string pMessage) => MSAssert.AreNotEqual(pExpected, pActual, pMessage);

        public void Fail(string pMessage) => MSAssert.Fail(pMessage);
        public void Fail(string pMessage, params object[] pParameters) => MSAssert.Fail(pMessage, pParameters);

        public void Inconclusive(string pMessage) => MSAssert.Inconclusive(pMessage);

        public void IsFalse(bool pCondition) => MSAssert.IsFalse(pCondition);
        public void IsFalse(bool pCondition, string pMessage) => MSAssert.IsFalse(pCondition, pMessage);
        public void IsFalse(bool pCondition, string pMessage, params object[] pParameters) => MSAssert.IsFalse(pCondition, pMessage);

        public void IsInstanceOfType(object pValue, Type pExpectedType) => MSAssert.IsInstanceOfType(pValue, pExpectedType);
        public void IsInstanceOfType(object pValue, Type pExpectedType, string pMessage) => MSAssert.IsInstanceOfType(pValue, pExpectedType, pMessage);

        public void IsNotNull(object pValue) => MSAssert.IsNotNull(pValue);
        public void IsNotNull(object pValue, string pMessage) => MSAssert.IsNotNull(pValue, pMessage);

        public void IsNull(object pValue) => Assert.IsNull(pValue);
        public void IsNull(object pValue, string pMessage) => MSAssert.IsNull(pValue, pMessage);
        
        public void IsTrue(bool pCondition) => MSAssert.IsTrue(pCondition);
        public void IsTrue(bool pCondition, string pMessage) => MSAssert.IsTrue(pCondition, pMessage);
        public void IsTrue(bool pCondition, string pMessage, params object[] pParameters) => MSAssert.IsTrue(pCondition, pMessage, pParameters);
    }
}
