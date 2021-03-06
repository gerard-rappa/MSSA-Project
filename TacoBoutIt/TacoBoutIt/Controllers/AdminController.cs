﻿using Microsoft.AspNetCore.Mvc;
using TacoBoutIt.Models;
using System.Linq;


using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace TacoBoutIt.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IMemeRepository repository;
        public AdminController(IMemeRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Memes.OrderByDescending(x => x));



        [HttpPost]
        public IActionResult AdminAdd()
        {
            
            var files = HttpContext.Request.Form.Files;
            string path = "wwwroot/Images/admin.jpg";
            if (files.Count == 0)
            {
                return RedirectToAction("Index");
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }
            
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult AdminDelete()
        {

            string path = "wwwroot/Images/admin.jpg";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> DeleteAsync(string memeUrl)
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
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(memeUrl);
                    await cloudBlockBlob.DeleteIfExistsAsync();
                }
                catch (StorageException ex)
                {
                    return RedirectToAction("Index");
                }

                Meme deletedMeme = repository.DeleteMeme(memeUrl);
                if (deletedMeme != null)
                {
                    TempData["message"] = $"{deletedMeme.ImgUrl} was deleted";
                }               
            }
            return RedirectToAction("Index");
        }
    }
}