using smt_ux.UX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smt_ux.ViewModels
{
    class MainViewModel : Notifyable
    {
        public MainViewModel()
        {
			KeyPair = new KeyPairViewModel();
        }

        private string _Message;

		public string Message
		{
			get { return _Message; }
			set { _Message = value; Notify("Message"); }
		}

		private KeyPairViewModel _Keys;

		public KeyPairViewModel KeyPair
		{
			get { return _Keys; }
			set { _Keys = value; Notify("KeyPair"); }
		}

		private string _ASN1Encoded;

		public string ASN1Encoded
		{
			get { return _ASN1Encoded; }
			set { _ASN1Encoded = value; Notify("ASN1Encoded"); }
		}


		private string _ASN1Decoded;

		public string ASN1Decoded
		{
			get { return _ASN1Decoded; }
			set { _ASN1Decoded = value; Notify("ASN1Decoded"); }
		}

		private string _PKEncrypted;

		public string PKEncrypted
        {
			get { return _PKEncrypted; }
			set { _PKEncrypted = value; Notify("PKEncrypted"); }
		}

        private string _PKDecrypted;

        public string PKDecrypted
        {
            get { return _PKDecrypted; }
            set { _PKDecrypted = value; Notify("PKDecrypted"); }
        }

    }
}
