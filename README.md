# Step 1
Clone source code from repo to a folder in your local machine.
Give that folder full permission.

# Step 2
Open K2America.sln and WebApp.sln(CMS) files in visual studio.

# Step 3
Restore db file into your local system sql server.
Open web.config file in WebApp(CMS) solution.
Update Connection String According to your local machine db in web.config.

# Step 4
build both K2America Solution and WebApp solution successfully.
Run both K2America solution and WebApp Solution in IIS Express localhost port.