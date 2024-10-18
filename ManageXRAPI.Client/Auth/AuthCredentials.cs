namespace ManageXRAPI.Client.Auth
{
    public class AuthCredentials
    {
        public static string Section = "ManageXR";
    
        public string OrganisationId { get; set; }
    
        public string KeyId { get; set; }
    
        public string KeySecret { get; set; }
    }   
}