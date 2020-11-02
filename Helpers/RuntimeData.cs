
using System;

namespace Mars.Helpers
{
	public class RuntimeData
	{
		// initiate a type of random num
		public static readonly Random rd = new Random();

		// initiate a type of date
		public static readonly string randdate = DateTime.Now.ToString("yyyy-MM-dd");
		// to store the current datet for all the actions where need to get this dynamic data
		public static string currentdate => randdate;

		// initiate a type of datetime 
		public static readonly string randdatetime = DateTime.Now.ToString("yyyyMMddHHmmss");
		// to store the current datetime for all the actions where need to get this dynamic data
		public static string currentdatetime => randdatetime;

		// to store the random number for all the actions where need to get this dynamic data
		public long randnum { get; set; }

		// define below information for all actions where need to input or check these informaton 
		public static string firstName = "Gary";
		public static string lastName = "Gao";
		public static string email = "0512gaoyuan@gmail.com";
		public static string password = "123123";
		public static string tags = "Locust";
		public static string skillexchange = "JMeter";		
	}
}
