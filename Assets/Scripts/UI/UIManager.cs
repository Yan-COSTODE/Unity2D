using UnityEngine;

public class UIManager : SingletonTemplate<UIManager>
{
	#region Fields & Properties
	#region Fields
	[SerializeField] private bool bGameUI;
	[SerializeField] private UIMain uiMain;
	[SerializeField] private HUD hud;
	[SerializeField] private FloatingDamage floatingDamage;
	[SerializeField] private UIPauseMenu uiPauseMenu;
	#endregion
	
	#region Properties
	public UIMain UIMain => uiMain;
	public HUD HUD => hud;
	public UIPauseMenu UIPauseMenu => uiPauseMenu;
	#endregion
	#endregion

	#region Methods
	private void Start()
	{
		if (!hud)
			hud = GetComponentInChildren<HUD>();
		if (!uiMain)
			uiMain = GetComponentInChildren<UIMain>();
		if (!uiPauseMenu)
			uiPauseMenu = GetComponentInChildren<UIPauseMenu>();
		
		Invoke(nameof(Init), 0.1f);
	}

	private void Init()
	{
		SetUI(bGameUI);
	}
	
	public void SetUI(bool _bGameUI)
	{
		bGameUI = _bGameUI;
		uiMain.gameObject.SetActive(!bGameUI);
		hud.gameObject.SetActive(bGameUI);

		if (bGameUI)
		{
			hud.Init();
			SoundManager.Instance.Play(ESound.BACKGROUND, Vector3.zero, 0.0f, true, true);
		}
		else
		{
			uiMain.BackToMenu(false);
			SoundManager.Instance.Play(ESound.MAIN_MENU, Vector3.zero, 0.0f, true, true);
		}
	}

	public FloatingDamage SpawnFloatingDamage(float _damage,  Color _color, Vector3 _position)
	{
		FloatingDamage _floatingDamage = Instantiate(floatingDamage);
		_floatingDamage.Set(_damage, _color, _position);
		return _floatingDamage;
	}
	#endregion
}
