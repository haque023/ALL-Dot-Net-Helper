using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

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
        [Route("CreateGetAPICall")]
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
        public class DataFormat
        {
            public string StrEmail { get; set; }
            public string StrCvData { get; set; }
            public long IntAutoId { get; set; }

        }
        public class DataFormat2k
        {
            public string StrEmail { get; set; }
            public string StrCvData { get; set; }
            public long IntAutoId { get; set; }

        }

        [HttpPost]
        [Route("CreatePostAPICall")]
        public async Task<IActionResult> CreatePostAPICall(DataFormat obj, string path)
        {
            try
            {
                HttpClient client = new HttpClient();
                var jsonInString = JsonConvert.SerializeObject(obj);
                await client.PostAsync(path, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

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
