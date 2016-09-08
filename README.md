# .NET Script Interpreter

Current version : 0.0.1.4 (jan 29th 2013)

Download Now !

**What is DNSI ?**

DNSI is a application that can compile files from various locations (local, network, internet) both in CSharp and VB.NET to library (dll), console application, windows application or into memory, and execute it.

**Why use DNSI ?**

1) There is **no need Visual Studio** to make .NET softwares.

2) There is **no need to (re)compile** your software and **no need to make update patch**.

3) If you put your source code on the web, there is **no need for user to download any exe** but DNSI (currently ~350Ko).

4) Final user is **always up to date** with your software.

5) Integrate Console App and Windows Forms App interaction with your website(s).

**Cool, but, have you an example?**

Imagine context as the following :

File 1 : (located at c:\HomeDev\Project1\Program.cs)
```
namespace HomeDev.Project1
{
  public class Program
  {
    public void Main(string[] args)
    {
    var dNow = Backups.Dev.Functions.GiveMeDateBaby().ToString();
    com.nowhere.files.myFile1.Alert( com.nowhere.files.myFile1.upMyCase("it's ") + dNow );
    }
  }
}
```

File 2 : (located at http://www.nowhere.com/myFile1.cs)
```
namespace com.nowhere.files
{
  public static class myFile1
  {
    public void Alert(string msg)
    { 
      MessageBox.Show(msg);
    }
    
    public string upMyCase(string myString)
    {
      return myString.ToUpper();
    }
    
    public void StartTest(string[] args)
    {
      MessageBox.Show("Hello world !");
    }
  }
}
```

File 3 : (located at \\Backups\Dev\Functions.vb)
```
Namespace Backups.Dev

  Public Module Functions
    Public Function GiveMeDateBaby() as DateTime
      Return DateTime.Now
    End Function
  End Module
End Namespace
```

Then, to exec c:\HomeDev\Project1\Program.cs, just type this command line :

>dnsi.exe "[-debug [true | false]] -x "c:\HomeDev\Project1\Program.cs"

Then showing a message box with "IT'S 2011-08-23 22:05:07" ! ;)

**Another example ?**

A Windows Forms Web Application !

Put into a web page a link like.. <a href="dnsi://host.com/dnsi.php">Run my WinForms Web Application</a>

File 1 : (located at http://host.com/dnsi.php)
```
'------------------ ' ' ' ' ' ' ' ' ' ' ' '------------------

Namespace TestDNSI Public Class Program Public Shared Sub Main(arg as String) MsgBox("date=[" & TestDNSI.ExtendA.GiveMeDate() & "],arg=[" & arg & "]") End Sub
    Public Shared Sub Main(args() as string)
        for i = 0 to args.Length - 1
            msgbox("date=[" & TestDNSI.ExtendA.GiveMeDate() & "],arg(" & i.tostring() & ")=[" & args(i) & "]")
        next i
    End Sub
End Class
End Namespace
```

File 2 : (located at http://host.com/dnsi-extendA.php)
```
<?php // My Extend A ?>
Namespace TestDNSI
  Public Class ExtendA
    Public Shared Function GiveMeDate() as Date
      Return DateTime.Now
    End Function
  End Class
End Namespace
```

**Omagod, more examples plz!**

Yeah! a Windows Forms Web Application with callback !!

Put into a web page a link like.. <a href="dnsi://host.com/dnsi.php">Run my WinForms Web Application with callback</a>

File 1 : (located at http://host.com/dnsi.php)
```
'------------------ ' ' ' '------------------

Namespace TestDNSI Public Class Program inherits Form

    private m_url as string = "http://host.com/dnsi-callback.php?name="
    private textbox1 as textbox

    Public Sub New()
        clientsize = new size(400, 70)
        text = "DNSI WinForms Web Application with callback"
        show()

        dim btmOk as new button()
        btmOk.text = "Ok"
        btmOk.location = new point(
            clientsize.width - btmok.width - 10,
            clientsize.height - btmok.height - 10
        )
        btmok.anchor = ctype((AnchorStyles.Right or AnchorStyles.Bottom), AnchorStyles)
        addhandler btmOk.Click, addressof Valid
        controls.add(btmOk)

        dim label1 as new label() with {.text = "Nom :",.location=new point(10,10),.autosize=true}
        controls.add(label1)

        textbox1 = new textbox() with {
            .name = "textbox1",
            .location = new point(label1.width + 20, 10),
            .size = new size(clientsize.width - (label1.width + 20 + 10), .size.height),
            .anchor = ctype((AnchorStyles.left or AnchorStyles.top or AnchorStyles.right), anchorstyles)
        }
        controls.add(textbox1)
    End Sub

    Private sub Valid()
        if not string.isnullorempty(textbox1.text) then
            process.start(m_url & textbox1.text, string.empty)
            application.exit()
        else
            msgbox("Veuillez indiquer votre nom svp !", MsgBoxStyle.Exclamation)
        end if
    end sub

End Class
End Namespace
```
