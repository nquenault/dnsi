
```
<dnsi>
	/* Main parameters */
	<target value="[exe|winexe|memory|run]" />	// compilation mode
	<autorun value="true" />			// optional autorun (default is false)
	<entrypoint value="MyClass" />			// entry point of the program
	<output value="MyProgram.exe" />		// if needed, the output filename
	<args value="[args]" />

	/* Install options */
	<shortcut target="desktop" /> 
	<shortcut target="startmenu" />

	/* Required libraries */
	<library file="C:\MyLibraries\MyLibrary.dll" />
	<library file="SomeGAC.dll" />

	/* Local source code files */
	<link src="Program.cs" />
	<link src="Main.Designer.cs" />
	<link src="Main.cs" />

	/* Remote source code files */
	<link src="http://www.myhost.com/remoteSource/SomeVBNet.vb" />
	<link src="http://www.myhost.com/remoteSource/Utils.cs" />
</dnsi>
```