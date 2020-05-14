using System;
using TechTalk.SpecFlow;
using AutomationProjectTestFramework.lib;
using NUnit.Framework;

namespace AutomationProjectTestFramework.BDD.SteppingFunctions
{

    [Binding]
    public class RegistrationTestSteps
    {
        private AutomatedProjectWebsite _automation;

        [Given(@"I have entered an invalid email address")]
        public void GivenIHaveEnteredAnInvalidEmailAddress()
        {
            _automation = new AutomatedProjectWebsite("chrome");
            _automation.AutomationProjectHome.VisitHomePage();
            _automation.AutomationProjectHome.ClickSignInLink();
            _automation.AutomationProjectRegister.InputEmail("InvalidEmail");
        }

        [When(@"I press create an account")]
        public void WhenIPressCreateAnAccount()
        {
            _automation.AutomationProjectRegister.CreateAccountClick();
        }

        [Then(@"the an invalid message should be displayed")]
        public void ThenTheAnInvalidMessageShouldBeDisplayed()
        {
            Assert.That(_automation.AutomationProjectRegister.EmailValidationFails,
                Is.EqualTo("Invalid email address."));
        }

    }
}
