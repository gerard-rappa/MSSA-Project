using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using TacoBoutIt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace TacoBoutIt.Controllers
{
    public class MemeController: Controller
    {
        private IMemeRepository repository;

        public MemeController(IMemeRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Memes.OrderByDescending(x=> x));

        public ViewResult LocalList(Location userLocation) => View(repository.LocalMemes(userLocation).OrderByDescending(x=> x));

        public ViewResult Add()=>  View();

        [HttpPost]
        [RequestSizeLimit(10000000)]
        public async Task<IActionResult> AddAsync(double Latitude, double Longitude)
        {
            Meme meme = new Meme();
            meme.Latitude = Latitude;
            meme.Longitude = Longitude;
            var files = HttpContext.Request.Form.Files;
            bool uploadSuccess = false;
            string uploadedUri = null;

            string extension = "";
            if (files.Count == 0)
            {
                return RedirectToAction("List");
            }
            ///////////////////////////////////////////////////////////////////////
            // Gets extension from uploaded file and adds it to uniquely generated image path
            // Only accepts jpg, png, gif, and webm as of right now
            ///////////////////////////////////////////////////////////////////////
            for (int i = files[0].FileName.Length - 1; i > 0; i--)
            {
                if (files[0].FileName[i] == '.')
                {
                    break;
                }
                extension = files[0].FileName[i].ToString() + extension;                
            }
            //checks for acceptable extensions
            extension = extension.ToLower();
            if (extension == "jpg" || extension == "jpeg" || extension == "png" || extension == "gif" || extension == "webm")
            {
                meme.ImgUrl = Guid.NewGuid().ToString() + "." + extension;
                using (var stream = files[0].OpenReadStream())
                {
                    (uploadSuccess, uploadedUri) = await UploadToBlob(meme.ImgUrl,stream, extension);
                    TempData["uploadedUri"] = uploadedUri;
                }

                repository.Add(meme);
            }
            return RedirectToAction("List");
        }


        private async Task<(bool, string)> UploadToBlob(string filename, Stream stream = null, string extension="")
        {
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=litmemes;AccountKey=ruUZfkyHWwNAc3Od+6wo+Ke4izeKi94dO7hKcoEBLX3Pp8kiFsrNiwIGo1qO7P46e/Nkbg50YsoTcw3FdLwm0w==;EndpointSuffix=core.windows.net";

            // Check whether the connection string can be parsed.
            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                try
                {
                    // Create the CloudBlobClient that represents the Blob storage endpoint
                    CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                    // Add to images container 
                    cloudBlobContainer = cloudBlobClient.GetContainerReference("images");

                    // Set the permissions so the blobs are public. 
                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };
                    await cloudBlobContainer.SetPermissionsAsync(permissions);

                    // Get a reference to the blob address, then upload the file to the blob.
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);

                    
                    if (stream != null)
                    {
                        // Pass in memory stream directly
                        if (extension.Equals("webm"))
                        {
                            cloudBlockBlob.Properties.ContentType = "video/" + extension;
                        }
                        else
                        {
                            cloudBlockBlob.Properties.ContentType = "image/" + extension;
                        }
                        await cloudBlockBlob.UploadFromStreamAsync(stream);
                    }
                    else
                    {
                        return (false, null);
                    }

                    return (true, cloudBlockBlob.SnapshotQualifiedStorageUri.PrimaryUri.ToString());
                }
                catch (StorageException ex)
                {
                    return (false, null);
                }
            }
            else
            {
                return (false, null);
            }

        }


        [HttpPost]
        public IActionResult LocalList(double Latitude, double Longitude)
        {            
            Location userLocation = new Location();
            userLocation.Latitude = Latitude;
            userLocation.Longitude = Longitude;
            if (userLocation.Latitude == 0 && userLocation.Longitude == 0)
            {
                userLocation.Longitude = -71.0;
                userLocation.Latitude = 25.0;
            }
            return RedirectToAction("LocalList", userLocation);
        }
    }
}
