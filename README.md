===============================================================================
               FOLLOWMEFREE: INSTALLATION & TROUBLESHOOTING GUIDE
===============================================================================

1. OVERVIEW
-----------
The FollowMeFree ecosystem consists of three core components:

* API & SERVICE: Must be installed on the same machine. They communicate 
  via named pipes.
* COMMANDER: Initially installed on the server for configuration. Once 
  configured, it can be uninstalled and moved to a remote PC if desired.


2. PREREQUISITES
----------------

[A] SQL SERVER:
    Install SQL Server Express (free). If using an existing network SQL Server, 
    you may skip this.

[B] .NET FRAMEWORK:
    Install .NET Framework 4.8 or higher (File: NDP48-x86-x64-AllOS-ENU.exe).
    Required for FollowMeFree Commander. For Windows 10 and above, this may already be installed.

[C] .NET DESKTOP RUNTIME:
    Install .NET Desktop Runtime 8.0.19 or higher 
    (File: windowsdesktop-runtime-8.0.19-win-x64.exe). 
    Required for FollowMeFree Service.

[D] IIS (INTERNET INFORMATION SERVICES):
    Enable via "Turn Windows features on or off". 
    Ensure "ASP.NET" and ".NET Extensibility" features are enabled.
    Required for FollowMeFree API.


3. PRINTER PREPARATION
----------------------

* VIRTUAL QUEUE:
  Manually add a local printer using port "LPT1". Set the printer to "Paused".
  Name and share the printer as "FMF Print Queue". You will need this name 
  during configuration.

* PHYSICAL PRINTERS:
  Add your physical network printers and name them clearly (e.g., "Kyocera 
  Accounts Dept"). These are the hardware endpoints where documents print.


4. INSTALLATION STEPS
---------------------

1.1 Install the FollowMeFree Service.
1.2 Install the FollowMeFree Commander.
1.3 Launch FollowMeFree Commander as Administrator (Right-click the desktop shortcut -> Run as Admin).
1.4 In the Configuration screen, set the "JobFilePath" (the folder where print jobs will be stored).
1.5 Set the "FMF Printer Name" to the name of your local paused queue 
    (e.g., FMF Print Queue).
1.6 Click "Save".
1.7 Under the Windows Service heading, click "Configure".
1.8 Close settings and click "View Logs" at the top. If you see logs from 
    Source: "Service", the configuration was successful.
1.9 Install .NET 8.0.25 or higher hosting bundle. (The file dotnet-hosting-8.0.25-win.exe is included. This is required for the FollowMeFree API).
2.0 Install the FollowMeFree API.

2.1 Install FollowMeFree Mobile app from the Google Play Store. Use the app to connect to the API and test printing. Create a user account froom the Commander app and set a pin code.
Test the system by logging into it from the mobile app. You will need the IP address of the API server and the port number. Default is 8080 (if it was not changed). eg. 192.168.8.100:8080

--> Next: Create users, departments and printers in the Commander app. Ensure the "FMF Printer Queue" or whatever you named it is shared on your network. Print to this shared printer and release from the mobile app.


5. TROUBLESHOOTING
------------------

(A) FOLDER PERMISSIONS (JobFilePath)
    If the service cannot process jobs, check the permissions of the 
    JobFilePath folder:
    1. Right-click the folder -> Properties -> Security -> Edit.
    2. Add the local group "IIS_IUSRS". 
       (Note: If not found, set Location to the local PC and click Find Now).
    3. Grant "Full Control" to this group and Save.
    4. Tip: Re-running the API installer will also apply these permissions.

(B) API ISSUES
    The API may fail to start if:
    * It cannot reach the SQL Database. Check SQL service status or update 
      credentials by re-running the API installer.
    * The JobFilePath is missing or lacks permissions (see section A).
    * The IIS Site or App Pool is stopped.

(C) IIS MANAGEMENT
    Open IIS Manager to check the following:
    * SITES: Ensure "FollowMeFreeAPI" is started.
    * APP POOLS: Ensure "FollowMeFreeAPIPool" is started.
    * BINDINGS: To change the API port, edit the bindings for the website.

(D) FIREWALL
    Ensure the port used by the API is allowed through the Windows Firewall.

===============================================================================
