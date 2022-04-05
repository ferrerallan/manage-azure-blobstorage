// See https://aka.ms/new-console-template for more information
using Azure.Storage.Blobs;

Console.WriteLine("uploading files in 'files' folder");

string connectionString = "DefaultEndpointsProtocol=https;AccountName=allanstorage;AccountKey=z4RfKqRktwsh/PsvS6DW5U+2SXwS5GKFqDCm4S7dc/M6qGskKBibI9X7AKZx+duG1ACeAddG66WZ+ASt/D3fqA==;EndpointSuffix=core.windows.net";
string containerName =  "allanstorage";

var blobServiceClient = new BlobServiceClient(connectionString);
var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

var files = Directory.GetFiles(Path.Combine("files"));

foreach (var file in files){
  
  using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(file))){
    try {
      containerClient.UploadBlob(Path.GetFileName(file), stream);
    }
    catch(Exception exc){
      Console.WriteLine(exc.Message);
    }
  }
  
  Console.Read();
  
  Console.WriteLine(file);
}

////downloading///
var blobs = containerClient.GetBlobs();

foreach (var blob in blobs){
  BlobClient blobClient = containerClient.GetBlobClient(blob.Name);
  blobClient.DownloadTo(Path.Combine("download")+ "/"+blob.Name);
}
