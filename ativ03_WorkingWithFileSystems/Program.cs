using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using static System.Console;

partial class Program
{
    static void Main(String[] args)
    {
        /*===============================================================
        ==          Cross-platform environments and filesystems        ==
        ===============================================================*/
        SectionTitle("* Handling cross-platform environments and filesystems");
        WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator", arg1: PathSeparator);
        WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar", arg1: DirectorySeparatorChar);
        WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()", arg1: GetCurrentDirectory());
        WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory", arg1: CurrentDirectory);
        WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory", arg1: SystemDirectory);
        WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()", arg1: GetTempPath());
        WriteLine("GetFolderPath(SpecialFolder");
        WriteLine("{0,-33} {1}", arg0: " .System)", arg1: GetFolderPath(SpecialFolder.System));
        WriteLine("{0,-33} {1}", arg0: " .ApplicationData)", arg1: GetFolderPath(SpecialFolder.ApplicationData));
        WriteLine("{0,-33} {1}", arg0: " .MyDocuments)", arg1: GetFolderPath(SpecialFolder.MyDocuments));
        WriteLine("{0,-33} {1}", arg0: " .Personal)", arg1: GetFolderPath(SpecialFolder.Personal));

        /*===============================================================
        ==                      Managing drives                        ==
        ===============================================================*/
        SectionTitle("Managing drives");
        WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady)
            {
                WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                drive.Name, drive.DriveType, drive.DriveFormat,
                drive.TotalSize, drive.AvailableFreeSpace);
            }
            else
            {
                WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
            }
        }

        /*===============================================================
        ==                   Managing directories                      ==
        ===============================================================*/
        SectionTitle("Managing directories");

        string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "NewFolder");
        WriteLine($"Working with: {newFolder}");

        WriteLine($"Does it exist? {Path.Exists(newFolder)}");

        WriteLine("Creating it...");
        CreateDirectory(newFolder);
        WriteLine($"Does it exist? {Path.Exists(newFolder)}");
        Write("Confirm the directory exists, and then press ENTER: ");
        ReadLine();

        WriteLine("Deleting it...");
        Delete(newFolder, recursive: true);
        WriteLine($"Does it exist? {Path.Exists(newFolder)}");

        /*===============================================================
        ==                      Managing files                         ==
        ===============================================================*/
        SectionTitle("Managing files");

        string dir = Combine(GetFolderPath(SpecialFolder.Personal), "OutputFiles");
        CreateDirectory(dir);

        string textFile = Combine(dir, "Dummy.txt");
        string backupFile = Combine(dir, "Dummy.bak");
        WriteLine($"Working with: {textFile}");

        WriteLine($"Does it exist? {File.Exists(textFile)}");

        StreamWriter textWriter = File.CreateText(textFile);
        textWriter.WriteLine("Hello, C#!");
        textWriter.Close();
        WriteLine($"Does it exist? {File.Exists(textFile)}");

        File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

        WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
        Write("Confirm the files exist, and then press ENTER: ");
        ReadLine();

        File.Delete(textFile);
        WriteLine($"Does it exist? {File.Exists(textFile)}");

        WriteLine($"Reading contents of {backupFile}:");
        StreamReader textReader = File.OpenText(backupFile);
        WriteLine(textReader.ReadToEnd());
        textReader.Close();

        /*===============================================================
        ==                      Managing paths                         ==
        ===============================================================*/
        SectionTitle("Managing paths");
        WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
        WriteLine($"File Name: {GetFileName(textFile)}");
        WriteLine("File Name without Extension: {0}",
        GetFileNameWithoutExtension(textFile));
        WriteLine($"File Extension: {GetExtension(textFile)}");
        WriteLine($"Random File Name: {GetRandomFileName()}");
        WriteLine($"Temporary File Name: {GetTempFileName()}");

        SectionTitle("Getting file information");

        FileInfo info = new(backupFile);
        WriteLine($"{backupFile}:");
        WriteLine($"Contains {info.Length} bytes");
        WriteLine($"Last accessed {info.LastAccessTime}");
        WriteLine($"Has readonly set to {info.IsReadOnly}");

        /*===============================================================
        ==                       Text streams                          ==
        ===============================================================*/
        SectionTitle("Writing to text streams");

        textFile = Combine(CurrentDirectory, "streams.txt");

        StreamWriter text = File.CreateText(textFile);

        foreach (string item in Viper.Callsigns)
        {
            text.WriteLine(item);
        }
        text.Close();

        WriteLine("{0} contains {1:N0} bytes.", arg0: textFile, arg1: new FileInfo(textFile).Length);
        WriteLine(File.ReadAllText(textFile));
    }
}

static class Viper
{
    public static string[] Callsigns = new[]
    {
    "Husker", "Starbuck", "Apollo", "Boomer",
    "Bulldog", "Athena", "Helo", "Racetrack"
    };
}

