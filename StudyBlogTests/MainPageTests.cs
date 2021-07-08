using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace StudyBlogTests
{
    public class MainPageTests
    {
        private readonly BasicSteps _basicSteps;

        public MainPageTests()
        {
            _basicSteps = new BasicSteps();
        }

        [Fact]
        public void CheckMainPageTiile()
        {
            _basicSteps.GoToMainPage();
            Assert.True(_basicSteps.IsElementFound("Публикации пользователей"));
            Assert.True(_basicSteps.IsElementFound("Все записи"));
            
        }

        [Fact]
        public void LoginWrongModelDataReturnsErrorMessage()
        {
            _basicSteps.GoToLoginPage();
           _basicSteps.FillFormField("Email", "wrong@email.com");
           _basicSteps.FillFormField("Password", "wrongPassword");
           _basicSteps.ClickButtonById("submit");
           Assert.True(_basicSteps.IsElementFound("Неправильный логин или пароль"));
        }
        
        [Fact]
        public void LoginEmptyEmailModelDataReturnsErrorMessage()
        {
            _basicSteps.GoToLoginPage();
            _basicSteps.FillFormField("Email", string.Empty);
            _basicSteps.FillFormField("Password", "wrongPassword");
            _basicSteps.ClickButtonById("submit");
            Assert.True(_basicSteps.IsElementFound("Это поле обязательно"));
        }
    }
}