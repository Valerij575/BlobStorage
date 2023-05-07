# BlobStorage

Azure Blob Storage ia s powerful cloud-based storage solution provided by Microsoft.
That allows storing and managing large amounts of unstructured data, including video.

1. Create Blob Storage account in Azure portal.
	After crerated, navigate to the "Access keys" section under the "Settings" tab and 
	note down the "Connection string"

2. Create a .Net Core API project

3. Install Azure.Storage.Blobs Nuget package

4. Implement file upload functionality.
	Create Service which will work with BlobServiceClient
	Add DependensyInjection
	Add FileController