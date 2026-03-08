using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [Header("Options Buttons")]
    [SerializeField] private Button SoundEffectButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;


    [Header("Keyboard Controlls")]
    [Header("Keyboard Movement")]
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;

    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;


    [Header("Keyboard Interactions")]
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAltButton;

    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAltText;

    [Header("Keyboard Pause")]
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI pauseText;

    [Header("Gamepad Controlls")]
    [Header("Gamepad Interactions")]
    [SerializeField] private Button gamepadInteractButton;
    [SerializeField] private Button gamepadInteractAltButton;

    [SerializeField] private TextMeshProUGUI gamepadInteractText;
    [SerializeField] private TextMeshProUGUI gamepadInteractAltText;

    [Header("Gamepad Pause")]
    [SerializeField] private Button gamepadPauseButton;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;


    [Header("Press To Rebind Key Transform")]
    [SerializeField] private Transform pressToRebindKeyTransform;


    private Action onCloseButtonAction;


    private void Awake()
    {
        Instance = this;
        SoundEffectButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        }); 
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseButtonAction();
        });

        moveUpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Up); });

        moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Down); });

        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left); });

        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right); });

        interactButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Interact); });

        interactAltButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.InteractAlt); });

        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });

        gamepadInteractButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Interact); });

        gamepadInteractAltButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_InteractAlt); });

        gamepadPauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Pause); });
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnLocalGameUnpaused += KitchenGameManager_OnGameUnpaused;

        UpdateVisual();
        HidePressToRebindKey();
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f); 
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlt);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);

        gamepadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        gamepadInteractAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlt);
        gamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }
    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;

        gameObject.SetActive(true);

        SoundEffectButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false); 
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }
    private void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        Debug.Log("Rebinding requested: " + binding);
        ShowPressToRebindKey();

        GameInput.Instance.RebindBinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }


}
