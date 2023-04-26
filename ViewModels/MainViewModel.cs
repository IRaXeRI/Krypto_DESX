using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PKG_V1;

namespace PGK_Z1_UI_V3.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string PrivName1 = "DES-X ";
    private string PrivName2 = "Encryptor";
    private string PrivMainKey = "";
    private string PrivKey1 = "";
    private string PrivKey2 = "";
    private string PrivDataEncrypted = "";
    private string PrivDataDecrypted = "";
    private string PrivPathDecrypted = "";
    private string PrivPathEncrypted = "";
    private byte[] PrivDataBytesEncrypted;
    private byte[] PrivDataBytesDecrypted;

    public string name1 {
        get => PrivName1;
        set {
            if (PrivName1 == value)
                return;
            PrivName1 = value;
            OnPropertyChanged(nameof(name1));
        }
    }
    public string name2 {
        get => PrivName2;
        set {
            if (PrivName2 == value)
                return;
            PrivName2 = value;
            OnPropertyChanged(nameof(name2));
        }
    }
    public string MainKey {
        get => PrivMainKey;
        set {
            if (PrivMainKey == value)
                return;
            PrivMainKey = value;
            OnPropertyChanged(nameof(MainKey));
        }
    }
    public string Key1 {
        get => PrivKey1;
        set
        {
            if (PrivKey1 == value)
                return;

            PrivKey1 = value;
            OnPropertyChanged(nameof(Key1));
        }
    }
    public string Key2 {
        get => PrivKey2;
        set
        {
            if (PrivKey2 == value)
                return;

            PrivKey2 = value;
            OnPropertyChanged(nameof(Key2));
        }
    }
    public string DataEncrypted {
        get => PrivDataEncrypted;
        set
        {
            if (PrivDataEncrypted == value)
                return;

            PrivDataEncrypted = value;
            OnPropertyChanged(nameof(DataEncrypted));
        }
    }
    public string DataDecrypted {
        get => PrivDataDecrypted;
        set
        {
            if (PrivDataDecrypted == value)
                return;

            PrivDataDecrypted = value;
            OnPropertyChanged(nameof(DataDecrypted));
        }
    }
    public string PathEncoded {
        get => PrivPathEncrypted;
        set
        {
            if (PrivPathEncrypted == value)
                return;

            PrivPathEncrypted = value;
            OnPropertyChanged(nameof(DataDecrypted));
        }
    }
    public string PathDecoded {
        get => PrivPathDecrypted;
        set
        {
            if (PrivPathDecrypted == value)
                return;

            PrivPathDecrypted = value;
            OnPropertyChanged(nameof(DataDecrypted));
        }
    }
    
    public byte[] DataBytesEncrypted {
        get => PrivDataBytesEncrypted;
        set
        {
            if (PrivDataBytesEncrypted == value)
                return;

            PrivDataBytesEncrypted = value;
            OnPropertyChanged(nameof(DataDecrypted));
        }
    }
    
    public byte[] DataBytesDecrypted {
        get => PrivDataBytesDecrypted;
        set
        {
            if (PrivDataBytesDecrypted == value)
                return;

            PrivDataBytesDecrypted = value;
            OnPropertyChanged(nameof(DataDecrypted));
        }
    }

    private DesX desX = new DesX();
    private SaveLoad saveLoad = new SaveLoad();
    private Conversion conv = new Conversion();
    
    
    public void GenerateKey() {
        Generator gen = new Generator();
        Key1 = gen.GenerateKey();
        Key2 = gen.GenerateKey();
        MainKey = gen.GenerateKey();
    }

    public void encode()
    {
        DataBytesEncrypted = desX.encrypt(DataBytesDecrypted, MainKey, Key1, Key2);
    }
    public void decode() {
        DataBytesDecrypted = desX.decrypt(DataBytesEncrypted, MainKey, Key1, Key2);
    }

    public void importDecryptedFile()
    {
        DataBytesDecrypted = saveLoad.load(PrivPathDecrypted);
    }
    
    public void saveDecryptedFile()
    {
        saveLoad.save(PrivPathDecrypted, DataBytesDecrypted);
    }
    
    public void importEncryptedFile()
    {
        DataBytesEncrypted = saveLoad.load(PrivPathEncrypted);
    }
    
    public void saveEncryptedFile()
    {
        saveLoad.save(PrivPathEncrypted, DataBytesEncrypted);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}