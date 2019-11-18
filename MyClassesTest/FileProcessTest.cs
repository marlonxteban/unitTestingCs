using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\bad.text.name";
        private string _GoodFileName;

        #region Class Initialize and Cleanup

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In the Class Initialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }
        #endregion

        #region Test Initialize and Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File: " + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some text");
                }
            }
        }

        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExist")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting File: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion

        public TestContext TestContext { get; set; }

        [TestMethod]
        [Description("Check to see if a file does exists")]
        [Owner("Marlon")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            //TestContext.WriteLine("Creating the file: " + _GoodFileName);
            //File.AppendAllText(_GoodFileName, "Some text");
            TestContext.WriteLine("Testing the file: " + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            //TestContext.WriteLine("Deleting the file: " + _GoodFileName);
            //File.Delete(_GoodFileName);
            Assert.IsTrue(fromCall);
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Marlon")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
            TestContext.WriteLine("Checking file: " + fileName);

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(2000);
        }


        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File Does Exist");
        }

        [TestMethod]
        public void FileNameDoesExistSimpleMessageWithFormatting()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File '{0}' Does Exist", _GoodFileName);
        }

        [TestMethod]
        [Description("Check to see if a file does not exists")]
        [Owner("Marlon")]
        [Priority(0)]
        [TestCategory("NoException")]
        [Ignore()]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        [Owner("Esteban")]
        [ExpectedException(typeof(ArgumentNullException))]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [Owner("Esteban")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //The test is correct
                return;
            }
            Assert.Fail("Not throws argumentNullException");
        }
    }
}
