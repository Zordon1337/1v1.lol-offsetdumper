using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Assets.Scripts;
using CodeStage.AntiCheat.ObscuredTypes;
using Cysharp.Threading.Tasks;
using Invector.CharacterController;
using JustPlay.Bots;
using JustPlay.CheatDetection;
using JustPlay.Equipment;
using JustPlay.Gameplay;
using JustPlay.Gameplay.Abilities;
using Photon.Pun;
using Photon.Realtime;
using Rewired;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable, EBNAOBBCIJE, MGNJHBDHIML, MCOKJKMIDIG
{
	public static global::PlayerController NALHMIPKGPO { get; private set; }

	public string LCHHDJMPKBN
	{
		get
		{
			return this.BAOEHNPBMPF.ToString();
		}
	}

	public int MPBMMGMHBCM
	{
		get
		{
			return this.BAOEHNPBMPF;
		}
	}

	public DKIFCEHMHBF AEJGKEMNPJM
	{
		get
		{
			return DKIFCEHMHBF.Players;
		}
	}

	public Collider FFDFHGGJGLN
	{
		get
		{
			return this.FDKAJIHIFMD;
		}
	}

	public Vector3 OLEEIOMBLCP
	{
		get
		{
			return this.GOAKEKDAKJP.GGAKADNHLNG.position;
		}
	}

	public BABFPNELLFA HGJCDHLIOII
	{
		get
		{
			if (this.HDENEDNCKMG == null)
			{
				PlayersManager.OEPCIBFBPLE.MDFIAEAIBPE.TryGetValue(this.BAOEHNPBMPF, out this.HDENEDNCKMG);
			}
			return this.HDENEDNCKMG;
		}
	}

	public bool OAHKGPBBLCP
	{
		get
		{
			if (!this._isBot && base.photonView.InstantiationData != null && base.photonView.InstantiationData.Length != 0)
			{
				this._isBot = (bool)base.photonView.InstantiationData[0];
			}
			return this._isBot;
		}
	}

	public bool BHBCEHICAEC
	{
		get
		{
			if (!this._isRespawn && base.photonView.InstantiationData != null && base.photonView.InstantiationData.Length > 1)
			{
				this._isRespawn = (bool)base.photonView.InstantiationData[1];
			}
			return this._isRespawn;
		}
	}

	public float ENPBPEPJODF
	{
		set
		{
			if (!this.KJLGKIJEHPJ)
			{
				this._thirdPersonController.SetChannelSpeedMultiplier(value);
			}
		}
	}

	public event Action CLMOPEFECHK;

	public bool BELADBHIACG
	{
		get
		{
			return this._thirdPersonController.BELADBHIACG;
		}
	}

	public Vector3 ACPGLKBKHOL
	{
		get
		{
			return this._playerIK.ACPGLKBKHOL;
		}
	}

	public Transform HLOAPDPJHBE
	{
		get
		{
			return this._playerIK.LDIACCDGMEF;
		}
	}

	public ObjectRenderManager NNPAKKFOMOK
	{
		get
		{
			return this._renderManager;
		}
	}

	public CapsuleCollider FDKAJIHIFMD
	{
		get
		{
			return this.GOAKEKDAKJP.PlayerMainCollider;
		}
	}

	public Vector3 BFDPGEJEEOJ
	{
		get
		{
			return base.transform.position + this.FBBIEFIDHCA * base.transform.up;
		}
	}

	public event global::PlayerController.DFENOJJIKGF AKFIOHEGFJP;

	public bool JDJGEBHGLMI
	{
		get
		{
			return !this.IsMine(false) && this.CJOMAJKKLPB != Teams.IMNAFDKMMFL.None && this.CJOMAJKKLPB == PhotonNetwork.LocalPlayer.PFBAOLAPCLP();
		}
	}

	public Teams.IMNAFDKMMFL CJOMAJKKLPB
	{
		get
		{
			BABFPNELLFA playerInfo = this.HGJCDHLIOII;
			if (playerInfo == null)
			{
				return Teams.IMNAFDKMMFL.None;
			}
			return playerInfo.CJOMAJKKLPB;
		}
	}

	public bool DCDCDFBOGEF
	{
		get
		{
			BABFPNELLFA playerInfo = this.HGJCDHLIOII;
			return ((playerInfo != null) ? playerInfo.DCDCDFBOGEF : this.PBDBCCJBHFF) || !base.gameObject.activeInHierarchy;
		}
	}

	public bool PBJPJLAJPOJ { get; private set; } = true;

	public bool MPGMDBJAMFK { get; set; } = true;

	public bool KHJGAEBJOAK
	{
		get
		{
			return ObscuredBool.CGEIFPBHOLI(this._health.KHJGAEBJOAK);
		}
	}

	public float EIJAKGJGNOI
	{
		get
		{
			return Mathf.Min(this._weaponsController.IJDJOBNNOHJ, this._health.HOMKDBMGBNM);
		}
	}

	public WeaponsController NFICAPHFDOF
	{
		get
		{
			return this._weaponsController;
		}
	}

	public EmoteManager OMAIBBFNHCN
	{
		get
		{
			return this._emoteManager;
		}
	}

	public PlayerChannellingController FLNJBBKMBIJ
	{
		get
		{
			return this._playerChannelling;
		}
	}

	public Vector3 PBCEJPPJABD
	{
		get
		{
			return this._thirdPersonController.targetDirection;
		}
	}

	public vThirdPersonController HBPLNFBJBCI
	{
		get
		{
			return this._thirdPersonController;
		}
	}

	public PlayerSkinManager GOAKEKDAKJP
	{
		get
		{
			return this._playerSkinManager;
		}
	}

	public PlayerEffects ODPKDHPJNKP
	{
		get
		{
			return this._playerEffects;
		}
	}

	public Vector3 HHEDJMICHMC { get; private set; }

	public PlayerBoundaries NLNKNHENDDE
	{
		get
		{
			return this._playerBoundaries;
		}
	}

	public PlayerStatModifiers AHMPOHOEFGF
	{
		get
		{
			return this._playerStatModifiers;
		}
	}

	public PlayerAbilities OJLHKIFIADP
	{
		get
		{
			return this._playerAbilities;
		}
	}

	public PlayerStatusEffects PKHFKJGOEKG
	{
		get
		{
			return this._statusEffects;
		}
	}

	public bool KJLGKIJEHPJ { get; set; }

	public PlayerHealth LFMCIILGNAJ
	{
		get
		{
			return this._health;
		}
	}

	public PlayerRevive ANBLFNMKPOM
	{
		get
		{
			return this._playerRevive;
		}
	}

	public bool FMEMPJOEHED
	{
		get
		{
			return this._thirdPersonController.isGodMode;
		}
	}

	public bool HKEMMMMFHDB
	{
		get
		{
			return this.EKJDLEOHOBF;
		}
	}

	public bool OJJEGHCBCGL
	{
		get
		{
			return GameManager.MAPCFNEKHIE && !this.DCDCDFBOGEF && !this._thirdPersonController.IsDiving && !this._thirdPersonController.IsGliding && !this.KHJGAEBJOAK;
		}
	}

	public bool ECAGOKBOHHN
	{
		get
		{
			return this._shouldBotUseArmor;
		}
	}

	public bool LDDBBJGPOJO
	{
		get
		{
			return this._isSuperBot;
		}
	}

	public BattleRoyaleBotController GBDIGMCJBKG
	{
		get
		{
			return this._battleRoyaleBotController;
		}
	}

	public InGamePlayerIndicator MFIGJJNIKDK
	{
		get
		{
			return this._playerIndicator;
		}
	}

	public string KPJOCPDMPNC
	{
		get
		{
			if (!this.GOFDIPBLFFJ.FINBDMFFKCG)
			{
				return string.Empty;
			}
			return this.GOFDIPBLFFJ.PIOFNOBBGLB.ID;
		}
	}

	public int KFIKCJJMLKN
	{
		get
		{
			return this.GOFDIPBLFFJ.KFIKCJJMLKN;
		}
	}

	public int BAOEHNPBMPF
	{
		get
		{
			if (!this.OAHKGPBBLCP)
			{
				return base.photonView.CreatorActorNr;
			}
			return 1000 + base.photonView.ViewID;
		}
	}

	public PlayerCheatsMonitor FODPMOPHFPM { get; private set; }

	public vThirdPersonInput HOBODGBDCOL { get; private set; }

	public PlayerIK HMOKGIBFHAD { get; private set; }

	public PlayerChampion GOFDIPBLFFJ { get; private set; }

	private async void Awake()
	{
		this._thirdPersonController.enabled = true;
		this.FBBIEFIDHCA = this.FDKAJIHIFMD.height * 0.5f;
		PhotonNetwork.SendRate = 24;
		PhotonNetwork.SerializationRate = 24;
		this.OIMNNCADELO = new BBOIIPNGBJK(1f / (float)PhotonNetwork.SerializationRate + Time.fixedDeltaTime);
		this.KAAOEOGCKAG = new Dictionary<PMINEMPECMM, int>
		{
			{
				PMINEMPECMM.Building,
				0
			},
			{
				PMINEMPECMM.Combat,
				1
			},
			{
				PMINEMPECMM.PlacingProps,
				0
			}
		};
		if (this.IsMine(false))
		{
			global::PlayerController.NALHMIPKGPO = this;
		}
		while (!GameManager.Instance)
		{
			await Task.Yield();
		}
		this.NOHBFOPBGOO();
		this.GOAKEKDAKJP.IKKFNOJLPBI += this.DJEHLIHCHBO;
		this.GOAKEKDAKJP.Init();
		this.LFMCIILGNAJ.KKJNOBLDEBF += this.OAKFMKCPHKO;
		this.LFMCIILGNAJ.NONNFKNGICI += this.KIFJONEKEPO;
		this.LFMCIILGNAJ.FAOJKLJOLME += this.LDKPPFJKGGA;
		this._thirdPersonController.AEDECBLBAPD += this.EICJNKFBJNC;
		if (!GameManager.GEJOOEPHNJC && EECGHFGCIPN.KMCLFJPLCLG.DoPlayersStartInDiveState)
		{
			this._thirdPersonController.SetGodMode(true);
			GameManager.Instance.GNBGBBCFOPM += this.PFECBKFMEBH;
		}
	}

	private async void Start()
	{
		this.LFMCIILGNAJ.Init();
		if (!this.IEKGOBJCJAE && GameManager.Instance != null)
		{
			this.PJBKHBJPFMJ();
			if (!this.IsMine(false) && EECGHFGCIPN.KMCLFJPLCLG.WinConditionType == BKLBPOLILJA.Race)
			{
				EDJLOJMOELJ.AJKMIJNOMFI(base.gameObject, GBHAOEGFINP.EHBFJJHOLNM, -1);
			}
		}
		this.ODPKDHPJNKP.Init();
		this._emoteManager.Init(base.photonView);
		if (this.GOAKEKDAKJP.BOLAIFFHKMM != null)
		{
			this.CBPLPELGACB();
		}
		this.GOAKEKDAKJP.DJKICINGGMC += this.CBPLPELGACB;
		if (this.IsMine(true) && this.OAHKGPBBLCP)
		{
			EDJLOJMOELJ.AJKMIJNOMFI(base.gameObject, GBHAOEGFINP.DDOMOPDNAMC, GBHAOEGFINP.GOHJGCOJNIK);
		}
		if (this.IsMine(false))
		{
			await UniTask.WaitUntil(new Func<bool>(this.CNFNMPPGFFB), PlayerLoopTiming.Update, default(CancellationToken));
			EDJLOJMOELJ.AJKMIJNOMFI(base.gameObject, GBHAOEGFINP.FOJPIEHPMNK, GBHAOEGFINP.GOHJGCOJNIK);
			EDJLOJMOELJ.AJKMIJNOMFI(base.gameObject, GBHAOEGFINP.FOJPIEHPMNK, GBHAOEGFINP.GGAKADNHLNG);
			EDJLOJMOELJ.AJKMIJNOMFI(base.gameObject, GBHAOEGFINP.FOJPIEHPMNK, GBHAOEGFINP.MIKMGELCAAJ);
			this._autoAimSphere.SetActive(false);
			if (PDPNOJGODFM.HLACAMDLNDC && !LAPNDFEKEBH.NBNHOLDCFDG)
			{
				this.ChangeControllerMapByState();
			}
		}
		if (this.JDJGEBHGLMI)
		{
			this._autoAimSphere.BMAIJKFHPKC(false);
		}
		if (!this.IsMine(true))
		{
			this.currRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
			this.currRigidbody.useGravity = false;
		}
	}

	private new void OnDisable()
	{
		base.OnDisable();
		this.GOAKEKDAKJP.DJKICINGGMC -= this.CBPLPELGACB;
		Action clmopefechk = this.CLMOPEFECHK;
		if (clmopefechk == null)
		{
			return;
		}
		clmopefechk();
	}

	private void OnDestroy()
	{
		if (global::PlayerController.NALHMIPKGPO == this)
		{
			global::PlayerController.NALHMIPKGPO = null;
		}
		this._thirdPersonController.AEDECBLBAPD -= this.EICJNKFBJNC;
		this.LFMCIILGNAJ.KKJNOBLDEBF -= this.OAKFMKCPHKO;
		this.LFMCIILGNAJ.NONNFKNGICI -= this.KIFJONEKEPO;
		this.LFMCIILGNAJ.FAOJKLJOLME -= this.LDKPPFJKGGA;
		this.GOAKEKDAKJP.IKKFNOJLPBI -= this.DJEHLIHCHBO;
		PlayersManager.KKJNOBLDEBF -= this.GLLJBKPCAII;
	}

	public List<Collider> GetNonTriggerColliders()
	{
		return this.PPENMAFIDFL;
	}

	private void EICJNKFBJNC(bool BIBLKBDHCOL)
	{
		this.FINCNCGLJIF = null;
	}

	private void OAKFMKCPHKO(global::PlayerController MEAMKIGOABA, string PNFFABNPAME, bool CFIOGGMHBJD)
	{
		this.ChangeState(PMINEMPECMM.Building, true);
		this._thirdPersonController.enabled = false;
		this._thirdPersonController.IsCrawling = true;
		if (this.IsMine(true))
		{
			this.GLLJBKPCAII(MEAMKIGOABA);
		}
	}

	private void Update()
	{
		if (!this.IEKGOBJCJAE)
		{
			this.PJBKHBJPFMJ();
		}
		if (this.isChangingState)
		{
			this.isChangingState = false;
		}
		if (!this.IsMine(true))
		{
			this.GLBGFAHJFCN();
			this.OKIOFGPDKBB();
			this.PPOOIBLNLLK();
		}
	}

	private void FixedUpdate()
	{
		this.JIHMJPDGMII();
		this.AKMAEOPOJMK = this.currRigidbody.velocity;
	}

	public void Respawn(Vector3 KJMOJNIHDGE, bool GLBJFEBHGBC = true, bool PPNLHCPNMDE = false)
	{
		this.PBDBCCJBHFF = false;
		this.SetPlayerCollidersState(true);
		base.gameObject.SetActive(true);
		this.LFMCIILGNAJ.ResetProperties();
		this.ODPKDHPJNKP.ApplyCreationEffect(null);
		this._thirdPersonController.enabled = true;
		this._thirdPersonController.IsCrawling = false;
		base.transform.position = KJMOJNIHDGE;
		if (GLBJFEBHGBC)
		{
			PlayersManager.OEPCIBFBPLE.RegisterActivePlayer(this);
		}
	}

	public void ChangeControllerMapByState()
	{
		PDPNOJGODFM.NKPAFHPKJKL(ControllerType.Joystick, this.GetControllerCurrentCategory(), 0);
	}

	public void SetPlayerIndicatorState(bool BIBLKBDHCOL)
	{
		if (this.OAHKGPBBLCP && this._battleRoyaleBotController == null)
		{
			return;
		}
		this._playerIndicator.SetFadingIndicatorState(BIBLKBDHCOL);
	}

	public void TriggerPlayerIndicatorFade()
	{
		if (this.OAHKGPBBLCP && this._battleRoyaleBotController == null)
		{
			return;
		}
		this._playerIndicator.TriggerFadingIndicator();
	}

	public void Die()
	{
		this._health.Die();
	}

	public void ResetToPreviousVelocity()
	{
		this.currRigidbody.velocity = this.AKMAEOPOJMK;
	}

	public bool IsMine(bool PCGCGKACOAC = false)
	{
		return (!this.OAHKGPBBLCP || PCGCGKACOAC) && base.photonView.IsMine;
	}

	public void ChangeState(PMINEMPECMM BEBMPMECIKB, bool MFEACBGEFCB = true)
	{
		if (this.MPGMDBJAMFK && this.IsMine(false))
		{
			base.photonView.RPC("ChangeStateRemote", RpcTarget.All, new object[] { BEBMPMECIKB });
			FirebaseGameplaySettingsData firebaseGameplaySettingsData = BBAFEPOJAKL<FirebaseGameplaySettingsData>.ANPNDNKBCIM;
			bool? flag;
			if (firebaseGameplaySettingsData == null)
			{
				flag = null;
			}
			else
			{
				FpsSettings fpssettings = firebaseGameplaySettingsData.FPSSettings;
				flag = ((fpssettings != null) ? new bool?(fpssettings.ForceActivateAutoSyncColliders) : null);
			}
			bool? flag2 = flag;
			bool flag3 = flag2.GetValueOrDefault() || BEBMPMECIKB == PMINEMPECMM.Building;
			if (flag3 != Physics.autoSyncTransforms)
			{
				Physics.autoSyncTransforms = flag3;
			}
			if (MFEACBGEFCB && HudManager.Instance.FIEMGCMHDFB == ControllerType.Joystick)
			{
				PDPNOJGODFM.NKPAFHPKJKL(ControllerType.Joystick, this.ILCBPLNCHJK(BEBMPMECIKB), 0);
			}
		}
	}

	public bool ChangeStatePressed()
	{
		return PDPNOJGODFM.FGPPCIANNMC(25) && !this.isChangingState && this.isChangingStateAllowed;
	}

	public void SetTargettableState(bool BIBLKBDHCOL, bool KBDCACJIPKM)
	{
		this.PBJPJLAJPOJ = BIBLKBDHCOL;
		if (KBDCACJIPKM)
		{
			this.ToggleAutoAimSphereState(BIBLKBDHCOL);
			this.ToggleAutoShootCancellerState(!BIBLKBDHCOL);
			this.MFIGJJNIKDK.SetIndicatorVisibility(BIBLKBDHCOL);
		}
	}

	public void ToggleAutoAimSphereState(bool BIBLKBDHCOL)
	{
		this._autoAimSphere.BMAIJKFHPKC(BIBLKBDHCOL);
	}

	public void ToggleAutoShootCancellerState(bool BIBLKBDHCOL)
	{
		this._autoShootCanceller.BMAIJKFHPKC(BIBLKBDHCOL);
	}

	private int ILCBPLNCHJK(PMINEMPECMM BEBMPMECIKB)
	{
		return this.KAAOEOGCKAG[BEBMPMECIKB];
	}

	public void TakeDamage(global::PlayerController EFAONLCCJIH, KDHPCGAACPI FHLHIKGIPJC, WeaponStats HMOGIGDDICJ)
	{
		if (ObscuredInt.CGEIFPBHOLI(this.LFMCIILGNAJ.DGAILMBPMNJ) > 0)
		{
			FHLHIKGIPJC.NPDPPGIFGPG = (((float)ObscuredInt.CGEIFPBHOLI(this.LFMCIILGNAJ.DGAILMBPMNJ) - FHLHIKGIPJC.MFCAABBJMAJ <= 0f) ? GBHNCNDMFHC.ShieldBreak : GBHNCNDMFHC.ShieldHit);
		}
		else
		{
			FHLHIKGIPJC.NPDPPGIFGPG = GBHNCNDMFHC.HealthHit;
		}
		if (FHLHIKGIPJC.LOHEPCFAEFC == CJKNLCFMAKJ.Friend && HMOGIGDDICJ.DamageSettings.IsRestorative)
		{
			base.photonView.RPC("TakeRestorativeHit", RpcTarget.All, new object[] { EFAONLCCJIH.BAOEHNPBMPF, FHLHIKGIPJC.ADEILIHMNLP, FHLHIKGIPJC.PFGEJGLMBFN, FHLHIKGIPJC.MAMNFNCELGE, FHLHIKGIPJC.DOFHBFPCJPN, FHLHIKGIPJC.OEJCFMBJFOG });
			return;
		}
		base.photonView.RPC("TakeHit", RpcTarget.All, new object[]
		{
			EFAONLCCJIH.BAOEHNPBMPF,
			FHLHIKGIPJC.ADEILIHMNLP,
			FHLHIKGIPJC.PFGEJGLMBFN,
			FHLHIKGIPJC.MAMNFNCELGE,
			FHLHIKGIPJC.DOFHBFPCJPN,
			FHLHIKGIPJC.OEJCFMBJFOG,
			(int)FHLHIKGIPJC.MFCAABBJMAJ
		});
	}

	public void TakeDamage(string AMDEHIOENPL, int LPDNEIFGGKD, OCFOEALHOHI PNEIJPNEOGN, Vector3? OGKJPIIOMAI)
	{
		base.photonView.RPC("TakeHit", RpcTarget.All, new object[] { AMDEHIOENPL, LPDNEIFGGKD, PNEIJPNEOGN, OGKJPIIOMAI });
	}

	public void TakeDamage(global::PlayerController EFAONLCCJIH, KDHPCGAACPI FHLHIKGIPJC, NDKGGNDGJHG CNHPGCHGCFE)
	{
		base.photonView.RPC("TakeHit", RpcTarget.All, new object[]
		{
			EFAONLCCJIH.BAOEHNPBMPF,
			FHLHIKGIPJC.ADEILIHMNLP,
			(int)FHLHIKGIPJC.MFCAABBJMAJ,
			FHLHIKGIPJC.MAMNFNCELGE
		});
	}

	public void ApplyKnockback(Vector3 FAEJCCIMMJJ)
	{
		this._thirdPersonController.ApplyKnockback(FAEJCCIMMJJ);
	}

	public KDHPCGAACPI GetHitInfo(Collider NCMGHADMKBG, global::PlayerController EFAONLCCJIH, string BIPBDLHHOOO, int AIBMBMDDGAA, bool MACALNOCNMA, Vector3 HLOKOICJPGA, Vector3 BJLNDIEILGI, Vector3 KBAFHJJAFOK, float POOOCDJOKKA)
	{
		if (!this.DCDCDFBOGEF && !ObscuredBool.CGEIFPBHOLI(this.LFMCIILGNAJ.JIKAEKMCGFF))
		{
			CJKNLCFMAKJ cjknlcfmakj = CJKNLCFMAKJ.Enemy;
			if (EFAONLCCJIH == this)
			{
				cjknlcfmakj = CJKNLCFMAKJ.Self;
			}
			else if (this.CJOMAJKKLPB == EFAONLCCJIH.CJOMAJKKLPB && EECGHFGCIPN.KMCLFJPLCLG.IsTeams)
			{
				cjknlcfmakj = CJKNLCFMAKJ.Friend;
			}
			bool flag = NCMGHADMKBG.CompareTag(ANDJKJOHCKK.LNFNMDEOJLP) && MACALNOCNMA;
			return new KDHPCGAACPI(BIPBDLHHOOO, AIBMBMDDGAA, flag, NCMGHADMKBG, BJLNDIEILGI, KBAFHJJAFOK, POOOCDJOKKA, cjknlcfmakj, this, new Vector3?(HLOKOICJPGA), this.ODPKDHPJNKP.FCIBOBICCGB, -1.0, new int?(EFAONLCCJIH.BAOEHNPBMPF));
		}
		return PKJOKMMCCBN.IOJMGJAPGPJ(NCMGHADMKBG, EFAONLCCJIH, BIPBDLHHOOO, AIBMBMDDGAA, HLOKOICJPGA, BJLNDIEILGI, KBAFHJJAFOK, POOOCDJOKKA);
	}

	public KDHPCGAACPI GetHitInfo(Collider NCMGHADMKBG, WeaponModel ONLFBJILMPP, Vector3 HLOKOICJPGA, Vector3 BJLNDIEILGI, Vector3 KBAFHJJAFOK, float POOOCDJOKKA)
	{
		return this.GetHitInfo(NCMGHADMKBG, ONLFBJILMPP.HDIPBEFIEDA, ONLFBJILMPP.LCHHDJMPKBN, ObscuredInt.CGEIFPBHOLI(ONLFBJILMPP.PFGEJGLMBFN), ONLFBJILMPP.MHDDCENIHGH.DamageSettings.CanHeadshot, HLOKOICJPGA, BJLNDIEILGI, KBAFHJJAFOK, POOOCDJOKKA);
	}

	public int GetControllerCurrentCategory()
	{
		return this.ILCBPLNCHJK(this.currentState);
	}

	public void OnPhotonSerializeView(PhotonStream AGCHHBFBONN, PhotonMessageInfo ONPDGDAHABL)
	{
		if (AGCHHBFBONN.IsWriting && base.photonView.IsMine)
		{
			AGCHHBFBONN.SendNext(base.transform.position);
			AGCHHBFBONN.SendNext(base.transform.rotation);
			AGCHHBFBONN.SendNext(this.currRigidbody.velocity);
			AGCHHBFBONN.SendNext(this._thirdPersonController.speed);
			AGCHHBFBONN.SendNext(this._thirdPersonController.direction);
			AGCHHBFBONN.SendNext(this._thirdPersonController.BELADBHIACG);
			AGCHHBFBONN.SendNext(this._thirdPersonController.isSprinting);
			AGCHHBFBONN.SendNext(this._thirdPersonController.isCrouching);
			AGCHHBFBONN.SendNext(this._thirdPersonController.IsCrawling);
			return;
		}
		if (AGCHHBFBONN.IsReading)
		{
			this.EFGHGNCKJNC = (Vector3)AGCHHBFBONN.ReceiveNext();
			this.OKFPAFDHEJJ = (Quaternion)AGCHHBFBONN.ReceiveNext();
			this.BBADNDNPOLK = (Vector3)AGCHHBFBONN.ReceiveNext();
			this.ILFPDDLGNNN = (float)AGCHHBFBONN.ReceiveNext();
			this.BKGLMNLIHKJ = (float)AGCHHBFBONN.ReceiveNext();
			this.DNKOHMBDBJK = (bool)AGCHHBFBONN.ReceiveNext();
			this.JEIOKLFIAKG = (bool)AGCHHBFBONN.ReceiveNext();
			this.BGBIIHNPNLE = (bool)AGCHHBFBONN.ReceiveNext();
			this.COLOBCNKICN = (bool)AGCHHBFBONN.ReceiveNext();
			double sentServerTime = ONPDGDAHABL.SentServerTime;
			if (this.IMJHPIEAJBG < 0.0)
			{
				this.IMJHPIEAJBG = sentServerTime;
			}
			if (this.OIMNNCADELO != null)
			{
				float num = (float)(sentServerTime - this.IMJHPIEAJBG);
				this.IMJHPIEAJBG = sentServerTime;
				this.OIMNNCADELO.FFHOBFNFJIE(num, this.EFGHGNCKJNC, this.BBADNDNPOLK, this.OKFPAFDHEJJ, null);
			}
		}
	}

	public void SetFrozen(bool BIBLKBDHCOL)
	{
		this.EKJDLEOHOBF = BIBLKBDHCOL;
		this._thirdPersonController.movementLockData.MMLJFGNJIAI = BIBLKBDHCOL;
		this._thirdPersonController.movementLockData.MNACBIFIAKO = BIBLKBDHCOL;
	}

	private void GLLJBKPCAII(FKFFCKIGIDG AEPIPPHAJHE)
	{
		this.GLLJBKPCAII(AEPIPPHAJHE.DCCPFFPFOPD);
	}

	private void GLLJBKPCAII(global::PlayerController OGFBNBFAOJJ)
	{
		if (OGFBNBFAOJJ == null || OGFBNBFAOJJ != this)
		{
			return;
		}
		this.PBDBCCJBHFF = true;
		this.SetPlayerCollidersState(false);
		if (this.IsMine(true))
		{
			this._thirdPersonController.movementLockData.MMLJFGNJIAI = true;
			this._thirdPersonController.movementLockData.MNACBIFIAKO = true;
			if (!this.OAHKGPBBLCP)
			{
				this.MFGHDNJMHPA();
			}
		}
		Action clmopefechk = this.CLMOPEFECHK;
		if (clmopefechk == null)
		{
			return;
		}
		clmopefechk();
	}

	private void KIFJONEKEPO(global::PlayerController MEAMKIGOABA, int? JDHHGEGKPLN, string PNFFABNPAME)
	{
		this._thirdPersonController.SetCrawling(true);
	}

	private void LDKPPFJKGGA(global::PlayerController MEAMKIGOABA, int KODCKOMKOHN)
	{
		this._thirdPersonController.SetCrawling(false);
	}

	public void SetPlayerCollidersState(bool BIBLKBDHCOL)
	{
		if (this._playerSkinManager.BOLAIFFHKMM == null || this._playerSkinManager.BOLAIFFHKMM.ActiveRenderers == null)
		{
			return;
		}
		foreach (Collider collider in this._playerSkinManager.BOLAIFFHKMM.PlayerColliders)
		{
			collider.enabled = BIBLKBDHCOL;
		}
	}

	private void CBPLPELGACB()
	{
		if (!BBAFEPOJAKL<FirebaseGameplaySettingsData>.DDMMEMMLIKP || BBAFEPOJAKL<FirebaseGameplaySettingsData>.ANPNDNKBCIM.PlayerSettings == null || Mathf.Abs(BBAFEPOJAKL<FirebaseGameplaySettingsData>.ANPNDNKBCIM.PlayerSettings.HitBoxSizeMultiplier - 1f) < Mathf.Epsilon)
		{
			return;
		}
		float hitBoxSizeMultiplier = BBAFEPOJAKL<FirebaseGameplaySettingsData>.ANPNDNKBCIM.PlayerSettings.HitBoxSizeMultiplier;
		foreach (Collider collider in this._playerSkinManager.BOLAIFFHKMM.PlayerColliders)
		{
			float num = hitBoxSizeMultiplier;
			float num2;
			if (this.HHFGNOMCONP.TryGetValue(collider.name, out num2))
			{
				num = num2;
			}
			SphereCollider sphereCollider = collider as SphereCollider;
			if (sphereCollider == null)
			{
				CapsuleCollider capsuleCollider = collider as CapsuleCollider;
				if (capsuleCollider != null)
				{
					capsuleCollider.radius *= num;
				}
			}
			else
			{
				sphereCollider.radius *= num;
			}
		}
	}

	private void PJBKHBJPFMJ()
	{
		if (GameManager.Instance == null)
		{
			return;
		}
		this.PBDBCCJBHFF = false;
		this.SetPlayerCollidersState(true);
		if (!this.IsMine(true))
		{
			PlayersManager.KKJNOBLDEBF += this.GLLJBKPCAII;
		}
		BABFPNELLFA babfpnellfa = PlayersManager.OEPCIBFBPLE.RegisterActivePlayer(this);
		if (this._playerIndicator != null && babfpnellfa != null)
		{
			int playerId = this.BAOEHNPBMPF;
			Photon.Realtime.Player localPlayer = PhotonNetwork.LocalPlayer;
			int? num = ((localPlayer != null) ? new int?(localPlayer.ActorNumber) : null);
			bool flag;
			if (!((playerId == num.GetValueOrDefault()) & (num != null)) && babfpnellfa.CJOMAJKKLPB != Teams.IMNAFDKMMFL.None && EECGHFGCIPN.KMCLFJPLCLG.IsTeams)
			{
				Teams.IMNAFDKMMFL cjomajkklpb = babfpnellfa.CJOMAJKKLPB;
				Photon.Realtime.Player localPlayer2 = PhotonNetwork.LocalPlayer;
				Teams.IMNAFDKMMFL? imnafdkmmfl = ((localPlayer2 != null) ? new Teams.IMNAFDKMMFL?(localPlayer2.PFBAOLAPCLP()) : null);
				flag = (cjomajkklpb == imnafdkmmfl.GetValueOrDefault()) & (imnafdkmmfl != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			Color color = PlayerColors.CLNNOLNPNDN(babfpnellfa, flag2);
			this._playerIndicator.InitIndicator(babfpnellfa.GCCNGNHHLMC, color, flag2, this.IsMine(false), babfpnellfa.GDMIIOPGIJI, true, this);
		}
		this.IEKGOBJCJAE = true;
	}

	private void MFGHDNJMHPA()
	{
		if (this._thirdPersonController.isCrouching)
		{
			this._thirdPersonController.Crouch(true);
		}
	}

	private void JIHMJPDGMII()
	{
		if (!this._thirdPersonController.BELADBHIACG)
		{
			if (!this.KOLGEEEILOH)
			{
				this.KOLGEEEILOH = true;
				this.FINCNCGLJIF = new float?(base.transform.position.y);
			}
			if (this._thirdPersonController.IsDiving && !this._thirdPersonController.IsGliding && base.transform.position.y <= Map.Instance.KAELEJBACHA)
			{
				this._thirdPersonController.SetGlideState(true);
				return;
			}
		}
		else if (this._thirdPersonController.BELADBHIACG)
		{
			if (this.KOLGEEEILOH && this.FINCNCGLJIF != null)
			{
				if (!EECGHFGCIPN.KMCLFJPLCLG.IsParkourMode)
				{
					this.ODPKDHPJNKP.ApplyLandingEffect();
				}
				AudioManager.OEPCIBFBPLE.PlayClip(JCHMPJPEAKG.PlayerLand, base.transform, 1f);
				this.LFMCIILGNAJ.HandleFallDamage(this.FINCNCGLJIF.Value, base.transform.position.y);
			}
			this.KOLGEEEILOH = false;
		}
	}

	private void GLBGFAHJFCN()
	{
		if (this.OIMNNCADELO.KCLGNKDOPFC)
		{
			this.OIMNNCADELO.GOHHPLFPLKD(Time.deltaTime);
			base.transform.position = this.OIMNNCADELO.HGDADGCHOCE;
			base.transform.rotation = this.OIMNNCADELO.CMAFJCFJJPG;
			this.HHEDJMICHMC = this.OIMNNCADELO.MFNJADLFGGA;
		}
	}

	private void OKIOFGPDKBB()
	{
		this._thirdPersonController.speed = this.ILFPDDLGNNN;
		this._thirdPersonController.direction = this.BKGLMNLIHKJ;
		this._thirdPersonController.BELADBHIACG = this.DNKOHMBDBJK;
		this._thirdPersonController.verticalVelocity = this.BBADNDNPOLK.y;
		this._thirdPersonController.isSprinting = this.JEIOKLFIAKG;
		this._thirdPersonController.isCrouching = this.BGBIIHNPNLE;
		this._thirdPersonController.isStrafing = this.isStrafing;
		this._thirdPersonController.IsCrawling = this.COLOBCNKICN;
		this._thirdPersonController.UpdateAnimator();
	}

	private void PPOOIBLNLLK()
	{
		this.GOAKEKDAKJP.UpdateMainCollider(!this.BGBIIHNPNLE);
	}

	private void NOHBFOPBGOO()
	{
		if (this._renderManager == null)
		{
			this._renderManager = base.GetComponentInChildren<ObjectRenderManager>();
		}
		if (this._weaponsController == null)
		{
			this._weaponsController = base.GetComponent<WeaponsController>();
		}
		if (this._health == null)
		{
			this._health = base.GetComponent<PlayerHealth>();
		}
		if (this._playerSkinManager == null)
		{
			this._playerSkinManager = base.GetComponent<PlayerSkinManager>();
		}
		if (this._playerEffects == null)
		{
			this._playerEffects = base.GetComponent<PlayerEffects>();
		}
		if (this._playerBoundaries == null)
		{
			this._playerBoundaries = base.GetComponent<PlayerBoundaries>();
		}
	}

	public override void OnMasterClientSwitched(Photon.Realtime.Player ELFHFBDKODG)
	{
		base.OnMasterClientSwitched(ELFHFBDKODG);
		if (PhotonNetwork.IsMasterClient && this.IsMine(true))
		{
			this.currRigidbody.constraints &= (RigidbodyConstraints)(-5);
			this.currRigidbody.useGravity = true;
		}
	}

	[PunRPC]
	public void ChangeStateRemote(PMINEMPECMM BEBMPMECIKB)
	{
		if (!this.DCDCDFBOGEF)
		{
			this.isChangingState = true;
			this.previousState = this.currentState;
			this.currentState = BEBMPMECIKB;
			global::PlayerController.DFENOJJIKGF akfiohegfjp = this.AKFIOHEGFJP;
			if (akfiohegfjp == null)
			{
				return;
			}
			akfiohegfjp(BEBMPMECIKB);
		}
	}

	[PunRPC]
	public void ChangeColorRPC(float JAGLCKEHGGH)
	{
		this._playerEffects.ChangeColorRemote(JAGLCKEHGGH);
	}

	public void ResetLastYPosition()
	{
		this.FINCNCGLJIF = null;
	}

	private void DJEHLIHCHBO()
	{
		this.PPENMAFIDFL.Clear();
		this.PPENMAFIDFL.Add(this.FDKAJIHIFMD);
		this.PPENMAFIDFL.Add(this.HBPLNFBJBCI.MEFCPBENNFC);
		this.PPENMAFIDFL.Add(this.HBPLNFBJBCI.OHPEFKKHHDE);
		this.PPENMAFIDFL.Add(this._playerSkinManager.BOLAIFFHKMM.GetHeadCollider());
		this.PPENMAFIDFL.Add(this._playerSkinManager.BOLAIFFHKMM.GetRootCollider());
	}

	Transform EBNAOBBCIJE.KJHJPEGONNN()
	{
		return base.transform;
	}

	Transform MCOKJKMIDIG.EFCDKOFHBIO()
	{
		return base.transform;
	}

	[CompilerGenerated]
	private void PFECBKFMEBH()
	{
		this._thirdPersonController.SetGodMode(false);
	}

	[CompilerGenerated]
	private bool CNFNMPPGFFB()
	{
		return this.GOAKEKDAKJP.NALNKCPHINP;
	}

	public PlayerBuildingManager PlayerBuildingManager;

	public bool isStrafing = true;

	[HideInInspector]
	public float OffenceMultiplier = 1f;

	public PMINEMPECMM currentState = PMINEMPECMM.Building;

	public PMINEMPECMM previousState = PMINEMPECMM.Building;

	[HideInInspector]
	public bool isChangingState;

	[HideInInspector]
	public bool isChangingStateAllowed = true;

	private readonly Dictionary<string, float> HHFGNOMCONP = new Dictionary<string, float>
	{
		{ "Spine_01", 1f },
		{ "Spine_02", 1f },
		{ "HeadCollider", 2f },
		{ "Collider", 1f }
	};

	[SerializeField]
	private bool _isBot;

	[SerializeField]
	private bool _shouldBotUseArmor;

	[SerializeField]
	private bool _isSuperBot;

	[SerializeField]
	private bool _isRespawn;

	[SerializeField]
	private Rigidbody currRigidbody;

	[SerializeField]
	private vThirdPersonController _thirdPersonController;

	[SerializeField]
	private GameObject _autoAimSphere;

	[SerializeField]
	private GameObject _autoShootCanceller;

	[SerializeField]
	private BattleRoyaleBotController _battleRoyaleBotController;

	[SerializeField]
	private ObjectRenderManager _renderManager;

	[SerializeField]
	private WeaponsController _weaponsController;

	[SerializeField]
	private PlayerStatModifiers _playerStatModifiers;

	[SerializeField]
	private PlayerChannellingController _playerChannelling;

	[SerializeField]
	private PlayerSkinManager _playerSkinManager;

	[SerializeField]
	private PlayerEffects _playerEffects;

	[SerializeField]
	private PlayerHealth _health;

	[SerializeField]
	private PlayerRevive _playerRevive;

	[SerializeField]
	private PlayerBoundaries _playerBoundaries;

	[SerializeField]
	private PlayerAbilities _playerAbilities;

	[SerializeField]
	private PlayerIK _playerIK;

	[SerializeField]
	private EmoteManager _emoteManager;

	[SerializeField]
	private InGamePlayerIndicator _playerIndicator;

	[SerializeField]
	private PlayerStatusEffects _statusEffects;

	private readonly List<Collider> PPENMAFIDFL = new List<Collider>();

	private bool EKJDLEOHOBF;

	private bool KOLGEEEILOH = true;

	private bool IEKGOBJCJAE;

	private bool PBDBCCJBHFF;

	private float? FINCNCGLJIF;

	private Vector3 AKMAEOPOJMK;

	private Dictionary<PMINEMPECMM, int> KAAOEOGCKAG;

	private double IMJHPIEAJBG = double.NegativeInfinity;

	private BBOIIPNGBJK OIMNNCADELO;

	private BABFPNELLFA HDENEDNCKMG;

	private float FBBIEFIDHCA;

	private Vector3 EFGHGNCKJNC;

	private Quaternion OKFPAFDHEJJ;

	private Vector3 BBADNDNPOLK;

	private float ILFPDDLGNNN;

	private float BKGLMNLIHKJ;

	private bool DNKOHMBDBJK;

	private bool JEIOKLFIAKG;

	private bool BGBIIHNPNLE;

	private bool COLOBCNKICN;

	public delegate void DFENOJJIKGF(PMINEMPECMM BEBMPMECIKB);
}
