﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;
using Azure.Storage.Blobs;

namespace Lab5.Pages.Predections
{
    public class DeleteModel : PageModel
    {
        private readonly Lab5.Data.PredictionDataContext _context;

        private readonly BlobServiceClient _blobServiceClient;
        private readonly string earthContainerName = "earthimages";
        private readonly string computerContainerName = "computerimages";

        public DeleteModel(Lab5.Data.PredictionDataContext context,BlobServiceClient  blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        [BindProperty]
      public Prediction Prediction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prediction == null)
            {
                return NotFound();
            }

            var prediction = await _context.Prediction.FirstOrDefaultAsync(m => m.PredectionId == id);

            if (prediction == null)
            {
                return NotFound();
            }
            else 
            {
                Prediction = prediction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Prediction == null)
            {
                return NotFound();
            }
            var prediction = await _context.Prediction.FindAsync(id);

            if (prediction != null)
            {
                Prediction = prediction;
                _context.Prediction.Remove(Prediction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
