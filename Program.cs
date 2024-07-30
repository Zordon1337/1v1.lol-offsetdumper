using System.ComponentModel;
using System.Diagnostics;

class PlayerController {
    public static Dictionary<int, string> List = new Dictionary<int, string> {
        {0, "PlayerController->LocalPlayer"},
        {38, "PlayerController->PlayerHealth"},
        {29, "PlayerController->vThirdPersonController"},
        {30, "PlayerController->PlayerSkinManager"},
        {31, "PlayerController->PlayerEffects"},
        {25, "PlayerController->WeaponsController"},
        {26, "PlayerController->EmoteManager"},
        {33, "PlayerController->PlayerBoundaries"},
        {34, "PlayerController->PlayerStatModifiers"},
        {35, "PlayerController->PlayerAbilities"},
        {36, "PlayerController->PlayerStatusEffects"},
        {39, "PlayerController->PlayerRevive"},
        {7, "PlayerController->IsBot"},
        {18, "PlayerController->IsTeammate"},
        {6, "PlayerController->PlayerInfo"}
    };
    public static void DumpOffsets(int indexbase)
    {
        foreach(var dict in List)
        {
            string fieldname = Utils.DumpField("./PlayerController.cs",indexbase,dict.Key);
            System.IO.File.AppendAllText("./dump.txt", $"[{fieldname}] {dict.Value}\n");
        }
    }
}
class PlayerInfo {
    public static Dictionary<int, string> List = new Dictionary<int, string> {
        {1, "PlayerInfo->PlayerXP"},
        {5, "PlayerInfo->PlayerUsername"}
    };
    public static void DumpOffsets(int indexbase)
    {
        foreach(var dict in List)
        {
            string fieldname = Utils.DumpField("./PlayerInfo.cs",indexbase,dict.Key);
            System.IO.File.AppendAllText("./dump.txt", $"[{fieldname}] {dict.Value}\n");
        }
    }
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
        int index = 1;
        while(i < lines.Length) // skipping 8 lines every field
        {
            if(lines[i].Contains("private async void"))
                return; // first function after fields is Awake() but in case it will change just checking if it is private async void
            string fixedvalue = lines[i].Replace("	",""); // very shit and funny code but i don't have any other idea
            
            //string exposetype = fixedvalue.Split(" ")[0];
            string fieldtype = fixedvalue.Split(" ")[1].Replace(";","");
            string fieldname = fixedvalue.Split(" ")[2].Replace(";","");
            if(fieldtype == "delegate")
                break;
            if(fieldtype == "readonly")
            {
                fieldtype = fixedvalue.Split(" ")[2].Replace(";","");
                fieldname = fixedvalue.Split(" ")[3].Replace(";","");
            }
            if(!fieldtype.Contains("Dictionary"))
            {
                System.IO.File.AppendAllText(file.Replace(".cs","_fulldump.txt"), $"{fieldtype} -> {fieldname} (Index {index})\n");
            }
            
            int linestoskip = 0;
            for(int i2 = i+1; i2 < 9999; i2++)
            {
                if(lines[i2].Contains("public"))
                    {
                        linestoskip = i2 - i;
                        break;
                    }
                if(i2+1 == lines.Length)
                    return;
            }
            i+=linestoskip;
            index++;
        }
    }
    public static string DumpField(string file, int baseindex, int pIndex)
    {
        string[] lines = System.IO.File.ReadAllLines(file);
        int i = baseindex-1;
        int index = 0;
        while(i < lines.Length)
        {
            string fixedvalue = lines[i].Replace("	",""); // very shit and funny code but i don't have any other idea
            //Utils.Log(fixedvalue);
            //string exposetype = fixedvalue.Split(" ")[0];
            string fieldtype = fixedvalue.Split(" ")[1].Replace(";","");
            string fieldname = fixedvalue.Split(" ")[2].Replace(";","");
            if(fieldname == "global::PlayerController") // bad idea but lol
                fieldname = fixedvalue.Split(" ")[3].Replace(";","");
            if(index == pIndex)
                return fieldname;
            if(fieldtype == "delegate")
                break;
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
            index++;
        }
        return "Not found???";
    }
    public static void RemoveExistingDumps()
    {
        List<string> files = new List<string>() {
            {"PlayerInfo_fulldump.txt"},
            {"PlayerController_fulldump"},
            {"PlayerInfo_Dump.txt"},
            {"PlayerController_Dump.txt"},
            {"dump.txt"}
        };
        foreach(var file in files)
        {
            if(File.Exists(file))
                File.Delete(file);
        }
    }
}
class Program {
    static void Main(string[] args)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        if(Utils.CheckFiles())
        {   
            Utils.RemoveExistingDumps();
            Utils.DumpAllFields("./PlayerInfo.cs", Utils.GetIndex("./PlayerInfo.cs", "public List<string>"));
            Utils.DumpAllFields("./PlayerController.cs", Utils.GetIndex("./PlayerController.cs", "public static global::PlayerController"));
            PlayerInfo.DumpOffsets(Utils.GetIndex("./PlayerInfo.cs", "public List<string>"));
            PlayerController.DumpOffsets(Utils.GetIndex("./PlayerController.cs", "public static global::PlayerController"));
        }
        watch.Stop();
        Utils.Log($"Dumping completed in {watch.ElapsedMilliseconds}ms");
    }
}