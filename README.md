# AcumaticaNiceLabelIntegration

This project contains source code and the Project for showcasing the NiceLabel integration with Acumatica

The file can be utilized as a Acumatica Customization Project steps to publish are below.

Steps to publish the customization.
1. Build the code in the NiceLabelDemo_Code with the build output path pointing to the cloned NiceLabelDemo folder as shown below. The build configuration can be found by righting clicking on the project and then clicking on the properties option 
![image](https://user-images.githubusercontent.com/13830240/160849043-7e22e245-4222-4f45-a65e-9e111b814299.png)


2. Launch a Acumatica instance (preferrably 2021R2 version)
3. Open Customization Projects (SM204505 - Customization Projects) Screen
4. Create a new customization by clicking on the "+" icon, and name it "NiceLabelDemo", as shown below
 ![image](https://user-images.githubusercontent.com/13830240/160195694-62b3312e-5da5-4d2e-8ef3-4788082e0907.png)
5. Click on the "NiceLabelDemo" project, Customization Project Editor opens up
6. On the customization Project Editor, click on the "Source control" tab and "Open Project from folder" menu highlighted below
![image](https://user-images.githubusercontent.com/13830240/160196054-cffcb7bd-426b-47bf-a536-ba7b12bfb014.png)
7. On the "Open Project from Folder" dialog box which opens up, select the path to the cloned folder "NiceLabelDemo" from the repository.
8. Notice the Custom Screens, files, Database scripts and sitemap sections being populated on the customization project editor as shown
![image](https://user-images.githubusercontent.com/13830240/160196531-6914c836-4853-4791-85bd-d3f394311281.png)
9. Click on "Publish Current Project" option from "Publish" menu on the Customization Project Editor
10. The customization should be published with the success message as shown below

![image](https://user-images.githubusercontent.com/13830240/160199197-d2b5d13a-a256-43a9-a3ca-0e3c03bf5e94.png)

11. You can find the custom screens on the main menu as shown below

![image](https://user-images.githubusercontent.com/13830240/160199361-391e2f1e-b784-412b-a4e9-3fa74205fa8f.png)


--> Use the NiceLabel Add Subscription Key screen , to add the subscription key from NiceLabel


--> Use the NiceLabel Preferences screen to Map the Customer Class from Acumatica with a Label and Printer from NiceLabel


--> Use the NiceLabel Sync screen to populate all the Label and printers from Nicelabel available for this demo


--> Prior to this, please do subscribe to Nice label

I) Get a subscription key and the cloud account. You can check by opening the nice label control centers.


II) Create the demo labels in NiceLabel Designer and save the save to the cloud account. You can find the label on the control center


III) Launch NiceLabelAutomation Manager and get the custom url (sample ones are given below) for the following to get 


List of Labels : "https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-LabelCatalog"

List of printers: "https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Printers"

To print: "https://labelcloudapi.onnicelabel.com/Trigger/v1/CloudTrigger/Api-CloudIntegrationDemo-Print" (with the label ID from the NiceLabel Designer)

Please use the documentation from NiceLabel for more details(https://help.nicelabel.com/hc/en-001/articles/4408433528337-Getting-started-with-NiceLabel-Cloud) 
         
IV) Replace the URLs in the ..\NiceLabelDemo_Code\NiceLabelDemo\Helper\NLWebCalls.cs file

    
    
-->Compile the NiceLabelDemo_Code project with the changed URL and publish the customization project with the updated NiceLabelDemo.dll, to utilize the labels created.
    





