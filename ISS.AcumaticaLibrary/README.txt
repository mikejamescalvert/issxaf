This is a library for accessing Acumatica REST services and it requires an extension of the web services called eCommerceExt. 
This extension contains additional web service endpoints that are used by this library.

Before using this library, you need to import the eCommerceExt extension into your Acumatica instance. 
The extension can be found in the Acumatica Clients git repository hosted on Azure DevOps. You can download the repository using the following command:

After downloading the repository, navigate to the Acumatica\Web Service Extensions folder and import the ISSeCommerceEndpoints.zip project into your Acumatica instance.

Once you have imported the eCommerceExt extension, publish the project and it will add the extension to your instance.