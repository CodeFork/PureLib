﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PureLib.Legacy.WPF.BusyControl {
    public abstract class BusyViewModelBase : ViewModelBase {
        private bool _isBusy;
        private string _busyContent;

        public bool IsBusy {
            get { return _isBusy; }
            set {
                _isBusy = value;
                RaiseChange(() => IsBusy);
            }
        }
        public string BusyContent {
            get { return _busyContent; }
            set {
                _busyContent = value;
                RaiseChange(() => BusyContent);
            }
        }

        public T BusyWith<T>(string content, Task<T> task) {
            BusyContent = content;
            IsBusy = true;
            try {
                DispatcherFrame frame = new DispatcherFrame();
                task = task.ContinueWith(t => {
                    frame.Continue = false;
                    return t.Result;
                });
                Dispatcher.PushFrame(frame);
                return task.Result;
            }
            finally {
                IsBusy = false;
            }
        }

        public async Task<T> BusyWithAsync<T>(string content, Task<T> task) {
            BusyContent = content;
            IsBusy = true;
            try {
                return await task;
            }
            finally {
                IsBusy = false;
            }
        }
    }
}
