
# Manage Azure Blob Storage Example

## Description

This repository provides an example of how to manage Azure Blob Storage using a Node.js application. It demonstrates how to set up and use Azure Blob Storage to upload, download, and list blobs, which is useful for developers looking to integrate Azure storage solutions into their applications.

## Requirements

- Node.js
- Azure Account with Blob Storage setup
- Azure Storage SDK for Node.js
- Yarn or npm for package management

## Mode of Use

1. Clone the repository:
   ```bash
   git clone https://github.com/ferrerallan/manage-azure-blobstorage.git
   ```
2. Navigate to the project directory:
   ```bash
   cd manage-azure-blobstorage
   ```
3. Install the dependencies:
   ```bash
   yarn install
   ```
4. Set up your environment variables for Azure Blob Storage connection string.
5. Run the application:
   ```bash
   node app.js
   ```


### Example of Use

Here is an example of how to upload a file to Azure Blob Storage using the Azure Storage SDK:

```javascript
const {{ BlobServiceClient }} = require("@azure/storage-blob");
const fs = require("fs");

const AZURE_STORAGE_CONNECTION_STRING = process.env.AZURE_STORAGE_CONNECTION_STRING;

async function uploadBlob(containerName, blobName, filePath) {{
  const blobServiceClient = BlobServiceClient.fromConnectionString(AZURE_STORAGE_CONNECTION_STRING);
  const containerClient = blobServiceClient.getContainerClient(containerName);
  const blockBlobClient = containerClient.getBlockBlobClient(blobName);

  const uploadBlobResponse = await blockBlobClient.uploadFile(filePath);
  console.log(`Upload block blob ${{blobName}} successfully`, uploadBlobResponse.requestId);
}}

uploadBlob("my-container", "my-blob", "path/to/file.txt").catch((err) => {{
  console.error("Error uploading blob: ", err);
}});
```

This code initializes a client to interact with Azure Blob Storage, retrieves a container client, and uploads a file to the specified blob.

## License

This project is licensed under the MIT License.

You can access the repository [here](https://github.com/ferrerallan/manage-azure-blobstorage).
