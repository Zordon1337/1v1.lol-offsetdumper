class PlayerController {

}
class Utils {
    public static void Log(string c)
    {
        Console.WriteLine($"[+] {c}");
    }
    public static bool CheckFiles()
    {
        if(!File.Exists("./PlayerController.cs"))
        {
            Log("PlayerController file not found");
            Console.ReadLine();
            Environment.Exit(1);
        }
        return true;
    }
    public static int GetIndex(string File, string reference)
    {
        string[] file = System.IO.File.ReadAllLines(File);
        for(int i = 0; i < file.Length; i++)
        {
            string line = file[i];
            if(line.Contains(reference))
                return i+1; // skipping one line because of space???
        }
        return -1; // if line won't be found
    }
}
class Program {
    static void Main(string[] args)
    {
        if(Utils.CheckFiles())
        {   int index = Utils.GetIndex("./PlayerController.cs", "public static global::PlayerController");
            if(index > 0)
            {
                Utils.Log("Found Base Index at line " + index);

            } else {
                Utils.Log("Failed to found Base index in PlayerController");
            }
        }
    }
}