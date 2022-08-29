# .NET Android Automation and Management Library

- Coding with C# base on .NET Core 6.0 .
- **Always use** the latest version of platform tools. Some features work in the latest version.
 [You can download here.](https://developer.android.com/studio/releases/platform-tools)
- **Do not forget** to turn on USB Debugging before use.
- USERDEBUG functions work when **serial console is active**.

## Usage

- Download the project, compile or get the **latest version** dll from the assemblies.
- For Visual Studio, import the dll file from the references section

### C# Usage
#### Call library
	 zenAutomation zen = new zenAutomation();
#### Init Information
You need to specify more than one configuration
1. First, you must specify the adb.exe **Android Debug Bridge** location.
Or add adb.exe to your **PATH variables** instead.
2. Adb commands take some time to run, sometimes **we run more than one adb command** in sequence. 
It wouldn't be good if one executed command could switch to another before it's finished. 
The variable **waitForExit** controls this setting. My suggestion is that waitForExit **should be true**.
3. We get output with the **outputs of console and string methods**. Is the output of the executed code a single line or full output? **readLineOutput** manages this setting. My recommendation **should be false**.
4. Android OS has multiple build configs. Select the build config of the operating system you are using. 
[You can browse here.](https://source.android.com/docs/setup/build/building)
If you are using **user software**, DeviceConfig.USER,
If you are using **rooted user firmware** DeviceConfig.USER
If you are using **engineering-userdebug firmware** , you should choose DeviceConfig.USERDEBUG.
5. If you don't want to define the PATH, move the platform tools files to the DLL location and set the **usePrebuilt** variable to true. My recommendation **should be false**.
6. Some of my suggestions are defined by default and **if you want to use suggestions** in methods, you can use **"default"**.
        public void zenInit(string? program, bool waitForExit = true, bool readLineOutput = false, DeviceConfig deviceConfig = DeviceConfig.USER, bool usePrebuilt = false)

#### Init Example Usage
	 zenAutomation zen = new zenAutomation();
With the **default** definitions, you can use the suggestions.
Warning: If you activate the **usePrebuilt** value, the first value **string program** will be disabled.

	 zen.zenInit("adb.exe", default, default ,zen_android_automation.Enums.Enums.DeviceConfig.USER, default);
If you want full output,

	 zen.zenInit("adb.exe", default, true ,zen_android_automation.Enums.Enums.DeviceConfig.USER, default);
In method definitions, the **IDE will show which value is used where**.

#### Using an exemplary method
Using the code that sends the android device to the home screen with the KeyCode method :
	 
	 zen.pressHome();
There are two ways to return to the main screen. One is the **KEYCODE_HOME** command and the other is the **keyevent 3** command. You can use the code below to use the second method.

	 zen.pressHome(true);
	 
