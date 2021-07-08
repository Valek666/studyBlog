using System.Threading;
using Xunit;

namespace StudyBlogTests
{
    public class AuthTests
    {
        private readonly BasicSteps _basicSteps;

        public AuthTests()
        {
            _basicSteps = new BasicSteps();
        }

        private bool SeeForm()
        {
            return _basicSteps.IsElementFound("Введите данные для входа");
        }

        private void FillAuthForm(string email, string password)
        {
            _basicSteps.FillFormField("Email", email);
            _basicSteps.FillFormField("Password", password);
        }

        private void SubmitAuthForm()
        {
            _basicSteps.ClickButtonById("submit");
        }

        [Fact]
        public void AuthenticateTest()
        {
            _basicSteps.GoToLoginPage();
            Assert.True(SeeForm());
            FillAuthForm("admin@admin.com", "1qaz@WSX29");
            SubmitAuthForm();
            Thread.Sleep(1000);
            Assert.True(_basicSteps.IsElementFound("Список пользователей"));
        }
    }
}