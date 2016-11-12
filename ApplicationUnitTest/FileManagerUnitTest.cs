using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThingsThatIForgetWhenISneeze.Application;
using System.Diagnostics;
using Newtonsoft.Json;
using ThingsThatIForgetWhenISneeze.Application.Entities;

namespace ApplicationUnitTest
{
    [TestClass]
    public class FileManagerUnitTest
    {
        FileManager _fileManager = null;
        [TestInitialize]
        public void intializeFileManager()
        {
            _fileManager = new FileManager(AppDomain.CurrentDomain.BaseDirectory);
        }

        [TestMethod]
        public void Test_GetPathExpected_Method()
        {
            string fileName = "testFile";
            string fileExtension = "json";
            string assertedPath= string.Format(@"{0}\{1}.{2}", AppDomain.CurrentDomain.BaseDirectory, fileName, fileExtension, "", true);
            string filepath= _fileManager.GetPath(fileName,fileExtension);
            Trace.WriteLine(assertedPath);
            Trace.WriteLine(filepath);
            Assert.AreEqual(assertedPath, filepath);
        }
        [TestMethod]
        public void Test_NoExtension_Method()
        {
            string fileName = "testFile";
            string fileExtension = "";
            string filepath = _fileManager.GetPath(fileName, fileExtension);
            Assert.IsNull(filepath);
        }

        [TestMethod]
        public void Test_NoName_Method()
        {
            string fileName = "";
            string fileExtension = "json";
            string filepath = _fileManager.GetPath(fileName, fileExtension);
            Assert.IsNull(filepath);
        }
        [TestMethod]
        public void Test_ExtensionFormat_Method()
        {
            string fileName = "testFile";
            string fileExtension = ".json";
            string assertedPath = string.Format(@"{0}\{1}{2}", AppDomain.CurrentDomain.BaseDirectory, fileName, fileExtension);
            string filepath = _fileManager.GetPath(fileName, fileExtension,true);
            Trace.WriteLine(assertedPath);
            Trace.WriteLine(filepath);
            Assert.AreEqual(assertedPath, filepath);
        }
        [TestMethod]
        public void Test_FolderFormat_Method()
        {
            string fileName = "testFile";
            string fileExtension = "json";
            string folderName = "Tests";
            string assertedPath = string.Format(@"{0}\{1}\{2}.{3}", AppDomain.CurrentDomain.BaseDirectory,folderName, fileName, fileExtension);
            string filepath = _fileManager.GetPath(fileName, fileExtension, true, folderName);
            string secondPath = _fileManager.GetPath(fileName, fileExtension, true, string.Format("{0}{1}",folderName,@"\"));
            Trace.WriteLine(assertedPath);
            Trace.WriteLine("returned path=");
            Trace.WriteLine(filepath);
            Assert.AreEqual(assertedPath, filepath);
            Assert.AreEqual(filepath, secondPath);
        }
        [TestMethod]
        public void Test_FolderFormat_PushItFurder_Method()
        {
            string fileName = "testFile";
            string fileExtension = "json";
            string folderName = @"Tests\fakes\jasonfile\really\like\long\paths\";
            string assertedPath = string.Format(@"{0}\{1}{2}.{3}", AppDomain.CurrentDomain.BaseDirectory, folderName, fileName, fileExtension);
            string filepath = _fileManager.GetPath(fileName, fileExtension, true, folderName);
            string secondPath = _fileManager.GetPath(fileName, fileExtension, true, string.Format("{0}{1}", folderName, @"\"));
            Trace.WriteLine("Expected Path");
            Trace.WriteLine(assertedPath);
            Trace.WriteLine("First Path");
            Trace.WriteLine(filepath);
            Trace.WriteLine("Second Path");
            Trace.WriteLine(secondPath);

            Assert.AreEqual(assertedPath, filepath);
            Assert.AreEqual(filepath, secondPath);
        }
        [TestMethod]
        public void Test_ReadFileNotNull_Method()
        {
            string fileName = "testFile";
            string fileExtension = "json";
            string text = _fileManager.ReadFile(fileName, fileExtension);
            Trace.WriteLine(string.Format("text is: {0}",text));
            Assert.IsNotNull(text);
        }
        [TestMethod]
        public void Test_WriteReadFile_Expected_Method()
        {
            string fileName = "testFile";
            string fileExtension = "json";
            string folderName = "Tests";
            string inText = JsonConvert.SerializeObject(new BasicInfoEntity { Name = "John", Surname = "Connor" });
            _fileManager.WriteFile(fileName, fileExtension, inText, folderName);
            string outText = _fileManager.ReadFile(fileName, fileExtension, folderName);
            Trace.WriteLine(string.Format("intText is: {0}", inText));
            Trace.WriteLine(string.Format("outText is: {0}", outText));
            Assert.AreEqual(inText,outText);
        }
    }
}
