using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core;
using UtmBuilder.Core.ValueObjects;

namespace UtmBulder.Core.Test.ValueObjects
{
    [TestClass]
    public class UtmTest
    {
        [TestMethod]
        public void Deve_retorna_uma_url_de_um_utm()
        {
            var url = new Url(address:"https://balta.io/");
            var campaign = new Campaign(
                source: "src", 
                medium: "med", 
                name: "nme",
                id: "id",
                term: "ter",
                content: "cont");

            var utm = new Utm(url, campaign);

            // resultado
            var result = @"https://balta.io/?utm_source=src&utm_medium=med&utm_campaign=nme&utm_id=id&utm_term=ter&utm_content=cont";
           

            Assert.AreEqual(result, utm.ToString());
        }
    }
}
