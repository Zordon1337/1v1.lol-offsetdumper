using System;
using System.Collections.Generic;
using JustPlay.AgeGate;
using JustPlay.Equipment;
using JustPlay.Gameplay.Abilities;
using JustPlay.ScriptableObjects;
using Lol.OneVsOne.Settings;
using Photon.Realtime;
using UnityEngine;

public class BABFPNELLFA
{
	public float GDIFAOLGHMG
	{
		get
		{
			if (this.BOLBFHGAICB > 0)
			{
				return (float)this.CEENENGAKBP / (float)this.BOLBFHGAICB;
			}
			return 0f;
		}
	}

	public bool BDPNKNJLHBP
	{
		get
		{
			return !this.OAHKGPBBLCP && !this.DKOGNEBJIPK.BFOMJOGMJFK<string>();
		}
	}

	public BABFPNELLFA(Player OBIFPBIDLHL, int NOOJOFGBCIF)
	{
		this.LCPPIKDKHPK = NOOJOFGBCIF;
		this.BAOEHNPBMPF = OBIFPBIDLHL.ActorNumber;
		this.GDMIIOPGIJI = OBIFPBIDLHL.RankXP;
		this.ECKBEOHOHLL = OBIFPBIDLHL.UserId;
		this.CJOMAJKKLPB = OBIFPBIDLHL.PFBAOLAPCLP();
		this.INFFIPKOBLE = true;
		this.ODNDPPDINMF = OBIFPBIDLHL.Skin;
		if (AgeGateManager.Instance != null)
		{
			this.GCCNGNHHLMC = AgeGateManager.Instance.ToValidNickname(OBIFPBIDLHL.NickName);
		}
		if (string.IsNullOrEmpty(this.GCCNGNHHLMC))
		{
			this.GCCNGNHHLMC = GameProperties.DefaultPlayerName;
		}
	}

	public static BABFPNELLFA ACLAPIECPNM(int IGPGMAOBGDA, string EHJANJOCFNM, Teams.IMNAFDKMMFL GEDKANLGGCO = Teams.IMNAFDKMMFL.None)
	{
		return new BABFPNELLFA(IGPGMAOBGDA, EHJANJOCFNM, GEDKANLGGCO, PlayersManager.OEPCIBFBPLE.MDFIAEAIBPE.Count);
	}

	private BABFPNELLFA(int IGPGMAOBGDA, string EHJANJOCFNM, Teams.IMNAFDKMMFL GEDKANLGGCO, int NOOJOFGBCIF)
	{
		this.BAOEHNPBMPF = IGPGMAOBGDA;
		this.LCPPIKDKHPK = NOOJOFGBCIF;
		this.INFFIPKOBLE = true;
		this.GCCNGNHHLMC = EHJANJOCFNM;
		this.CJOMAJKKLPB = GEDKANLGGCO;
		this.OAHKGPBBLCP = true;
	}

	public void NJNFEBAFLGC(string AMDEHIOENPL, int AIBMBMDDGAA, int JALGGJIIJFN, int KJNDNDJAINP)
	{
		this.NNBHHEDFFID += JALGGJIIJFN;
		Ability ability;
		if (Abilities.OJHFMCJNNPI(AMDEHIOENPL, out ability))
		{
			this.MKBCCMGLDFH += JALGGJIIJFN;
			return;
		}
		WeaponBaseData weaponBaseData;
		if (!SOManagedInstance<WeaponStatsDatabase>.Instance.GINHHCMLIHF(AMDEHIOENPL, out weaponBaseData))
		{
			return;
		}
		int num = Mathf.Min(this.CEENENGAKBP + 1, this.BOLBFHGAICB);
		KJNDNDJAINP = ((KJNDNDJAINP > 0) ? 1 : 0);
		this.MFJIFEPJHPD += KJNDNDJAINP;
		this.CEENENGAKBP = num;
		LIACDELIMOO liacdelimoo = new LIACDELIMOO(AMDEHIOENPL, AIBMBMDDGAA);
		DLCDEKBCIKM dlcdekbcikm;
		if (!this.CPCLPEBOOKA.TryGetValue(liacdelimoo, out dlcdekbcikm))
		{
			dlcdekbcikm = this.AKOAAMDAKAF(AMDEHIOENPL, AIBMBMDDGAA);
		}
		dlcdekbcikm.NNBHHEDFFID += JALGGJIIJFN;
		dlcdekbcikm.FJMFADMJKCI += KJNDNDJAINP;
		dlcdekbcikm.CEENENGAKBP = Mathf.Min(dlcdekbcikm.CEENENGAKBP + 1, dlcdekbcikm.BOLBFHGAICB);
	}

	public void DKMCNAJJAAK(string BIPBDLHHOOO, int AIBMBMDDGAA)
	{
		this.BOLBFHGAICB++;
		LIACDELIMOO liacdelimoo = new LIACDELIMOO(BIPBDLHHOOO, AIBMBMDDGAA);
		DLCDEKBCIKM dlcdekbcikm;
		if (!this.CPCLPEBOOKA.TryGetValue(liacdelimoo, out dlcdekbcikm))
		{
			dlcdekbcikm = this.AKOAAMDAKAF(BIPBDLHHOOO, AIBMBMDDGAA);
		}
		dlcdekbcikm.BOLBFHGAICB++;
	}

