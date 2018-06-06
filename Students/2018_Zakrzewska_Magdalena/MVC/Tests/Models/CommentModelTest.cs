using Twitter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testyyyy.Tests.Helpers;

namespace testyyyy.Tests.Models
{
    [TestClass]
    public class CommentModelTest
    {
        [TestMethod]
        public void CommentMinLengthValidate()
        {
            var comment = new Comment {Content = "Cont"};
            var result = ModelValidHelper.Validate(comment);
            Assert.AreEqual("Comment content to short. Minimum length : 5.", result[0].ErrorMessage);
        }
        [TestMethod]
        public void CommentMaxValueValidate()
        {
            var comment = new Comment { Content = "dfsfdjfheskjgfhjsghrjghreghtrejkhygjkfdhgkfjdhgkjfhkjfdhgjdfkghdjfkghfdjkghsltuoriethjkfdgv.d,slkdfjewjfgrkghjlrkfgjdklsngkdslhglskdsjfsldgjlregrlkgjrlklkdfjtlrkejglre" };
            var result = ModelValidHelper.Validate(comment);
            Assert.AreEqual("Comment content to long. Maximum length : 160.", result[0].ErrorMessage);
        }
    }
}
