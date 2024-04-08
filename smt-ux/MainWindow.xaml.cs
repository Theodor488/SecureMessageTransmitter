using SecureMessageTransmitter;
using SecureMessageTransmitter.Models;
using smt_ux.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace smt_ux
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _Model = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _Model;

            _Model.PropertyChanged += _Model_PropertyChanged;

            _Model.Message = "Message to encyrpt";
            GenerateKeys();

            UpdateValues();
        }

        private void UpdateASN1Encoding(string message)
        {
            var bytes = Asn1Encoder.EncodeMessageToAsn1(message);
            _Model.ASN1Encoded = Convert.ToBase64String(bytes);
            _Model.ASN1Decoded = Asn1Encoder.DecodeMessageFromAsn1(bytes);
        }

        private void UpdatePublicKeyEncryption(String message, KeyPair keyPair)
        {
            if (keyPair != null)
            {
                var bytes = RsaEncoder.RsaEncrypt(Encoding.UTF8.GetBytes(message), keyPair.PublicKey);
                _Model.PKEncrypted = Convert.ToBase64String(bytes);
                var decrypted = RsaEncoder.RsaDecrypt(bytes, keyPair.PrivateKey);
                _Model.PKDecrypted = System.Text.Encoding.UTF8.GetString(decrypted);
            }
        }

        private void GenerateKeys()
        {
            _Model.KeyPair.Keys = KeyManager.GenerateRsaKeys();
        }

        private void UpdateValues()
        {
            UpdateASN1Encoding(_Model.Message);
            UpdatePublicKeyEncryption(_Model.Message, _Model.KeyPair.Keys);            
        }

        private void _Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Message")
            {
                UpdateValues();
            }    
        }

        private void GenerateKeys_Click(object sender, RoutedEventArgs e)
        {
            GenerateKeys(); 
        }

        private void CopyASN1Encoded_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_Model.ASN1Encoded);
        }

        private void PKEncrypted_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_Model.PKEncrypted);

        }

        private void PrivateKey_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_Model.KeyPair.PrivateKey);
        }
    }
}