	public void AHOOOGMOFDB(int AGKBJCBNCLH)
	{
		this.FINLNLDBENA += AGKBJCBNCLH;
	}

	public void AOKPIFKFKMG(string JMAKIPIDMBI)
	{
		this.AEIKKHDAEGG++;
		if (this.DLJOEFBIKDM(JMAKIPIDMBI))
		{
			if (!this.CAGHHLKMJJA.ContainsKey(JMAKIPIDMBI))
			{
				this.ODAEOAEKJDL(JMAKIPIDMBI);
				return;
			}
			this.CAGHHLKMJJA[JMAKIPIDMBI].CKCEDALMBLA++;
		}
	}

	public void CFHJOHCEDLC(string BIPBDLHHOOO, int AIBMBMDDGAA, int AGKBJCBNCLH)
	{
		LIACDELIMOO liacdelimoo = new LIACDELIMOO(BIPBDLHHOOO, AIBMBMDDGAA);
		DLCDEKBCIKM dlcdekbcikm;
		if (!this.CPCLPEBOOKA.TryGetValue(liacdelimoo, out dlcdekbcikm))
		{
			dlcdekbcikm = this.AKOAAMDAKAF(BIPBDLHHOOO, AIBMBMDDGAA);
		}
		dlcdekbcikm.OBAJEBALPOM += AGKBJCBNCLH;
	}

	public override string ToString()
	{
		return string.Format("Name: {0} Kills: {1} DeathTime: {2}", this.GCCNGNHHLMC, this.AEIKKHDAEGG, this.GJPACKJONIP);
	}

	private bool DLJOEFBIKDM(string JMAKIPIDMBI)
	{
		using (Dictionary<LIACDELIMOO, DLCDEKBCIKM>.ValueCollection.Enumerator enumerator = this.CPCLPEBOOKA.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.NLEBDKNCHCJ.ToLower() == JMAKIPIDMBI.ToLower())
				{
					return true;
				}
			}
		}
		return false;
	}

	private void ODAEOAEKJDL(string JMAKIPIDMBI)
	{
		LocalEquipmentProductData localEquipmentProductData = SOManagedInstance<LocalProductsData>.Instance.KAIFPFOAJMB(JMAKIPIDMBI);
		if (localEquipmentProductData != null)
		{
			AFJPLNEKMIA afjplnekmia = new AFJPLNEKMIA(localEquipmentProductData.DefaultName, 1);
			this.CAGHHLKMJJA.Add(JMAKIPIDMBI, afjplnekmia);
		}
	}

	private DLCDEKBCIKM AKOAAMDAKAF(string BIPBDLHHOOO, int AIBMBMDDGAA)
	{
		LIACDELIMOO liacdelimoo = new LIACDELIMOO(BIPBDLHHOOO, AIBMBMDDGAA);
		DLCDEKBCIKM dlcdekbcikm = new DLCDEKBCIKM
		{
			NLEBDKNCHCJ = BIPBDLHHOOO,
			PFGEJGLMBFN = AIBMBMDDGAA,
			NNBHHEDFFID = 0,
			FJMFADMJKCI = 0,
			BOLBFHGAICB = 0,
			CEENENGAKBP = 0,
			OBAJEBALPOM = 0
		};
		this.CPCLPEBOOKA.Add(liacdelimoo, dlcdekbcikm);
		return dlcdekbcikm;
	}

	public readonly int BAOEHNPBMPF;

	public readonly string ECKBEOHOHLL;

	public readonly Dictionary<LIACDELIMOO, DLCDEKBCIKM> CPCLPEBOOKA = new Dictionary<LIACDELIMOO, DLCDEKBCIKM>();

	public List<string> DKOGNEBJIPK = new List<string>();

	public int GDMIIOPGIJI;

	public int AEIKKHDAEGG;

	public Dictionary<string, AFJPLNEKMIA> CAGHHLKMJJA = new Dictionary<string, AFJPLNEKMIA>();

	public int DOPENJAIFKP;

	public string GCCNGNHHLMC;

	public string ODNDPPDINMF;

	public readonly Teams.IMNAFDKMMFL CJOMAJKKLPB;

	public bool DCDCDFBOGEF;

	public bool INFFIPKOBLE;

	public double GJPACKJONIP;

	public int NNBHHEDFFID;

	public int MKBCCMGLDFH;

	public int BDOHBKBLDDM;

	public int AGOFMAMINNK;

	public int JFNHAEFEMFG;

	public int KEONJLICCGP;

	public int NAJLFBFEAFF;

	public int MFJIFEPJHPD;

	public int BOLBFHGAICB;

	public int CEENENGAKBP;

	public int FINLNLDBENA;

	public int OBPJGNGADDA;

	public int LODCNDDFINA;

	public int KPMJPKPBNFJ;

	public int FGGHKMNPOLK;

	public int MABBJHHBDKH;

	public int PCAJNODGHMF;

	public int EHHGPEDCBFD;

	public float KFBGFOPCJLH;

	public bool OAHKGPBBLCP;

	public int LNFJFOAHCIO;

	public int NHNJJBHIDDO;

	public readonly int LCPPIKDKHPK;
}
