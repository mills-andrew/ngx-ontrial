using OnTrial.MSTest;
using OnTrial.MSTest.Desktop;
using System.Collections.Generic;

namespace OnTrial.Desktop.Tests
{
    [TestSuite]
    [App(@"Microsoft.WindowsCalculator_8wekyb3d8bbwe!App")]
    public class UnitTest1 : DesktopTests
    {
        #region Positive Test Case(s)

        [TestCase] 
        public void ValidateAddition() 
        {
            int equationInt = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 0;
            string equationStr = "1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 0";
            CalculatorApp calculator = new CalculatorApp(mAgent);
            calculator.Equate(equationStr);
            Assert.AreEqual(equationInt.ToString(), calculator.Results());
        }

        [TestCase]
        public void ValidateSubtraction()
        {
            int equationInt = 1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 - 0;
            string equationStr = "1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 - 0";
            CalculatorApp calculator = new CalculatorApp(mAgent);
            calculator.Equate(equationStr);
            Assert.AreEqual(equationInt.ToString(), calculator.Results());
        }

        [TestCase]
        public void ValidateDivision()
        {
            int equationInt = 1 / 2 / 3 / 4 / 5 / 6 / 7 / 8 / 9;
            string equationStr = "1 / 2 / 3 / 4 / 5 / 6 / 7 / 8 / 9";
            CalculatorApp calculator = new CalculatorApp(mAgent);
            calculator.Equate(equationStr);
            Assert.AreEqual(equationInt.ToString(), calculator.Results());
        }

        [TestCase]
        public void ValidateMultiplication()
        {
            int equationInt = 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9;
            string equationStr = "1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9";
            CalculatorApp calculator = new CalculatorApp(mAgent);
            calculator.Equate(equationStr);
            Assert.AreEqual(equationInt.ToString(), calculator.Results());
        }

        #endregion

        #region Negitive Test Case(s)

        [TestCase]
        public void ValidateDividByZeroDoesntThrowException ()
        {
            string equationStr = "1 / 0";
            CalculatorApp calculator = new CalculatorApp(mAgent);
            calculator.Equate(equationStr);
            Assert.AreEqual("Cannot divide by zero", calculator.Results());
        }

        #endregion
    }

    public class CalculatorApp
    {
        public IDesktopElement Button_One => mAgent.FindElement(DesktopLocator.Name, "One");
        public IDesktopElement Button_Two => mAgent.FindElement(DesktopLocator.Name, "Two");
        public IDesktopElement Button_Three => mAgent.FindElement(DesktopLocator.Name, "Three");
        public IDesktopElement Button_Four => mAgent.FindElement(DesktopLocator.Name, "Four");
        public IDesktopElement Button_Five => mAgent.FindElement(DesktopLocator.Name, "Five");
        public IDesktopElement Button_Six => mAgent.FindElement(DesktopLocator.Name, "Six");
        public IDesktopElement Button_Seven => mAgent.FindElement(DesktopLocator.Name, "Seven");
        public IDesktopElement Button_Eight => mAgent.FindElement(DesktopLocator.Name, "Eight");
        public IDesktopElement Button_Nine => mAgent.FindElement(DesktopLocator.Name, "Nine");
        public IDesktopElement Button_Zero => mAgent.FindElement(DesktopLocator.Name, "Zero");
               
        public IDesktopElement Button_DivideBy => mAgent.FindElement(DesktopLocator.Name, "Divide by");
        public IDesktopElement Button_MultiplyBy => mAgent.FindElement(DesktopLocator.Name, "Multiply by");
        public IDesktopElement Button_Minus => mAgent.FindElement(DesktopLocator.Name, "Minus");
        public IDesktopElement Button_Plus => mAgent.FindElement(DesktopLocator.Name, "Plus");
        public IDesktopElement Button_Equals => mAgent.FindElement(DesktopLocator.Name, "Equals");
               
        public IDesktopElement CalculatorResults => mAgent.FindElement(DesktopLocator.AccessibilityId, "CalculatorResults");
        public IDesktopElement Button_Clear => mAgent.FindElement(DesktopLocator.Name, "Clear");

        Dictionary<char, IDesktopElement> buttons;

        protected IDesktopAgent mAgent;
        public CalculatorApp(IDesktopAgent pAgent)
        {
            this.mAgent = pAgent;
            buttons = new Dictionary<char, IDesktopElement>()
            {
                { '1', Button_One },
                { '2', Button_Two },
                { '3', Button_Three },
                { '4', Button_Four },
                { '5', Button_Five },
                { '6', Button_Six },
                { '7', Button_Seven },
                { '8', Button_Eight },
                { '9', Button_Nine },
                { '0', Button_Zero },

                { '/', Button_DivideBy },
                { '*', Button_MultiplyBy },
                { '-', Button_Minus },
                { '+', Button_Plus },
                { '=', Button_Equals },
            };
        }

        public void Equate(string pEquation)
        {
            char[] characters = pEquation.RemoveWhitespace().ToCharArray();
            for(int x=0; x<characters.Length; x++)
            {
                buttons[characters[x]].Click();
            }
            Button_Equals.Click();
        }

        public string Results()
        {
            return CalculatorResults.Text.Replace("Display is ", string.Empty).Trim();
        }
    }
}
