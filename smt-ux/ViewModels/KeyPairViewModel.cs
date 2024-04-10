using SecureMessageTransmitter.Models;
using smt_ux.UX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smt_ux.ViewModels
{
    public class KeyPairViewModel : Notifyable
    {
		private KeyPair _Keys;

		public KeyPair Keys
		{
			get { return _Keys; }
			set { _Keys = value; Notify("Keys", "PublicKey", "PrivateKey"); }
		}

		public string PublicKey { get => _Keys.PublicKey; }
        public string PrivateKey { get => _Keys.PublicKey; }


    }
}
