using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OnTrial.MSTest
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestSuiteAttribute : TestClassAttribute
    {
        public string Title;
        public string Description;
    }
}
