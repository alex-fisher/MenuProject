using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using MenuProject.Services;
using System.Web;

namespace MenuProject.Tests.Services
{
    [TestClass]
    public class HttpFileProcessingServiceTest
    {
        class MemoryFile : HttpPostedFileBase
        {
            Stream stream;
            string contentType;
            string fileName;

            public MemoryFile(Stream stream, string contentType, string fileName)
            {
                this.stream = stream;
                this.contentType = contentType;
                this.fileName = fileName;
            }

            public override int ContentLength
            {
                get { return (int)stream.Length; }
            }

            public override string ContentType
            {
                get { return contentType; }
            }

            public override string FileName
            {
                get { return fileName; }
            }

            public override Stream InputStream
            {
                get { return stream; }
            }

        }

        [TestMethod]
        public void save_FileCreated()
        {
            string json = "";
            using (StreamReader sr = new StreamReader(@"Resources\test.json"))
            {
                json = sr.ReadToEnd();
            }

            string destination = @"\menufiles\";
            HttpPostedFileBase file = new MemoryFile(ToStream(json), "", "test.json");
            HttpFileProcessingService.save(file, destination);

            string contents;
            using (StreamReader sr = new StreamReader(destination + "test.json"))
            {
                contents = sr.ReadToEnd();
            }
            Assert.IsNotNull(contents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void save_IOExcption_InvalidDestination()
        {
            string json = "";
            using (StreamReader sr = new StreamReader(@"Resources\test.json"))
            {
                json = sr.ReadToEnd();
            }

            HttpPostedFileBase file = new MemoryFile(ToStream(json), "", "test.json");
            HttpFileProcessingService.save(file, "/</");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void save_ArgumentException_InvalidDestination_null()
        {
            string json = "";
            using (StreamReader sr = new StreamReader(@"Resources\test.json"))
            {
                json = sr.ReadToEnd();
            }

            HttpPostedFileBase file = new MemoryFile(ToStream(json), "", "test.json");
            HttpFileProcessingService.save(file, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void save_ArgumentException_InvalidDestination_blank()
        {
            string json = "";
            using (StreamReader sr = new StreamReader(@"Resources\test.json"))
            {
                json = sr.ReadToEnd();
            }

            HttpPostedFileBase file = new MemoryFile(ToStream(json), "", "test.json");
            HttpFileProcessingService.save(file, "");
        }

        public static Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
