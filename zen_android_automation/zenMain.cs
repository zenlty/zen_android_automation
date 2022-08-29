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
        public void SetDeviceBuildConfig(DeviceConfig value)
        {
            initDeviceConfigs = value;
        }
        public Enums.Enums.DeviceConfig GetDeviceBuildConfig()
        {
            return initDeviceConfigs;
        }
        public void zenInit(string? program, string? args, bool waitForExit = true, bool readOnlyOutput = false, DeviceConfig deviceConfig = DeviceConfig.USER, bool usePrebuilt = false)
        {
            if (usePrebuilt)
            {
                executeCommand.program = program;
            }
            else
            {
                executeCommand.program = "adb.exe";
            }
            executeCommand.args = args;
            executeCommand.waitForExit = waitForExit;
            executeCommand.readOnlyOutput = readOnlyOutput;
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
                    executeCommand.runCommand();
                    executeCommand.args = "remount";
                    executeCommand.runCommand();
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
                    executeCommand.runCommand();
                    executeCommand.args = "remount";
                    executeCommand.runCommand();
                    executeCommand.args = "disable-verity";
                    executeCommand.runCommand();
                    Console.WriteLine("Wait for exit set : " + getWaitForExitStatus);
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
                    break;
                case DeviceConfig.USER_With_Root:
                    initSU = " su -c ";
                    break;
            }
        }
        public string startServer()
        {
            executeCommand.args = "start-server";
            executeCommand.runCommand();
            return "Server is starting now!";
        }
        public string inputTap(string? x,string? y)
        {
            executeCommand.args = "-s " + selfDevice + " shell input tap " + x + " " + y;
            executeCommand.runCommand();
            return "Clicked X: " + x + " Y: " + y;
        }
        public string inputSwipe(string? x1, string? y1, string? x2, string? y2, int time = 200)
        {
           
            executeCommand.args = "-s " + selfDevice + " shell input swipe " + x1 + " " + y1 + " " + x2 + " " + y2 + " " + time;
            executeCommand.runCommand();
            return "Swipe " + x1 + ":" + y1 + " to " + x2 + ":" + y2 + " time=" + time;

        }
        public string inputText(string text)
        {
            executeCommand.args = "-s " + selfDevice + " shell input text " + text;
            executeCommand.runCommand();
            return "Sent!";
           
        }
        public string pressHome()
        {
            return "Sent!";
        }
        public string pressBack()
        {
            return "Sent!";
        }
        public string pressPower()
        {
            return "Sent!";
        }
        public string wakeup()
        {
            return "Sent!";
        }
        public string sleep()
        {
            return "Sent!";
        }
        public string volumeUp()
        {
            return "Sent!";
        }
        public string volumeDown()
        {
            return "Sent!";
        }
        public string keycodeEvent()
        {
            return "Sent!";
        }
        public string launchApp()
        {
            return "Sent!";
        }
        public string closeApp()
        {
            return "Sent!";
        }
        public string listEvents()
        {
            return "Sent!";
        }
        public string openAppDetailInSettings()
        {
            return "Sent!";
        }
        public string searchApp()
        {
            return "Sent!";
        }
        public string listApps()
        {
            return "Sent!";
        }
        public string reConnect()
        {
            return "Sent!";
        }
        public string cleanAppData()
        {
            return "Sent!";
        }
        public string getDeviceName()
        {
            return "Sent!";
        }
        public string getDeviceStatus()
        {
            return "Sent!";
        }
        public string getDevices()
        {
            return "Sent!";
        }
    }
}