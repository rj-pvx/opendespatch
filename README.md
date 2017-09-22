# Open Despatch 

Application interacts with the carrier applications / APIs to complete the despatch process initiated by Peoplevox system.

Following a despatch in the PeopleVox Web application, a file will be downloaded to a folder on the local machine (by default the download folder). This would be an XML file with extension .pvx containing all necessary information to complete the despatch at pack bench.

First the OpenDespatch application will look for any “.pvx” extension files and attempt to find a plugin that can complete the despatch though an external application or API. Once the plugin completed the process, in most cases the carrier label will be printed, and the tracking number is submitted back to Peoplevox. 

There are different guides available for assistance in different tasks regarding OpenDespatch.

1. How to download the code and set up on your local machine:
http://wms.peoplevox.net/app/common/downloads/OpenDespatchClientDownloadInstructionsv2.pdf

2. How to become a contributor.
http://wms.peoplevox.net/app/common/downloads/OpenDespatch_HowtoContribute.pdf

3. Understanding the software architecture of the asp.net project.
http://wms.peoplevox.net/app/common/downloads/OpenDespatchArchitecture.pdf
