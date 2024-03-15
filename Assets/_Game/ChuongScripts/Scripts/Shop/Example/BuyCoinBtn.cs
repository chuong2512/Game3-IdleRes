using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public class BuyCoinBtn : BaseIAPButton
    {
        [SerializeField] private int _amount;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _amountText;

        private PlayerData _player;

        protected override void OnStart()
        {
            _player = GameDataManager.Instance.playerData;

            _button.onClick.AddListener(OnClickButton);

            _amountText.text = $"x{_amount}";
        }

        protected override void OnBuySuccess()
        {
            _player.Coin += _amount;
        }
    }
}