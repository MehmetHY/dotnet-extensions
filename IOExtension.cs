using System.IO;

namespace Mhy.Extensions;

public static class IOExtension
{
    public static void CopyDir(this string source,
                               string destination,
                               bool overwrite = false)
    {
        Directory.CreateDirectory(destination);

        foreach (var file in Directory.GetFiles(source))
        {
            var newFile = Path.Combine(destination, Path.GetFileName(file));

            if (!File.Exists(newFile) || overwrite)
                File.Copy(file, newFile, overwrite);
        }

        foreach (var dir in Directory.GetDirectories(source))
        {
            var newDir = Path.Combine(destination, Path.GetFileName(dir));
            Directory.CreateDirectory(newDir);
            dir.CopyDir(newDir, overwrite);
        }
    }
}