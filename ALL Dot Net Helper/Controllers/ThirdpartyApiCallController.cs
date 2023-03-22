using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ALL_Dot_Net_Helper.Controllers
{
    [Route("helper/[controller]")]
    [ApiController]
    public class ThirdpartyApiCallController : ControllerBase
    {
        public ThirdpartyApiCallController()
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> CreateGetAPICall(string path)
        {
            try
            {
                HttpClient client = new HttpClient();
                string product = string.Empty;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsStringAsync();//<string>();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Request Failed");
            }
        }

    }
}
