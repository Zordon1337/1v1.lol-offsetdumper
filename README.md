> [!NOTE]
> Repo is being archived, due to game being shut down this year.

# 1v1.lol SDK Generator
Utility which used(1v1.lol shut down so i will refer to it as "used") to map ingame fields to more familliar name, by generating SDK with useful classes & fields.
## ps: it recomended to read source code before using, otherwise you may not understand how to read generated sdk

Example dump:
```
[GDMIIOPGIJI] PlayerInfo->PlayerXP
[GCCNGNHHLMC] PlayerInfo->PlayerUsername
[NALHMIPKGPO] PlayerController->LocalPlayer
[LFMCIILGNAJ] PlayerController->PlayerHealth
[HBPLNFBJBCI] PlayerController->vThirdPersonController
[GOAKEKDAKJP] PlayerController->PlayerSkinManager
[ODPKDHPJNKP] PlayerController->PlayerEffects
[NFICAPHFDOF] PlayerController->WeaponsController
[OMAIBBFNHCN] PlayerController->EmoteManager
[NLNKNHENDDE] PlayerController->PlayerBoundaries
[AHMPOHOEFGF] PlayerController->PlayerStatModifiers
[OJLHKIFIADP] PlayerController->PlayerAbilities
[PKHFKJGOEKG] PlayerController->PlayerStatusEffects
[ANBLFNMKPOM] PlayerController->PlayerRevive
[OAHKGPBBLCP] PlayerController->IsBot
[JDJGEBHGLMI] PlayerController->IsTeammate
[HGJCDHLIOII] PlayerController->PlayerInfo
```

## How to use
1. Compile SDK Gen
2. Open Assembly-Csharp.dll in DnSpy
3. Find Class "PlayerController"
4. File->Save Code. And save it in Folder with Dumper as PlayerController.cs
5. In PlayerController find line like ```public BABFPNELLFA HGJCDHLIOII```, it should 7th variable from class start
6. Open the variable type class(BABFPNELLFA in this case, just double click on variable type in DnSpy)
7. Do the same thing as in step 4 but save file as PlayerInfo.cs

Please keep in mind that small change in 1v1.lol code can break the generator
