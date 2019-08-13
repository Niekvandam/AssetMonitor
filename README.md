# AssetMonitor
The asset monitor is a project that I created for the Gemeente veere so that they can more easily manage their 'assets' like computers and pc's. 
This will save the system managers of the Gemeeente Veere time since they will no longer have to look up the assets used in an external program. 
This is done by importing a .db file which contains a 'log' of each login that happened on every machine in the Gemeente Veere. We then group them and only get the last one per workspace-id
So that we know who used what workspace most recently. Once this data is imported you have the option to choose between multiple queries that can be executed, each their own purpose.
The main query is the selecting of the most recent check in per workspace. 

When running a query, the result will end up in a datagrid, in which you can click on the UserID and workspaceID. These will both take you to their own form in which you can see additional data bout either the user or workspace.



## Installing
This tool is mostly just plug and play, but you do require one important file which I did not include in the repo. This file is called the settings.SECRET.xml. This xml file contains database credentials and the location of the .db file. 
These fields are all required in order to use this tool as intended.

I am planning on adding an example file to the repository, but did not have time to do so yet. So for now, when cloning the repo you need to manually create the file named settings.SECRET.ini. The file should look as follows:
```ini
[LiveDB]
servername=
dbname=
username=
password=

[LocalDB]
localpath=
```
It should speak for itself which value should be appointed to each variable

