using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IgoFirst.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Text変更通知プロパティ
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set
            {
                if (_Text == value)
                {
                    return;
                }
                _Text = value;
                RaisePropertyChanged("Text");
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            var clipboardWatcher =
                Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(100)) // 指定間隔で値を発行
                .Where(_ => Clipboard.ContainsText())   // タイマーから値が発行されたタイミングでクリップボードにテキストが含まれるかチェック
                .ObserveOnDispatcher()  // Clipboard.GetText()はSTAスレッドからしか呼び出されないため、UIスレッドに処理を委譲
                .Select(_ => Clipboard.GetText())   // 流れる値がタイマーから発行された数値からクリップボードのテキストに変換
                .Catch((Exception e) => Observable.Return(e.ToString()))
                .ObserveOn(Scheduler.Default)   // 作業スレッドを変更
                .DistinctUntilChanged() // 前の値と違った値が来たときのみ以降の処理を行う
                .Skip(1)    // 最初の値を捨てる。監視前に入力された値を無視するため。
                .Subscribe(x => Text = x);
        }
    }
    
}
