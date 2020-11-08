using System.IO;
using System.Reflection;

namespace LearningEfCore.Tools
{
    internal class PathHandler
    {
        private readonly string rootPath;

        internal PathHandler()
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            DirectoryInfo assemblyDir = Directory.GetParent(assemblyLocation);
            DirectoryInfo parentDir = Directory.GetParent(assemblyDir.FullName);
            for (int i = 0; i < 3; i++)
            {
                parentDir = Directory.GetParent(parentDir.FullName);
            }
            rootPath = parentDir.FullName + @"\";
        }

        internal string MapPath(string virtualPath)
        {
            return string.Concat(rootPath, virtualPath);
        }
    }
}
