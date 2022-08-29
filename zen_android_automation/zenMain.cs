using zen_android_automation.Executer;



namespace zen_android_automation
{
    public class zenAutomation
    
    {
        public string selfDevice { get; set; } = String.Empty;

        

        // Initialize class for Executers
        executeCommand executeCommand = new executeCommand();
        // Initialize for Enums/DeviceConfigs
        Enums.Enums deviceConfig = new Enums.Enums();
        private Enums.Enums.DeviceConfig deviceConfigs;

        public void SetDeviceBuildConfig(Enums.Enums.DeviceConfig value)
        {
            deviceConfigs = value;
        }
        public Enums.Enums.DeviceConfig GetDeviceBuildConfig()
        {
            return deviceConfigs;
        }
        public void zenInit(string? program, string? args, bool waitForExit, bool readOnlyOutput, Enums.Enums.DeviceConfig deviceConfig = Enums.Enums.DeviceConfig.USER, bool usePrebuilt = false)
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