namespace Cours.Enum 
{
    public enum Role
    {
        Comptable,
       RS,
        Client,
    }
    public class RoleHelper
    {
        public static Array GetRole()
        {
            return Role.GetValues(typeof(Role));
        }
    }
    
}