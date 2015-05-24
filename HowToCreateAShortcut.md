`dnsi.exe -x "uri path to main file"`

Example with [InternetHostSercher](http://code.google.com/p/dnsi/source/browse/#svn%2Fprojects%2FInternetHostSearcher)

```
dnsi.exe -x http://dnsi.googlecode.com/svn/projects/InternetHostSearcher/Program.cs
```

Run [InternetHostSercher](http://code.google.com/p/dnsi/source/browse/#svn%2Fprojects%2FInternetHostSearcher) from a html link using _dnsi://_ prefix :
```
<a href="dnsi://dnsi.googlecode.com/svn/projects/InternetHostSearcher/Program.cs">Run InternetHostSearcher !</a>
```

Autorun at html loaded :
```
<iframe src="dnsi://dnsi.googlecode.com/svn/projects/InternetHostSearcher/Program.cs" style="display: none;"></iframe>
```