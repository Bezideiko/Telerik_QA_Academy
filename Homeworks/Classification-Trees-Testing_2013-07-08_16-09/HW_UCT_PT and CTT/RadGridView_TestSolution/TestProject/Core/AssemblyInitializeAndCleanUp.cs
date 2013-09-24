using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class AssemblyInitializeAndCleanUp
    {
        [AssemblyInitialize]
        public static void InitializeAssembly(TestContext context)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            TestController.CleanUpTest();
        }

        [AssemblyCleanup]
        public static void CleanUpAssembly()
        {
            TestController.CleanUpTest();
        }
    }
}