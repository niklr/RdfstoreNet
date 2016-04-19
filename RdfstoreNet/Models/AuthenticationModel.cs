namespace RdfstoreNet.Models
{
    /// <summary>
    /// The authentication model used in conjunction with the AccessManager.
    /// http://www.iana.org/assignments/http-authschemes/http-authschemes.xhtml
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// The authentication scheme (e.g. Basic, Bearer, etc.)
        /// </summary>
        public string AuthScheme { get; set; }

        /// <summary>
        /// The authentication data (e.g. Base64 encoded credentials, bearer token, etc.)
        /// </summary>
        public string AuthData { get; set; }
    }
}
