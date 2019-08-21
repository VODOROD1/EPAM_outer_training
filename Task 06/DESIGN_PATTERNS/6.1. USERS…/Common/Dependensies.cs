using _6._1.USERS_.DAL;

namespace _6._1.USERS_.Common
{
    public static class Dependensies
    {
        public static IStorable GetTextFilesObj { get; } = new TextFiles();

    }
}
