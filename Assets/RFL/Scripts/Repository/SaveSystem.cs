namespace RFL.Scripts.Repository
{
    using System.IO;

    public static class SaveSystem
    {
        public static void Set(string key, string value) => File.WriteAllText(key, value);

        public static bool Get(string key, out string value)
        {
            value = !File.Exists(key) ? null : File.ReadAllText(key);
            return value != null;
        }
    }
}