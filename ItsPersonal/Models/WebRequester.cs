using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ItsPersonal.Models
{
	public class WebRequester
	{

		public async Task<string> GetResponseAsStringAsync(string url)
		{
			url = "http://v8.psapi.nrk.no/" + url;
			while (true)
			{
				using (var client = CreateHttpClient(TimeSpan.FromSeconds(5)))
				{
					using (var response = await client.GetAsync(url))
					{
						var result = await response.Content.ReadAsStringAsync();
						return result;
					}
				}
			}

		}

		private static HttpClient CreateHttpClient(TimeSpan responseTimeout)
		{
			var handler = new HttpClientHandler();

			return new HttpClient(handler) { Timeout = responseTimeout };
		}

	}
}