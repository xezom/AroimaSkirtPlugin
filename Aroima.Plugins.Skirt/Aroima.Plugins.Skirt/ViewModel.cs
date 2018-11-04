using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aroima.Plugins.Skirt
{
    public class ModelUpdatedEventArgs<T> : EventArgs where T : class
    {
        T src;

        public T Src { get => src; }
        public ModelUpdatedEventArgs(T src)
        {
            this.src = src;
        }
    }
    //public delegate void ModelUpdatedEventHandler<T> 
    //    (object sender,ModelUpdatedEvent<T> e) where T : class;


    /// <summary>
    /// ViewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewModel<T> where T : class, new()
    {
        bool modified = false;
        bool setup = true;
        T seleced = null;
        int currentIndex = -1;
        List<Action<T>> validators = new List<Action<T>>();
        List<T> dataList = new List<T>();
        List<bool> modifedList = new List<bool>();

        #region イベント

        /// <summary>
        /// UIにてモデルデータの変更が発生した
        /// </summary>
        public event EventHandler ModelModified;

        /// <summary>
        /// UIにてデータ選択の変更が発生した
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// UIにて選択の変更が発生した
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

        public int CurrentIndex { get => currentIndex; }

        public List<bool> ModifedList { get => modifedList; set => modifedList = value; }
        public bool Setup { get => setup; set => setup = value; }

        #endregion

        private void OnModelModified(EventArgs e)
        {
            if (setup)
                return;

            if (ModelModified != null)
                ModelModified(this, e);
            if (modified)
                modifedList[currentIndex] = true;
        }

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

        public void Cancel()
        {
            if (!modified)
                return;
            OnSelectionChanged(new EventArgs());
            Modified = false;
        }

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


        /// <summary>
        /// 画面変更の検証
        /// </summary>
        /// <returns>問題なければtrue、そうでなければfalse</returns>
        public bool ValidateInput()
        {
            var temp = new T();
            try
            {
                foreach (var validator in validators)
                    validator(temp);
            }
            catch (ValidationException ve)
            {
                MessageBox.Show(ve.Message);
                ve.TargetControl.Focus();
                if (ve.TargetControl is TextBox)
                    ((TextBox)ve.TargetControl).SelectAll();

                return false;
            }
            if (ModelUpdated != null)
                ModelUpdated(this, new ModelUpdatedEventArgs<T>(temp));
            return true;
        }
    }

    public class ValidationException : Exception
    {
        Control control_;

        public ValidationException(string message, Control control) : base(message)
        {
            this.control_ = control;
        }

        public Control TargetControl { get => control_; set => control_ = value; }
    }
}
