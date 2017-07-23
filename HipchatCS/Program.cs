using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HipchatApiV2;
using System.IO;

namespace HipchatCS
{
	class Program
	{
		static void Main(string[] args)
		{
			String token = System.Environment.GetEnvironmentVariable("HIPCHAT_TOKEN");
            String room_id = System.Environment.GetEnvironmentVariable("HIPCHAT_ROOM_ID");
            String url = System.Environment.GetEnvironmentVariable("HIPCHAT_URL");
            //HipchatClient client = new HipchatClient(token);
            //client.SendNotification("bsc-rockstars", "This is your captain speaking.");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "/v2/room/" + room_id + "/notification");
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token); 
			httpWebRequest.Method = "POST";

			using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string json = "{\"auth_token\":\"" + token + "\"," +
							  "\"from\":\"Aditya\"," +
							  "\"message\": \"Test from csharp code\"}";

				streamWriter.Write(json);
				streamWriter.Flush();
				streamWriter.Close();
			}

			var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				var result = streamReader.ReadToEnd();
			}

		}
	}
}
