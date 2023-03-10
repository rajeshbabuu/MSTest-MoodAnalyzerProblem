using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TestCases
{
    [TestClass]
    public class MoodTester
    {
        [TestMethod]
        public void TestHappyOrSad()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer("Happy"); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }
        [TestMethod]
        public void GivenSad_ReturnSad()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer("I am in Sad Mood"); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Sad".ToUpper(), result); //Assert
        }
        [TestMethod]
        public void GivenAny_ReturnHappy()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer("I am in Any Mood"); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }
        [TestMethod]
        public void GivenNull_ReturnHappy()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer(null); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }


        [TestMethod]
        public void CreateMoodAnalyzerObject_ParameterConstructor_UsingReflection()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer();

            var objFactory = MoodAnalyzerFactory.CreateInstance("MoodAnalyzerProblem.MoodAnalyzer");

            Assert.IsInstanceOfType(objMood, (Type)objFactory);
        }


        [TestMethod]
        public void ChangeMoodDynamically_GivenImproperField_ReturnException()
        {
            string expected = MoodAnalysisErrors.NO_SUCH_FIELD.ToString();
            string actual = MoodAnalyzerFactory.ChangeMoodDynamically("messageWrong", MoodAnalysisErrors.NO_SUCH_FIELD.ToString());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeMoodDynamically_GivenNull_ReturnNull()
        {
            string expected = MoodAnalysisErrors.Null.ToString();
            string actual = MoodAnalyzerFactory.ChangeMoodDynamically("message", null);
            Assert.AreEqual(expected, actual);
        }
    }
}