using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace OnTrial.Workflow
{
    public class WorkflowEventArgs : System.EventArgs
    {
        #region Public Properties

        public Exception Exception { get; }
        public IDictionary Properties { get; }
        public MemberInfo TestMethodMemberInfo { get; }
        public Type TestClassType { get; }
        public TestOutcome TestOutcome { get; }
        public string TestName { get; }
        public string TestClassName { get; }
        public string TestFullName { get; }
        public string ConsoleOutputMessage { get; }
        public string ConsoleOutputStackTrace { get; }
        public List<string> Categories { get; }
        public List<string> Authors { get; }
        public List<string> Descriptions { get; }

        #endregion

        #region Constructor(s)
        
        public WorkflowEventArgs(IDictionary pProperties, MemberInfo testMethodMemberInfo)
        {
            Properties = pProperties;
            TestMethodMemberInfo = testMethodMemberInfo;
        }

        public WorkflowEventArgs(IDictionary pProperties, MemberInfo testMethodMemberInfo, Type pTestClassType)
        {
            Properties = pProperties;
            TestMethodMemberInfo = testMethodMemberInfo;
            TestClassType = pTestClassType;
        }

        public WorkflowEventArgs(IDictionary pProperties, string pTestName, MemberInfo testMethodMemberInfo, Type pTestClassType)
        {
            Properties = pProperties;
            TestName = pTestName;
            TestMethodMemberInfo = testMethodMemberInfo;
            TestClassType = pTestClassType;
            TestName = TestMethodMemberInfo.Name;
            TestClassName = pTestClassType.FullName;
            TestFullName = $"{TestClassName}.{TestName}";
        }

        #endregion
    }
}
