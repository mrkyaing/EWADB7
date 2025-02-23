using System.Net;
using System.Net.Sockets;

namespace HRMS.Web.Utilities {
    public static class NetworkHelper {
        public static async Task<string> GetIpAddressAsnyc() {
            string ip = "unknow";
            string url = "https://api.ipify.org";
            try {
                using (HttpClient client = new HttpClient()) {
                    //getting the public IP
                    ip = await client.GetStringAsync(url);//Concurrent  programming style methods
                }
            }
            catch (Exception e) {
                ip = GetLocalIPAddress();//getting the local ip 
            }
            return ip;
        }

        private static string GetLocalIPAddress() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
