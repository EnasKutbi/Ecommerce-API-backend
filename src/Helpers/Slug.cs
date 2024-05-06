namespace api.Helpers
{
    public class Slug 
    {
        public static string GenerateSlug(string name){
            return name.ToLower().Replace(" ","-");
        }
    }
}
