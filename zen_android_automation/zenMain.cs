using zen_android_automation.Executer;
using static zen_android_automation.Enums.Enums;

namespace zen_android_automation
{
    public class zenAutomation

    {
        public string selfDevice { get; set; } = String.Empty;
        public string initSU { get; set; } = String.Empty;


        // Initialize class for Executers
        executeCommand executeCommand = new executeCommand();
        // Initialize for Enums/DeviceConfigs
        Enums.Enums deviceConfig = new Enums.Enums();
        private Enums.Enums.DeviceConfig initDeviceConfigs;
        private bool getWaitForExitStatus;
        private bool getOutputType;
        public void SetDeviceBuildConfig(DeviceConfig value)
        {
            initDeviceConfigs = value;
        }
        public Enums.Enums.DeviceConfig GetDeviceBuildConfig()
        {
            return initDeviceConfigs;
        }
        public void zenInit(string? program, bool waitForExit = true, bool readLineOutput = false, DeviceConfig deviceConfig = DeviceConfig.USER, bool usePrebuilt = false)
        {
            if (usePrebuilt)
            {
                executeCommand.program = program;
            }
            else
            {
                executeCommand.program = "adb.exe";
            }
            executeCommand.args = "";
            executeCommand.waitForExit = waitForExit;
            executeCommand.readLineOutput = readLineOutput;
            SetDeviceBuildConfig(deviceConfig);
            InitalizeRootConfigs(deviceConfig);
        }
        public string ActivateAdbRoot() // Only support USERDEBUG builds
        {
            switch (GetDeviceBuildConfig())
            {
                case DeviceConfig.USER:
                    return "Only support USERDEBUG software";
                case DeviceConfig.USERDEBUG:
                    getWaitForExitStatus = executeCommand.waitForExit;
                    Console.WriteLine("Wait for exit set true");
                    executeCommand.waitForExit = true;
                    executeCommand.args = "root";
                    Console.WriteLine(executeCommand.runCommand());
                    executeCommand.args = "remount";
                    Console.WriteLine(executeCommand.runCommand());
                    executeCommand.waitForExit = getWaitForExitStatus;
                    Console.WriteLine("Wait for exit set : " + getWaitForExitStatus);
                    return "Executed all process!";
                    
                case DeviceConfig.USER_With_Root:
                    return "Only support USERDEBUG software";
                default:
                    return "Please configure init method";
            }
        }
        public string DisableDMVerity() // Only support USERDEBUG builds
        {
            switch (GetDeviceBuildConfig())
            {
                case DeviceConfig.USER:
                    return "Only support USERDEBUG software";
                case DeviceConfig.USERDEBUG:
                    getWaitForExitStatus = executeCommand.waitForExit;
                    Console.WriteLine("Wait for exit set true");
                    executeCommand.waitForExit = true;
                    executeCommand.args = "root";
                    Console.WriteLine(executeCommand.runCommand());
                    executeCommand.args = "remount";
                    Console.WriteLine(executeCommand.runCommand());
                    executeCommand.args = "disable-verity";
                    Console.WriteLine(executeCommand.runCommand());
                    Console.WriteLine("Wait for exit set : " + getWaitForExitStatus);
                    executeCommand.waitForExit = getWaitForExitStatus;
                    Console.WriteLine("Please reboot device and activate root permissions");
                    return "Executed all process!";

                case DeviceConfig.USER_With_Root:
                    return "Only support USERDEBUG software";
                default:
                    return "Please configure init method";
            }
        }
        public void InitalizeRootConfigs(DeviceConfig deviceConfig)
        {
            switch (deviceConfig)
            {
                case DeviceConfig.USER:
                    initSU = "";
                    break;
                case DeviceConfig.USERDEBUG:
                    initSU = "";
                    Console.WriteLine("Please dont forget : Activate root permission");
                    break;
                case DeviceConfig.USER_With_Root:
                    initSU = " su -c ";
                    break;
            }
        }
        public string startServer()
        {
            executeCommand.args = "start-server";
            Console.WriteLine(executeCommand.runCommand());
            return "Server is starting now!";
        }
        public string inputTap(string? x,string? y)
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + "  input tap " + x + " " + y;
            Console.WriteLine(executeCommand.runCommand());
            return "Clicked X: " + x + " Y: " + y;
        }
        public string inputSwipe(string? x1, string? y1, string? x2, string? y2, int time = 200)
        {
           
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + "  input swipe " + x1 + " " + y1 + " " + x2 + " " + y2 + " " + time;
            Console.WriteLine(executeCommand.runCommand());
            return "Swipe " + x1 + ":" + y1 + " to " + x2 + ":" + y2 + " time=" + time;

        }
        public string inputText(string text)
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + "  input text " + text;
            return executeCommand.runCommand();
           
        }
        public string pressHome(bool method2 = false) // Please dont forget! Method 2 support some devices. 
        {
            if (method2)
            {
                executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent 3";

            }
            else
            {
                executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent KEYCODE_HOME";
            }
            return executeCommand.runCommand();
        }
        public string pressBack()
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent KEYCODE_BACK";
            return executeCommand.runCommand();
        }
        public string pressPower()
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent KEYCODE_POWER";
            return executeCommand.runCommand();
        }
        public string wakeup()
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent KEYCODE_WAKEUP";
            return executeCommand.runCommand();
        }
        public string sleep()
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent KEYCODE_SLEEP";
            return executeCommand.runCommand();
        }
        public string volumeUp()
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent KEYCODE_VOLUMEUP";
            return executeCommand.runCommand();
        }
        public string volumeDown()
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent KEYCODE_VOLUMEDOWN";
            return executeCommand.runCommand();
        }
        public string keycodeEvent(string keyCode)
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " input keyevent " + keyCode;
            return executeCommand.runCommand();
        }

        public string launchApp(string packageName, bool closeFirst = false)
        {
            if (closeFirst) // 1. Close app 2. Launch app
            {
                getWaitForExitStatus = executeCommand.waitForExit;
                Console.WriteLine("Wait for exit set true");
                executeCommand.waitForExit = true;
                // Close App
                executeCommand.args = "-s " + selfDevice + " shell " + initSU + " am force-stop " + packageName;
                executeCommand.runCommand();
                // Launch App
                executeCommand.args = "-s " + selfDevice + " shell " + initSU + " monkey -p " + packageName;
                executeCommand.runCommand();
                executeCommand.waitForExit = getWaitForExitStatus;
                Console.WriteLine("Wait for exit set : " + getWaitForExitStatus);
                return executeCommand.runCommand();

            }
            else // Just launch app
            {
                executeCommand.args = "-s " + selfDevice + " shell " + initSU + " monkey -p " + packageName;
                return executeCommand.runCommand();
            }
        }
        public string closeApp(string packageName)
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " am force-stop " + packageName;
            return executeCommand.runCommand();
        }

        public string openAppDetailInSettings(string packageName)
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " am start -a android.settings.APPLICATION_DETAILS_SETTINGS -d package:" + packageName;

            return executeCommand.runCommand();
        }
        public string listPackages()
        {
            getOutputType = executeCommand.readLineOutput;
            Console.WriteLine("Full output is true");
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " pm list packages";
            Console.WriteLine(executeCommand.runCommand());
            executeCommand.readLineOutput = getOutputType;
            Console.WriteLine("Read only output set : " + getWaitForExitStatus);
            return executeCommand.runCommand();
        }
        public string reConnect() // Only support wirelles-debugging
        {
            getWaitForExitStatus = executeCommand.waitForExit;
            Console.WriteLine("Wait for exit set true");
            executeCommand.waitForExit = true;


            executeCommand.args = "disconnect";

            Console.WriteLine(executeCommand.runCommand());
            executeCommand.args = "connect " + selfDevice;

            return executeCommand.runCommand();
        }
        public string cleanAppData(string packageName)
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " pm clear " + packageName ;
            return executeCommand.runCommand();
        }
        public string getDeviceName()
        {
            executeCommand.args = "-s " + selfDevice + " shell " + initSU + " getprop ro.product.device";

            return executeCommand.runCommand();
        }
        public string getDeviceStatus()
        {
            executeCommand.args = "-s " + selfDevice + " get-state";
            return executeCommand.runCommand();
        }
        public string getDevices()
        {
            executeCommand.args = "devices";
            executeCommand.runCommand();
            return executeCommand.runCommand();
        }
    }
}