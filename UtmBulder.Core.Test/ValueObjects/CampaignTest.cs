using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBulder.Core.Test.ValueObjects
{
    [TestClass]
    public class CampaignTest
    {
        [TestMethod]
        [DataRow("", "", "", true)]
        [DataRow("source", "", "", true)]
        [DataRow("source", "medium", "", true)]
        [DataRow("", "medium", "", true)]
        [DataRow("", "", "name", true)]
        [DataRow("source", "medium", "name", false)]
        public void TestCampaign(
            string source,
            string medium,
            string name,
            bool expectException)
        {
            if(expectException)
            {
                try
                {
                    new Campaign(source, medium, name);
                    Assert.Fail();
                }
                catch (InvalidCampaignException)
                    //when(e.Message == "source é invalido")
                {

                    Assert.IsTrue(true);
                }
            }
            else
            {
                new Campaign(source, medium, name);
                Assert.IsTrue(true);
            }
        }
    }
}
