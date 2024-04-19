using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjetoWebCorreiros
{
    public class MyTestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            TestResult[] results = base.Execute(testMethod);

            foreach (TestResult result in results)
            {
                if (result.Outcome == UnitTestOutcome.Failed)
                {
                    string message = result.TestFailureException.Message;

                    using (StreamWriter sw = new StreamWriter(Hooks.Report, true))
                    {
                        sw.WriteLine($"<h4 style= 'color:red;'>{result.TestFailureException.Message}</h4>");
                        sw.WriteLine($"<h4 style= 'color:red;'>{result.TestFailureException.InnerException}</h4>");
                        sw.WriteLine($"<h4 style= 'color:red;'>{result.TestFailureException.StackTrace}</h4>");
                    }
                }
            }

            return results;
        }
    }
}