using SecureMessageTransmitter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace smt_ux.UX
{
    public abstract class Notifyable : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnNotified(string fn)
        {
        }

        protected virtual void OnPreNotify(params string[] args)
        {
        }

        protected void Notify(params string[] args)
        {
            OnPreNotify(args);
            if (this.PropertyChanged != null)
            {
                args.ForEach(delegate (string s)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(s));
                    OnNotified(s);
                });
            }
        }

    }

}
