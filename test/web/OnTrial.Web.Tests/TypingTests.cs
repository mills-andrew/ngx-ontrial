using OnTrial.MSTest;
using OnTrial.MSTest.Web;

namespace OnTrial.Web.Tests
{
    [TestSuite]
    [Browser(BrowserType.Edge)]
    public class TypingTests : DefaultWebTestBase
    {
        [TestCase]
        public void ShouldFireKeyPressEvents() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldFireKeyDownEvents() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldFireKeyUpEvents() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldTypeLowerCaseLetters() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToTypeCapitalLetters() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToTypeQuoteMarks() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToTypeTheAtCharacter() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToMixUpperAndLowerCaseLetters() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ArrowKeysShouldNotBePrintable() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToUseArrowKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void WillSimulateAKeyUpWhenEnteringTextIntoInputElements() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void WillSimulateAKeyDownWhenEnteringTextIntoInputElements() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void WillSimulateAKeyPressWhenEnteringTextIntoInputElements() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void WillSimulateAKeyUpWhenEnteringTextIntoTextAreas() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void WillSimulateAKeyDownWhenEnteringTextIntoTextAreas() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void WillSimulateAKeyPressWhenEnteringTextIntoTextAreas() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldFireFocusKeyEventsInTheRightOrder() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldReportKeyCodeOfArrowKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldReportKeyCodeOfArrowKeysUpDownEvents() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void NumericNonShiftKeys() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void NumericShiftKeys() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void LowerCaseAlphaKeys() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void UppercaseAlphaKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void AllPrintableKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ArrowKeysAndPageUpAndDown() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void HomeAndEndAndPageUpAndPageDownKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void DeleteAndBackspaceKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void SpecialSpaceKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void NumberpadKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void FunctionKeys() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShiftSelectionDeletes() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ChordControlHomeShiftEndDelete() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ChordReveseShiftHomeSelectionDeletes() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ChordControlCutAndPaste() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void ShouldTypeIntoInputElementsThatHaveNoTypeAttribute() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldNotTypeIntoElementsThatPreventKeyDownEvents() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void GenerateKeyPressEventEvenWhenElementPreventsDefault() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void ShouldBeAbleToTypeOnAnEmailInputField() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void ShouldBeAbleToTypeOnANumberInputField() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void ShouldThrowIllegalArgumentException() => Assert.Inconclusive("Testcase not complete."); 
       
        [TestCase]
        public void CanSafelyTypeOnElementThatIsRemovedFromTheDomOnKeyPress() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void CanClearNumberInputAfterTypingInvalidInput() => Assert.Inconclusive("Testcase not complete."); 
        
        [TestCase]
        public void TypingIntoAnIFrameWithContentEditableOrDesignModeSet() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void NonPrintableCharactersShouldWorkWithContentEditableOrDesignModeSet() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToTypeIntoEmptyContentEditableElement() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToTypeIntoContentEditableElementWithExistingValue() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void ShouldBeAbleToTypeIntoTinyMCE() => Assert.Inconclusive("Testcase not complete."); 
    }
}
