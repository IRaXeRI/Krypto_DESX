using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using PGK_Z1_UI_V3.ViewModels;

namespace PGK_Z1_UI_V3;

public class ViewLocator : IDataTemplate
{
    public IControl Build(object data)
    {
        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object data)
    {
        return false;
        //return data is ViewModelBase;
    }
}