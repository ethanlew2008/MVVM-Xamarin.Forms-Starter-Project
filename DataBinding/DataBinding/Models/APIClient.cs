using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataBinding
{
    internal class APIClient : MainPage
    {
        HttpClient _httpClient;
        ReqVars vars = new ReqVars();


        public APIClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ReqVars> GetName()
        {
            Uri uri = new Uri("https://api.agify.io/?name=james");
            try
            {
                HttpResponseMessage rs = await _httpClient.GetAsync(uri);
                string rsStr = await rs.Content.ReadAsStringAsync();                
                vars = JsonConvert.DeserializeObject<ReqVars>(rsStr);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return vars;
        }
    }
}
