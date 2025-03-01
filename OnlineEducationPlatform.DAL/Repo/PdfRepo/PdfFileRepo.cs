﻿using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repositories
{
    public class PdfFileRepo : IPdfFileRepo
    {
        private readonly EducationPlatformContext _context;

        public PdfFileRepo(EducationPlatformContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PdfFile pdfFile)
        {
            await _context.PdfFile.AddAsync(pdfFile);
            SaveChangesAsync();
        }

        public async Task<IEnumerable<PdfFile>> GetAllAsync()
        {
            var Pdfs = await _context.PdfFile.AsNoTracking().Where(p => p.IsDeleted == false).ToListAsync();
            if (Pdfs != null)
            {
                return Pdfs;
            }
            return null;
        }

        public async Task<PdfFile> GetByIdAsync(int id)
        {

            return await _context.PdfFile.Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(PdfFile pdfFile)
        {
            await SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pdfFile = await _context.PdfFile.FindAsync(id);
            if (pdfFile != null)
            {
                pdfFile.IsDeleted = true;
                await SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> LectureIdExist(int LectureId)
        {
            var courseExist = await _context.Lecture.AnyAsync(c => c.Id == LectureId);
            if (courseExist)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IdExist(int Id)
        {
            var LectureIdExist = await _context.PdfFile.AnyAsync(a => a.Id == Id);
            if (LectureIdExist)
            {
                return true;
            }
            return false;
        }
    }
}
