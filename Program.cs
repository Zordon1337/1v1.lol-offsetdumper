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
    public static void DumpAllFields(string file, int baseindex)
    {
        
        string[] lines = System.IO.File.ReadAllLines(file);
        int i = baseindex+1;
        while(i < lines.Length) // skipping 8 lines every field
        {
            if(lines[i].Contains("private async void"))
                return; // first function after fields is Awake() but in case it will change just checking if it is private async void
            string fixedvalue = lines[i].Replace("	",""); // very shit and funny code but i don't have any other idea
            
            //string exposetype = fixedvalue.Split(" ")[0];
            string fieldtype = fixedvalue.Split(" ")[1];
            string fieldname = fixedvalue.Split(" ")[2];
            if(fieldtype == "delegate")
                break;
            if(lines[i].Contains("{ get; private set; }"))
            {
                Log($" {fieldtype} -> {fieldname}");
            } else {
                Log($" {fieldtype} -> {fieldname}");
            }
            //foreach(var val in fixedvalue.Split(" "))
            //    Log($"{val}");
            int linestoskip = 0;
            for(int i2 = i+1; i2 < 9999; i2++)
            {
                if(lines[i2].Contains("public"))
                    {
                        linestoskip = i2 - i;
                        break;
                    }
            }
            i+=linestoskip;
        }
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
                Utils.DumpAllFields("./PlayerController.cs", index);

            } else {
                Utils.Log("Failed to found Base index in PlayerController");
            }
        }
    }
}