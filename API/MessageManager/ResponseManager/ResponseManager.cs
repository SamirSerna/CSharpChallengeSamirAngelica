using NUnit.Framework;
using RestSharp;

namespace BusinessSolution.API.MessageManager.ResponseManager
{
    public class ResponseManager
    {
        public void ValidateNoContentResponse(IRestResponse response)
        {
            Assert.AreEqual("application/json;charset=UTF-8", response.ContentType.ToString());
            Assert.AreEqual("NoContent", response.StatusCode.ToString());
        }

        public void ValidateCreatedResponse(IRestResponse response)
        {
            Assert.AreEqual("application/json;charset=UTF-8", response.ContentType.ToString());
            Assert.AreEqual("Created", response.StatusCode.ToString());
        }

        public void ValidateOKResponse(IRestResponse response)
        {
            Assert.AreEqual("application/json;charset=UTF-8", response.ContentType.ToString());
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }
    }
}
