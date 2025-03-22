using Newtonsoft.Json;

namespace BlazorApp.Core
{
    public class ResponseHelper
    {
        /// <summary>
        /// Get API response and deserialize response object to class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public static T GetResponse<T>(APIResponse responseModel)
        {
            if (responseModel.StatusCode == 200)
            {
                return JsonConvert.DeserializeObject<T>(responseModel.Result.ToString());
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Get string response from API
        /// </summary>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public static string GetResponse(APIResponse responseModel)
        {
            if (responseModel.StatusCode == 200)
            {
                return responseModel.Result.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get boolean response from api
        /// </summary>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public static bool GetBooleanResponse(APIResponse responseModel)
        {
            if (responseModel.StatusCode == 200)
            {
                return (bool)responseModel.Result;
            }
            else
            {
                return false;
            }
        }
    }
}
