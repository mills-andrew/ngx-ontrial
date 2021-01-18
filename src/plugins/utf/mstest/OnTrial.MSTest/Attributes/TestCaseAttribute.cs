using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OnTrial.MSTest
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCaseAttribute : TestMethodAttribute
    {
        public int Id;
        public string Title;
        public string Description;
        public string[] Steps;
    }
}
