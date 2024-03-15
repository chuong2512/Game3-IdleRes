using System;
using ChuongCustom;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public class BuySkillBtn : AShopBtn
    {
        [SerializeField] private int id = 0;
        [SerializeField] private int _amount = 1, _price = 500;
        [SerializeField] private Button _button;
        [SerializeField] private Text _amountText, _priceText;

        private PlayerData _player;

        protected override void OnStart()
        {
            _player = GameDataManager.Instance.playerData;
        }

        protected override void ShowNotEnoughMoney()
        {
            ToastManager.Instance.ShowMessageToast("Not enough coin!!");
        }

        protected override bool IsEnoughResource()
        {
            return _player.Coin >= _price;
        }

        protected override void OnBuySuccess()
        {
            _player.Coin -= _price;
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            //todo:
        }
    }
}