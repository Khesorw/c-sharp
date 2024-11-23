using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Data;
using Lab5.Models;
using Azure.Storage.Blobs;
using Azure;

namespace Lab5.Pages.Predections
{
    public class CreateModel : PageModel
    {
        private readonly Lab5.Data.PredictionDataContext _context;

       private readonly BlobServiceClient _blobServiceClient;
        private readonly string earthContainerName = "earthimages";
        private readonly string computerContainerName = "computerimages";

     


        public CreateModel(Lab5.Data.PredictionDataContext context,BlobServiceClient blobServiceClient)
        {

            _context = context;
           _blobServiceClient = blobServiceClient;



        }

      
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Prediction Prediction { get; set; }

        [BindProperty]
        public IFormFile image { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
         
            if (image != null)
            {


                var absoluteFilePath = Path.GetFullPath(image.FileName);
             
                BlobContainerClient containerClient;
                var containerName = earthContainerName;

                if (!(Prediction.Question.ToString() == "Earth"))
                {
                    containerName = earthContainerName;
                }
                try
                {
                    containerClient = await _blobServiceClient.CreateBlobContainerAsync(containerName);
                    // Give access to public
                    containerClient.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
                }
                catch (RequestFailedException)
                {
                    containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                }

                try
                {
                     string  = Path.GetRandomFileName(); 
                


                    // create the blob to hold the data
                    var blockBlob = containerClient.GetBlobClient(randomFileName);
                    if (await blockBlob.ExistsAsync())
                    {
                        await blockBlob.DeleteAsync();
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                       
                        await image.CopyToAsync(memoryStream);

                        memoryStream.Position = 0;

                        // send the file to the cloud
                        await blockBlob.UploadAsync(memoryStream);
                        memoryStream.Close();
                    }
                    Prediction.FileName = image.FileName;
                    Prediction.Url = blockBlob.Uri.AbsoluteUri;
                }
                catch (RequestFailedException)
                {
                    RedirectToPage("Error");
                }

            }

            _context.Prediction.Add(Prediction);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
