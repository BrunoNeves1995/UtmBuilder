using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBulder.Core.Test.ValueObjects
{
    [TestClass]
    public class UrlTest
    {
        private const string urlInvalida = "http//www.bnana?banana?cocoa&banaca";
        private const string urlValida = "https://balta.io/";

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

           new Url(address: urlInvalida);
        }

        [TestMethod]
        public void Dado_uma_url_valida_nao_deve_retorna_uma_execao()
        {
            new Url(address: urlValida);
            Assert.IsTrue(true);

        }

        [TestMethod]
        [DataRow("https//www.bnana?banana?cocoa&banaca", moreData: true)] // to esperando uma exeção
        [DataRow("http/banana.com.br", moreData: true)]
        [DataRow("banana", moreData: true)]
        [DataRow("", moreData: true)]
        [DataRow("https://balta.io/", moreData: false)] // não to esperando uma exeção
        public void TesteDataRow(
            string link,
            bool ExpectException)
        {
            if (ExpectException)
            {
                try
                {
                    new Url(address: link);
                    Assert.Fail();

                }
                catch (InvalidUrlException)
                {

                    Assert.IsTrue(true);
                }
            }
            else
            {
                new Url(address: link);
                Assert.IsTrue(true);
            }



        }
    }
}
