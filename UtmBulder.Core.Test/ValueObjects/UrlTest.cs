using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBulder.Core.Test.ValueObjects
{
    [TestClass]
    public class UrlTest
    {

        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        public void Dado_uma_url_invalida_deve_retorna_uma_execao()
        {
            //try
            //{
            //    var url = new Url(address: "http//www.bnana?banana?cocoa&banaca");
            //    Assert.Fail();
            //}
            //catch (InvalidUrlException)
            //{

            //   Assert.IsTrue(true);
            //}

           new Url(address: "http//www.bnana?banana?cocoa&banaca");
        }

        [TestMethod]
        public void Dado_uma_url_valida_nao_deve_retorna_uma_execao()
        {
            new Url(address: "https://balta.io/");
            Assert.IsTrue(true);
        }
    }
}
