using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aroima.Plugins.Skirt
{
    /// <summary>
    /// 変更終了イベント引数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModelUpdatedEventArgs<T> : EventArgs where T : class
    {
        T src;

        /// <summary>
        /// 変更後データ
        /// </summary>
        public T Src { get => src; }

        public ModelUpdatedEventArgs(T src)
        {
            this.src = src;
        }
    }


    /// <summary>
    /// ViewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewModel<T> where T : class, ICloneable,  new()
    {
        #region メンバ変数

        bool modified = false;
        bool setup = true;
        T seleced = null;
        int currentIndex = -1;
        List<Action<T>> validators = new List<Action<T>>();
        List<T> dataList = new List<T>();
        List<bool> modifedList = new List<bool>();

        #endregion

        #region イベント

        /// <summary>
        /// モデルデータの変更が終了した
        /// </summary>
        public event EventHandler ModelModified;

        /// <summary>
        /// データ選択の変更が終了した
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// 画面にて選択の変更が発生した
        /// </summary>
        public event EventHandler<ModelUpdatedEventArgs<T>> ModelUpdated;

        #endregion

        #region プロパティ

        /// <summary>
        /// 画面での変更有無
        /// </summary>
        public bool Modified
        {
            get => modified;
            set
            {
                if (modified != value)
                {
                    modified = value;
                    OnModelModified(new EventArgs());
                }
            }
        }

        /// <summary>
        /// 選択されているオブジェクト
        /// </summary>
        public T Seleced { get => seleced; }

        /// <summary>
        /// データソース
        /// </summary>
        public List<T> DataSource { get => dataList;
            set
            {
                dataList = value;
                if (dataList != null)
                    for (int i = 0; i < dataList.Count; i++)
                        modifedList.Add(false);
            }
        }

        /// <summary>
        /// 選択中のインデックス
        /// </summary>
        public int CurrentIndex { get => currentIndex; }

        /// <summary>
        /// 変更結果一覧
        /// </summary>
        public List<bool> ModifedList { get => modifedList; set => modifedList = value; }

        public bool Setup { get => setup; set => setup = value; }

        #endregion

        #region プライベートメソッド

        /// <summary>
        /// 変更発生時処理
        /// </summary>
        /// <param name="e"></param>
        private void OnModelModified(EventArgs e)
        {
            if (setup)
                return;

            if (ModelModified != null)
                ModelModified(this, e);
            if (modified)
                modifedList[currentIndex] = true;
        }

        /// <summary>
        /// 選択変更後時処理
        /// </summary>
        /// <param name="e"></param>
        private void OnSelectionChanged(EventArgs e)
        {

            if (SelectionChanged != null)
            {
                try
                {
                    setup = true;
                    SelectionChanged(this, e);
                }
                finally
                {
                    setup = false;
                }
            }
        }

        /// <summary>
        /// 画面変更の検証
        /// </summary>
        /// <returns>問題なければtrue、そうでなければfalse</returns>
        private bool ValidateInput()
        {
            var temp = (T)seleced.Clone();
            try
            {
                // 入力データの検証
                foreach (var validator in validators)
                    validator(temp);
            }
            catch (ValidationException ve)
            {
                MessageBox.Show(ve.Message, "入力不正",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // フォーカスをあてる
                ve.TargetControl.Focus();
                if (ve.TargetControl is TextBox)
                    ((TextBox)ve.TargetControl).SelectAll();

                return false;
            }
            // 変更終了イベント
            if (ModelUpdated != null)
                ModelUpdated(this, new ModelUpdatedEventArgs<T>(temp));
            return true;
        }

        #endregion

        /// <summary>
        /// 画面検証処理の登録
        /// </summary>
        /// <param name="v">画面検証処理</param>
        public void Add(Action<T> v)
        {
            validators.Add(v);
        }

        /// <summary>
        /// 画面変更の確定
        /// </summary>
        public void Commit()
        {
            if (!modified)
                return;
            if (!ValidateInput())
                return;
            Modified = false;
        }

        /// <summary>
        /// 画面変更の取消
        /// </summary>
        public void Cancel()
        {
            if (!modified)
                return;
            OnSelectionChanged(new EventArgs());
            Modified = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newIndex"></param>
        /// <param name="newobj"></param>
        /// <returns></returns>
        public int SelectionChanging(int newIndex, T newobj)
        {
            if (currentIndex == newIndex)
                return currentIndex;
            if (modified)
            {
                if (ValidateInput())
                {
                    currentIndex = newIndex;
                    seleced = newobj;
                    OnSelectionChanged(new EventArgs());
                    Modified = false;
                }
            }
            else
            {
                currentIndex = newIndex;
                seleced = newobj;
                OnSelectionChanged(new EventArgs());
                Modified = false;
            }
            return currentIndex;
        }
    }

    /// <summary>
    /// 入力検証例外
    /// </summary>
    public class ValidationException : Exception
    {
        Control control_;

        public ValidationException(string message, Control control) : base(message)
        {
            this.control_ = control;
        }

        /// <summary>
        /// 発生元コントロール
        /// </summary>
        public Control TargetControl { get => control_; set => control_ = value; }
    }
}
